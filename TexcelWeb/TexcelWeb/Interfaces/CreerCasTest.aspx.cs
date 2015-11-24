using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
using System.IO;
using TexcelWeb.Classes;
using System.Data;
using System.Web.UI.HtmlControls;


namespace TexcelWeb
{
    public partial class CreerCasTest : System.Web.UI.Page
    {
        static bool modif;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CasTest casTest;
                //Premier loading de la page
                if (CtrlController.GetCurrentUser() == null)
                {
                    //Not logged in
                    Response.Redirect("login.aspx");
                }
                else
                {
                    //Formatage Bienvenue, [NomUtilisateur] et la Date
                    Utilisateur currentUser = CtrlController.GetCurrentUser();
                    txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
                }

                //Longueur des champs
                setFieldLength();
                Session["modifProjet"] = false;
                string codeCasTest = String.Format("{0}", Request.QueryString["codeCasTest"]);
                if (codeCasTest != "")
                {
                    casTest = CtrlCasTest.GetCasTestByCode(codeCasTest);
                    Session["casTest"] = casTest;
                    modif = true;
                }


                ChargerDropDownList();
                btnEnregistrer.Text = "Enregistrer";
                txtDateCreationCasTest.Text = Convert.ToString(DateTime.Today.ToString("d"));

                //Mode modifier
                if (Session["casTest"] != null)
                {
                    txtCodeCasTest.Enabled = false;
                    btnEnregistrer.Text = "Modifier";
                    modif = true;
                    casTest = (CasTest)Session["casTest"];
                    Session["CasTestFichier"] = Session["casTest"];
                    Session["ModifCasTest"] = casTest;
                    RemplirChamps(casTest);
                    Titre.InnerText = "Modifier un cas de test";
                    Fichiers(casTest);
                    Session["casTest"] = null;
                }
                else
                {
                    modif = false;
                    btnCopier.Visible = false;
                    FileUpload1.Visible = false;
                    btnUpload.Visible = false;
                }
            }
        }

        public void Fichiers(CasTest _casTest)
        {
            //Si ya pas de dossier, création d'un dossier
            string path = HttpContext.Current.Server.MapPath(@"~/CasDeTest/" + _casTest.codeCasTest);
            if (!(Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);
            }

            string[] filePaths = CtrlCasTest.GetPaths(_casTest);
            
            /////
            int indexTableCasTest;
            if (filePaths.Count() != 0)
            {
                //Nombre de page pour la table des cas de tests
                double page = (double)filePaths.Count() / 5;
                int nbPage = Convert.ToInt16(Math.Ceiling(page));

                //Savoir sil faut afficher plus d'une page dans la table
                if (nbPage < 2)
                {
                    dataGridPagination.Visible = false;
                    fillTableFichier(0, filePaths.ToList(), 1);
                }
                else
                {
                    //Plus de 5 cas de test donc plusieur page de cas test
                    //Index pour la liste des cas test
                    indexTableCasTest = Convert.ToInt16(Request.QueryString["index"]);

                    //Pagination visible
                    dataGridPagination.Visible = true;

                    //Emplissage de la table
                    fillTableFichier(indexTableCasTest, filePaths.ToList(), nbPage);
                }
            }
        }

        private void fillTableFichier(int index, List<string> lstFichier, int nbPage)
        {
            int nuCasTest;
            if (index == 0 || index == 1)
            {
                index = 1;
                nuCasTest = 0;
            }
            else
            {
                nuCasTest = index * 5 - 5;
            }

            if (nbPage != 1)
            {
                //Creation des bouton de navigation entre les pages
                for (int i = 1; i <= nbPage; i++)
                {
                    HtmlGenericControl htmlGC = new HtmlGenericControl("a");
                    if (i == index)
                    {
                        htmlGC.Attributes.Add("class", "active");
                    }
                    htmlGC.Attributes.Add("href", "creerCasTest.aspx?index=" + i);
                    htmlGC.InnerText = i.ToString();
                    dataGridPagination.Controls.Add(htmlGC);
                }
            }

            List<Fichier> lstFichierAfficher = new List<Fichier>();
            //Emplissage des cas de test dans le gridView
            for (int i = nuCasTest; i < nuCasTest + 5; i++)
            {
                if (i < lstFichier.Count)
                {
                    FileInfo fi = new FileInfo(lstFichier[i]);
                    long fileSizeInBytes = fi.Length;

                    Fichier fich = new Fichier(fi.Name, fileSizeInBytes, fi.Extension, fi.LastWriteTime);
                    lstFichierAfficher.Add(fich);
                }
                else
                {
                    break;
                }
            }
            ajoutDonnesDataGrid(lstFichierAfficher);
        }
        private void ajoutDonnesDataGrid(List<Fichier> lstFichier)
        {

            DataTable dT = new DataTable();
            dT.Columns.AddRange(new DataColumn[4] { new DataColumn("File Name", typeof(string)), new DataColumn("Taille", typeof(string)), new DataColumn("Extansion", typeof(string)), new DataColumn("Derniere modification", typeof(DateTime)) });
 
            int cpt = 0;
            foreach (Fichier fichier in lstFichier)
            {
                cpt++;
                DataRow dR = dT.NewRow();

                dR["File Name"] = fichier.path;
                dR["Taille"] = fichier.taille;
                dR["Extansion"] = fichier.extan;
                dR["Derniere modification"] = fichier.derModif;
                dT.Rows.Add(dR);
            }
            GridView1.DataSource = dT;
            GridView1.DataBind();
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            CasTest casTest = (CasTest)Session["ModifCasTest"];
            cProjet proj = CtrlProjet.GetProjet(String.Format("{0}", Request.Form["DropDownProjet"]));
            Difficulte diff = null;
            NiveauPriorite nivPri = null;
            TypeTest typTest = CtrlTypeTest.GetTypeTest(String.Format("{0}", Request.Form["dropDownTypeTestCasTest"]));

          
            if (String.Format("{0}", Request.Form["dropDownDifficulteCasTest"]) != "Aucun")
            {
                diff = CtrlDifficulte.GetDiff(String.Format("{0}", Request.Form["dropDownDifficulteCasTest"]));
            }

            if (String.Format("{0}", Request.Form["dropDownPrioritéCasTest"]) != "Aucun")
            {
                nivPri = CtrlNivPriorite.GetNivPrio(String.Format("{0}", Request.Form["dropDownPrioritéCasTest"]));
            }

            //if (String.Format("{0}", Request.Form["dropDownTypeTestCasTest"]) != "Aucun")
            //{
            //    typTest = CtrlTypeTest.GetTypeTest(String.Format("{0}", Request.Form["dropDownTypeTestCasTest"]));
            //}
            if (!modif)
            {
                if (CtrlCasTest.Ajouter(txtCodeCasTest.Text, txtNomCasTest.Text, proj, diff, nivPri, Convert.ToDateTime(txtDateCreationCasTest.Text), txtDateLivraisonCasTest.Text, typTest, rtxtDescriptionCasTest.Text, rtxtObjectifCastest.Text, rtxtDiversCasTest.Text))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Cas de test ajouté!', 'Le cas de test a été ajouté avec succès.', 'success');", true);
                    ViderChamps();
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Une erreur est survenue lors de la création du cas de test.', 'error');", true);
                    Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue');</script>");
                }
            }
            else
            {
                if (CtrlCasTest.Modifier(txtNomCasTest.Text, proj, diff, nivPri, Convert.ToDateTime(txtDateCreationCasTest.Text), txtDateLivraisonCasTest.Text, typTest, rtxtDescriptionCasTest.Text, rtxtObjectifCastest.Text, rtxtDiversCasTest.Text, casTest))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Cas de test modifié!', 'Le cas de test a été modifié avec succès.', 'success');", true);
                    
                    RemplirChamps(casTest);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Une erreur est survenue lors de la modification du cas de test', 'error');", true);
                }
            }
           
           
        }
        private void setFieldLength()
        {
            int maxLengthCodeCasTest = CtrlCasTest.GetMaxLength<CasTest>(CasTest => CasTest.codeCasTest);
            int maxLengthNomCasTest = CtrlCasTest.GetMaxLength<CasTest>(CasTest => CasTest.nomCasTest);
            txtCodeCasTest.MaxLength = maxLengthCodeCasTest;
            txtNomCasTest.MaxLength = maxLengthNomCasTest;
        }
        protected void ChargerDropDownList()
        {
            dropDownProjet.Items.Clear();
            dropDownTypeTestCasTest.Items.Clear();
            //dropDownTypeTestCasTest.Items.Add("Aucun");
            dropDownDifficulteCasTest.Items.Clear();
            dropDownDifficulteCasTest.Items.Add("Aucun");
            dropDownPrioritéCasTest.Items.Clear();
            dropDownPrioritéCasTest.Items.Add("Aucun");

            foreach (cProjet proj in CtrlProjet.GetListProjet())
            {
                dropDownProjet.Items.Add(proj.nomProjet);
            }
            foreach (TypeTest tT in CtrlTypeTest.GetLstTypeTest())
            {
                dropDownTypeTestCasTest.Items.Add(tT.nomTest);
            }
            foreach (Difficulte diff in CtrlDifficulte.GetLstDiff())
            {
                dropDownDifficulteCasTest.Items.Add(diff.nomDiff);
            }
            foreach (NiveauPriorite nivPrio in CtrlNivPriorite.GetLstNivPrio())
            {
                dropDownPrioritéCasTest.Items.Add(nivPrio.nomNivPri);
            }
        }

        protected void btnCopier_Click(object sender, EventArgs e)
        {
            string Param = "CasTest";
            DateTime? dt = new DateTime?();

            if (txtDateLivraisonCasTest.Text == "")
            {
                dt = null;              
            }
            else
            {
               dt =  Convert.ToDateTime(txtDateLivraisonCasTest.Text);
            }
                    
            // Envoie de param 
            CtrlCasTest.CopierCasTestEnCours(txtCodeCasTest.Text,txtNomCasTest.Text,CtrlProjet.getProjetByCode(dropDownProjet.SelectedValue),
                CtrlDifficulte.GetDiff(dropDownDifficulteCasTest.SelectedValue),CtrlNivPriorite.GetNivPrio(dropDownPrioritéCasTest.SelectedValue),
                Convert.ToDateTime(txtDateCreationCasTest.Text),Convert.ToDateTime(dt),CtrlTypeTest.GetTypeTest(dropDownTypeTestCasTest.SelectedValue),
                rtxtDescriptionCasTest.Text);    
                        
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('copierCasTest.aspx?Param=" + Param + "');", true);
           
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            CasTest casTest = (CasTest)Session["CasTestFichier"];         
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~/CasDeTest/" + casTest.codeCasTest + "/") + fileName);
            Session["casTest"] = casTest;
            Response.Redirect(Request.Url.AbsoluteUri);
            
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            CasTest casTest = (CasTest)Session["CasTestFichier"];
            string filePath = Request.MapPath(@"~/CasDeTest/" + casTest.codeCasTest + "/" + (sender as LinkButton).CommandArgument);
            File.Delete(filePath);
            Session["casTest"] = casTest;
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            CasTest casTest = (CasTest)Session["CasTestFichier"];
            string filePath = Request.MapPath(@"~/CasDeTest/" + casTest.codeCasTest + "/" + (sender as LinkButton).CommandArgument);
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        public void ViderChamps()
        {
            txtCodeCasTest.Text = "";
            txtNomCasTest.Text = "";
            dropDownDifficulteCasTest.Text = "Aucun";
            dropDownPrioritéCasTest.Text = "Aucun";
            txtDateCreationCasTest.Text = Convert.ToString(DateTime.Today.ToString("d"));
            txtDateLivraisonCasTest.Text = "";
            rtxtDescriptionCasTest.Text = "";

        }

        public void RemplirChamps(CasTest casTest)
        {

            txtNomCasTest.Text = casTest.nomCasTest;
            txtCodeCasTest.Text = casTest.codeCasTest;
            if (casTest.cProjet != null)
            {
                dropDownProjet.Text = casTest.cProjet.nomProjet;
            }
            else
            {
                dropDownProjet.Text = "Aucun";
            }

            if (casTest.Difficulte != null)
            {
                dropDownDifficulteCasTest.Text = casTest.Difficulte.nomDiff;
            }
            else
            {
                dropDownDifficulteCasTest.Text = "Aucun";
            }

            if (casTest.NiveauPriorite != null)
            {
                dropDownPrioritéCasTest.Text = casTest.NiveauPriorite.nomNivPri;
            }
            else
            {
                dropDownPrioritéCasTest.Text = "Aucun";
            }

            if (casTest.TypeTest != null)
            {
                dropDownTypeTestCasTest.Text = casTest.TypeTest.nomTest;
            }
            else
            {
                dropDownTypeTestCasTest.Text = "Aucun";
            }

            if (casTest.dateCreation != null)
            {
                txtDateCreationCasTest.Text = ((DateTime)(casTest.dateCreation)).ToShortDateString();
            }
            if (casTest.dateLivraison != null)
            {
                txtDateLivraisonCasTest.Text = ((DateTime)(casTest.dateLivraison)).ToShortDateString();
            }
            rtxtDescriptionCasTest.Text = casTest.descCasTest;
            rtxtObjectifCastest.Text = casTest.objCasTest;
            rtxtDiversCasTest.Text = casTest.divCasTest;
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            Session["casTest"] = null;
            Response.Redirect("recherche.aspx");
        }
    }
}