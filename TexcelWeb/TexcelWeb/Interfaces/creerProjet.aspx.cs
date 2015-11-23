using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Personnel;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes.Jeu;
using TexcelWeb.Classes;
using System.Web.UI.HtmlControls;
using TexcelWeb.Classes.Projet;
using System.Data;
using System.Data.Entity.Core.Objects.DataClasses;

namespace TexcelWeb
{
    public partial class creerProjet : System.Web.UI.Page
    {
        int indexTableCasTest;
        static bool modifierProjet;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //Longueur des champs
                setFieldLength();
                string nomChefProjet = "";

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
                    nomChefProjet = currentUser.Employe.prenomEmploye + " " + currentUser.Employe.nomEmploye;
                }

                //Emplissage des DropDownList
                fillDropDownBox();
                

                //Variable qui laisse savoir si on modifie ou on ajoute un projet
                bool modifier = Convert.ToBoolean(Session["modifProjet"]);
                if (!modifier)
                {
                    ListItem lst;
                    btnEnregistrer.Text = "Enregistrer";
                    modifierProjet = false;

                    //Nom du Chef de Projet actuelle par defaut dans le Dropdownlist
                    lst = new ListItem();
                    lst.Text = nomChefProjet;
                    if (txtChefProjet.Items.Contains(lst))
                    {
                        txtChefProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);
                    }
                    else
                    {
                        lst.Text = "Aucun";
                        txtChefProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);
                    }
                    //Date de création Aujourd'hui par défaut
                    txtDateCreationProjet.Text = Convert.ToString(DateTime.Today.ToString("d"));
                }
                else
                {
                    
                    //Setup de la page pour la modification
                    modifierProjet = true;
                    txtVersionJeuProjet.Enabled = true;
                    dataGridLstCasTest.Visible = true;
                    btnEnregistrer.Text = "Modifier";

                    string codeProjet = (string)Session["modifCodeProjet"];
                    cProjet projet = CtrlProjet.getProjetByCode(codeProjet);

                    //Emplissage des champs avec le projet
                    fillFieldsWithProjet(projet);

                    //Emplissage du GridView pour les cas de test
                    fillDataGridViewCasTest(projet);


                    
                }
            }
        }
        private void fillDataGridViewCasTest(cProjet projet)
        {
            if (projet.CasTest.Count != 0)
            {
                //Nombre de page pour la table des cas de tests
                double page = (double)projet.CasTest.Count / 5;
                int nbPage = Convert.ToInt16(Math.Ceiling(page));

                //Savoir sil faut afficher plus d'une page dans la table
                if (nbPage < 2)
                {
                    dataGridPagination.Visible = false;
                    fillTableCasTest(0, projet.CasTest.ToList(), 1);
                }
                else
                {
                    //Plus de 5 cas de test donc plusieur page de cas test
                    //Index pour la liste des cas test
                    indexTableCasTest = Convert.ToInt16(Request.QueryString["index"]);

                    //Pagination visible
                    dataGridPagination.Visible = true;

                    //Emplissage de la table
                    fillTableCasTest(indexTableCasTest, projet.CasTest.ToList(), nbPage);
                }
            }
        }
        private void fillFieldsWithProjet(cProjet projet)
        {
            txtCodeProjet.Text = projet.codeProjet;
            txtNomProjet.Text = projet.nomProjet;

            ListItem lst = new ListItem();
            if (projet.chefProjet != null)
            {
                Employe chefProjet = CtrlEmploye.getEmployeById(projet.chefProjet);
                lst.Text = chefProjet.prenomEmploye + " " + chefProjet.nomEmploye;
                txtChefProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);
            }
            else
            {
                lst = new ListItem();
                lst.Text = "Aucun";
                txtChefProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);
            }

            if (projet.dateCreation != null)
            {
                txtDateCreationProjet.Text = ((DateTime)projet.dateCreation).ToShortDateString();
            }
            if (projet.dateLivraison != null)
            {
                txtDateLivraisonProjet.Text = ((DateTime)projet.dateLivraison).ToShortDateString();
            }

            if (projet.VersionJeu != null)
            {
                lst = new ListItem();
                lst.Text = projet.VersionJeu.cJeu.nomJeu;
                txtJeuProjet.SelectedIndex = txtJeuProjet.Items.IndexOf(lst);

                
                lst = new ListItem();
                lst.Text = projet.VersionJeu.nomVersionJeu;
                txtVersionJeuProjet.Items.Add(lst);
                txtVersionJeuProjet.SelectedIndex = txtVersionJeuProjet.Items.IndexOf(lst);
            }
            else
            {
                lst = new ListItem();
                lst.Text = "Aucun";
                txtJeuProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);
            }

            rtxtDescriptionProjet.Text = projet.descProjet;
            rtxtObjectifProjet.Text = projet.objProjet;
            rtxtDiversProjet.Text = projet.divProjet;
        }
        private void fillDropDownBox()
        {
            ListItem lst;
            //Emplissage du DropDownList Chef de Projet
            txtChefProjet.Items.Clear();
            foreach (Employe emp in CtrlEmploye.getLstChefProjet())
            {
                txtChefProjet.Items.Add(emp.prenomEmploye + " " + emp.nomEmploye);
            }
            lst = new ListItem();
            lst.Text = "Aucun";
            txtChefProjet.Items.Add(lst);
            txtChefProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);

            //Emplissage du DropDownList Jeux
            txtJeuProjet.Items.Clear();
            foreach (cJeu jeu in CtrlJeu.LstJeu())
            {
                txtJeuProjet.Items.Add(jeu.nomJeu);
            }
            lst = new ListItem();
            lst.Text = "Aucun";
            txtJeuProjet.Items.Add(lst);
            txtJeuProjet.SelectedIndex = txtJeuProjet.Items.IndexOf(lst);
            lst = new ListItem();
            lst.Text = "Aucun";
            txtVersionJeuProjet.Items.Add(lst);
            txtVersionJeuProjet.SelectedIndex = txtVersionJeuProjet.Items.IndexOf(lst);
        }
        private void fillTableCasTest(int index, List<CasTest> lstCasTest, int nbPage)
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
                    htmlGC.Attributes.Add("href", "/Interfaces/creerProjet.aspx?index=" + i);
                    htmlGC.InnerText = i.ToString();
                    dataGridPagination.Controls.Add(htmlGC);
                }
            }

            List<CasTest> lstCasTestAfficher = new List<CasTest>();
            //Emplissage des cas de test dans le gridView
            for (int i = nuCasTest; i < nuCasTest + 5; i++)
            {
                if (i < lstCasTest.Count)
                {
                    lstCasTestAfficher.Add(lstCasTest[i]);
                }
                else
                {
                    break;
                }
            }
            ajoutDonnesDataGrid(lstCasTestAfficher);
        }
        private void ajoutDonnesDataGrid(List<CasTest> lstCasTest)
        {
            //Emplissage du gridView pour les cas de test
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("CodeCasTest");
            dt.Columns.Add("NomCasTest");
            dt.Columns.Add("DateLivraisonCasTest");
            dt.Columns.Add("PrioriteCasTest");
            dt.Columns.Add("DifficulteCasTest");
            dt.Columns.Add("OptionsCasTest");

            foreach (CasTest casTest in lstCasTest)
            {
                DataRow dr = dt.NewRow();

                dr.SetField("CodeCasTest", casTest.codeCasTest);
                dr.SetField("NomCasTest", casTest.nomCasTest);
                if (casTest.dateLivraison != null)
                {
                    dr.SetField("DateLivraisonCasTest", ((DateTime)casTest.dateLivraison).ToShortDateString());
                }
                if (casTest.NiveauPriorite != null)
                {
                    dr.SetField("PrioriteCasTest", casTest.NiveauPriorite.nomNivPri);
                }
                else
                {
                    dr.SetField("PrioriteCasTest", "");
                }
                if (casTest.Difficulte != null)
                {
                    dr.SetField("DifficulteCasTest", casTest.Difficulte.nomDiff);
                }
                else
                {
                    dr.SetField("DifficulteCasTest", "");
                }
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
            dataGridLstCasTest.DataSource = ds;
            dataGridLstCasTest.DataBind();
            
            foreach (GridViewRow gvr in dataGridLstCasTest.Rows)
	        {
                HtmlAnchor hgc = (HtmlAnchor)gvr.Cells[5].FindControl("btnModifierGridView");
                hgc.Attributes["href"] = "/Interfaces/creerCasTest.aspx?codeCasTest="+gvr.Cells[0].Text;
	        }
        }
        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //Collecte de l'information pour un projet
            string codeProjet = String.Format("{0}", Request.Form["txtCodeProjet"]);
            string nomProjet = String.Format("{0}", Request.Form["txtNomProjet"]);
            string chefProjet = String.Format("{0}", Request.Form["txtChefProjet"]);
            string dateCreationProjet = String.Format("{0}", Request.Form["txtDateCreationProjet"]);
            string dateLivraisonProjet = String.Format("{0}", Request.Form["txtDateLivraisonProjet"]);
            string versionJeuProjet = String.Format("{0}", Request.Form["txtVersionJeuProjet"]);
            string descProjet = String.Format("{0}", Request.Form["rtxtDescriptionProjet"]);
            string objProjet = String.Format("{0}", Request.Form["rtxtObjectifProjet"]);
            string DiversProjet = String.Format("{0}", Request.Form["rtxtDiversProjet"]);

            int idChefProjet;
            if (chefProjet != "Aucun")
            {
                 idChefProjet = CtrlEmploye.getIdEmploye(chefProjet);
            }
            else
            {
                idChefProjet = -1;
            }
            
            
            if (!modifierProjet)
            {
                //Ajout du projet dans la Base de Données
                string message = CtrlProjet.AjouterProjet(codeProjet, nomProjet, idChefProjet, dateCreationProjet, dateLivraisonProjet, versionJeuProjet, descProjet, objProjet, DiversProjet);
                switch (message)
                {
                    case "projetajoute":
                        Response.Write("<script type=\"text/javascript\">alert('Le projet a été ajouté avec succès.');</script>");
                        Session["modifProjet"] = false;
                        break;
                    case "erreur":
                        Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue lors de la création du projet.');</script>");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //Modification du Projet
                string message = CtrlProjet.ModifierProjet(codeProjet, nomProjet, idChefProjet, dateCreationProjet, dateLivraisonProjet, versionJeuProjet, descProjet, objProjet, DiversProjet);
                switch (message)
                {
                    case "projetmodifier":
                        Response.Write("<script type=\"text/javascript\">alert('Le projet a été modifié avec succès.');</script>");
                        Session["modifProjet"] = false;
                        break;
                    case "erreur":
                        Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue lors de la modification du projet.');</script>");
                        break;
                    default:
                        break;
                }
            }
        }

        protected void txtJeuProjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Active textbox Version de Jeu lorsqu'un Jeu est sélectionné
            if (txtJeuProjet.SelectedIndex != -1)
            {
                if (txtJeuProjet.SelectedItem.Text != "Aucun")
                {
                    cJeu jeu = CtrlJeu.GetJeu(txtJeuProjet.SelectedItem.Text);
                    txtVersionJeuProjet.Enabled = true;
                    txtVersionJeuProjet.Items.Clear();
                    foreach (VersionJeu versionJeu in jeu.VersionJeu)
                    {
                        txtVersionJeuProjet.Items.Add(versionJeu.nomVersionJeu);
                    }
                }
                else
                {
                    ListItem lst = new ListItem();
                    lst.Text = "Aucun";
                    txtVersionJeuProjet.SelectedIndex = txtVersionJeuProjet.Items.IndexOf(lst);
                    txtVersionJeuProjet.Enabled = false;
                }
            }
        }

        private void setFieldLength()
        {
            int maxLengthCodeProjet = CtrlProjet.GetMaxLength<cProjet>(cProjet => cProjet.codeProjet);
            int maxLengthNomProjet = CtrlProjet.GetMaxLength<cProjet>(cProjet => cProjet.nomProjet);
            txtCodeProjet.MaxLength = maxLengthCodeProjet;
            txtNomProjet.MaxLength = maxLengthNomProjet;
        }
        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Interfaces/recherche.aspx");
        }

        protected void btnCopier_Click(object sender, EventArgs e)
        {
            Response.Redirect("copierCasTest.aspx?Parameter=" + Server.UrlEncode("Projet"));
        }




 
    }
}