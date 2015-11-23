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
<<<<<<< HEAD
        bool modif;
        CasTest casTest;
      
        protected void Page_Load(object sender, EventArgs e)
        {
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

            modif = false;
=======
        static bool modif;

        protected void Page_Load(object sender, EventArgs e)
        {
>>>>>>> origin/sprint3
            if (!Page.IsPostBack)
            {
                CasTest casTest;
                //Premier loading de la page
                if (CtrlController.GetCurrentUser() == null)
                {
<<<<<<< HEAD
                    casTest = CtrlCasTest.GetCasTestByCode(codeCasTest);
                    Session["casTest"] = casTest;
                    modif = true;
                }
            }
            
            ChargerDropDownList();
            btnEnregistrer.Text = "Enregistrer";
            txtDateCreationCasTest.Text = Convert.ToString(DateTime.Today.ToString("d"));

            //Mode modifier
            if (Session["casTest"] != null)
            {
                btnEnregistrer.Text = "Modifier";
                modif = true;
                casTest = (CasTest)Session["casTest"];
                txtNomCasTest.Text = casTest.nomCasTest;
                txtCodeCasTest.Text = casTest.codeCasTest;
                dropDownProjet.Text = casTest.cProjet.nomProjet;
                try
                {
                    dropDownDifficulteCasTest.Text = casTest.Difficulte.nomDiff;
                    dropDownPrioritéCasTest.Text = casTest.NiveauPriorite.nomNivPri;
                    dropDownTypeTestCasTest.Text = casTest.TypeTest.nomTest;
                }
                catch(Exception)
                { }
=======
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


>>>>>>> origin/sprint3

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

                    RemplirChamps(casTest);

                    //Si ya pas de dossier, création d'un dossier
                    string path = HttpContext.Current.Server.MapPath(@"~/CasDeTest/" + casTest.codeCasTest);
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string[] filePaths = Directory.GetFiles(Server.MapPath(@"~/CasDeTest/" + casTest.codeCasTest));

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
                else
                {
                    modif = false;
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
                    htmlGC.Attributes.Add("href", "/Interfaces/creerCasTest.aspx?index=" + i);
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
            if (!modif)
            {
                if (CtrlCasTest.Ajouter(txtCodeCasTest.Text, txtNomCasTest.Text, CtrlProjet.GetProjet(String.Format("{0}", Request.Form["DropDownProjet"])), CtrlDifficulte.GetDiff(String.Format("{0}", Request.Form["dropDownDifficulteCasTest"])), CtrlNivPriorite.GetNivPrio(String.Format("{0}", Request.Form["dropDownPrioritéCasTest"])), Convert.ToDateTime(txtDateCreationCasTest.Text), Convert.ToDateTime(txtDateLivraisonCasTest.Text), CtrlTypeTest.GetTypeTest(String.Format("{0}", Request.Form["dropDownTypeTestCasTest"])), rtxtDescriptionCasTest.Text))
                {
                    Response.Write("<script type=\"text/javascript\">alert('Cas de test créé');</script>");
                    ViderChamps();
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue');</script>");
                }
            }
            else
            {
<<<<<<< HEAD
                if (CtrlCasTest.Modifier(txtCodeCasTest.Text, txtNomCasTest.Text, CtrlProjet.GetProjet(String.Format("{0}", Request.Form["DropDownProjet"])), CtrlDifficulte.GetDiff(String.Format("{0}", Request.Form["dropDownDifficulteCasTest"])), CtrlNivPriorite.GetNivPrio(String.Format("{0}", Request.Form["dropDownPrioritéCasTest"])), Convert.ToDateTime(txtDateCreationCasTest.Text), Convert.ToDateTime(txtDateLivraisonCasTest.Text), CtrlTypeTest.GetTypeTest(String.Format("{0}", Request.Form["dropDownTypeTestCasTest"])), rtxtDescriptionCasTest.Text, casTest))
=======
                if (CtrlCasTest.Modifier(txtNomCasTest.Text, proj, diff, nivPri, Convert.ToDateTime(txtDateCreationCasTest.Text), txtDateLivraisonCasTest.Text, typTest, rtxtDescriptionCasTest.Text, casTest))
>>>>>>> origin/sprint3
                {
                    Response.Write("<script type=\"text/javascript\">alert('Cas de test modifié');</script>");
                    Session["casTest"] = null;
                    RemplirChamps(casTest);
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue');</script>");
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
            dropDownDifficulteCasTest.Items.Clear();
            dropDownPrioritéCasTest.Items.Clear();

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

            CtrlCasTest.CopierCasTestEnCours(txtCodeCasTest.Text,txtNomCasTest.Text,CtrlProjet.getProjetByCode(dropDownProjet.SelectedValue),
                CtrlDifficulte.GetDiff(dropDownDifficulteCasTest.SelectedValue),CtrlNivPriorite.GetNivPrio(dropDownPrioritéCasTest.SelectedValue),
                Convert.ToDateTime(txtDateCreationCasTest.Text),Convert.ToDateTime(dt),CtrlTypeTest.GetTypeTest(dropDownTypeTestCasTest.SelectedValue),
                rtxtDescriptionCasTest.Text);    
                        
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('copierCasTest.aspx?Param=" + Param + "');", true);
           
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            casTest = CtrlCasTest.GetCasTestByNom(txtNomCasTest.Text);
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~/CasDeTest/" + casTest.codeCasTest + "/") + fileName);
            Response.Redirect(Request.Url.AbsoluteUri);

        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            casTest = CtrlCasTest.GetCasTestByNom(txtNomCasTest.Text);
            string filePath = Request.MapPath(@"~/CasDeTest/" + casTest.codeCasTest + "/" + (sender as LinkButton).CommandArgument);
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            casTest = CtrlCasTest.GetCasTestByNom(txtNomCasTest.Text);
            string filePath = Request.MapPath(@"~/CasDeTest/" + casTest.codeCasTest + "/" + (sender as LinkButton).CommandArgument);
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

<<<<<<< HEAD
       
=======
        public void ViderChamps()
        {
            txtCodeCasTest.Text = "";
            txtNomCasTest.Text = "";
            dropDownProjet.Text = "Aucun";
            dropDownDifficulteCasTest.Text = "Aucun";
            dropDownPrioritéCasTest.Text = "Aucun";
            txtDateCreationCasTest.Text = Convert.ToString(DateTime.Today.ToString("d"));
            txtDateLivraisonCasTest.Text = "";
            dropDownTypeTestCasTest.Text = "Aucun";
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
        }
>>>>>>> origin/sprint3
    }
}