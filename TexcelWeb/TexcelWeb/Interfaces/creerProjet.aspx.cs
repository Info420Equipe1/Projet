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

namespace TexcelWeb
{
    public partial class creerProjetCopier : System.Web.UI.Page
    {
        int indexTableCasTest;
        static bool modifierProjet;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //Premier loading de la page
                //txtVersionJeuProjet.Enabled = false;
                //Formatage Bienvenue, [NomUtilisateur] et la Date
                Utilisateur currentUser = CtrlController.GetCurrentUser();
                txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
                DateTime date = Convert.ToDateTime(currentUser.dateDernModif);
                txtDerniereConnexion.InnerText = date.ToString("d");

                //DataGrid

                //Emplissage du DropDownList Chef de Projet
                txtChefProjet.Items.Clear();
                foreach (Employe emp in CtrlEmploye.getLstChefProjet())
                {
                    txtChefProjet.Items.Add(emp.prenomEmploye + " " + emp.nomEmploye);
                }

                //Emplissage du DropDownList Jeux
                txtJeuProjet.Items.Clear();
                foreach (cJeu jeu in CtrlJeu.LstJeu())
                {
                    txtJeuProjet.Items.Add(jeu.nomJeu);
                }

                //Variable qui laisse savoir si on modifie ou on ajoute un projet
                bool modifier = Convert.ToBoolean(Session["modifProjet"]);
                if (!modifier)
                {
                    btnEnregistrer.Text = "Enregistrer";
                    modifierProjet = false;
                    //Nom du Chef de Projet actuelle par defaut dans le Dropdownlist
                    string nomChefProjet = currentUser.Employe.prenomEmploye + " " + currentUser.Employe.nomEmploye;
                    ListItem lst = new ListItem();
                    lst.Text = nomChefProjet;
                    txtChefProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);


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
                    txtCodeProjet.Text = projet.codeProjet;
                    txtNomProjet.Text = projet.nomProjet;

                    ListItem lst = new ListItem();
                    if (projet.chefProjet != null)
                    {
                        lst.Text = projet.chefProjet;
                        txtChefProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);
                    }
                    else
                    {
                        txtChefProjet.ClearSelection();
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
                        txtJeuProjet.ClearSelection();
                    }
                    
                    rtxtDescriptionProjet.Text = projet.descProjet;
                    rtxtObjectifProjet.Text = projet.objProjet;
                    rtxtDiversProjet.Text = projet.divProjet;


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
            }
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
            int cpt = 0;
            foreach (CasTest casTest in lstCasTest)
            {
                cpt++;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0:
                            dr.SetField("CodeCasTest", casTest.codeCasTest);
                            break;
                        case 1:
                            dr.SetField("NomCasTest", casTest.nomCasTest);
                            break;
                        case 2:
                            if (casTest.dateLivraison != null)
                            {
                                dr.SetField("DateLivraisonCasTest", ((DateTime)casTest.dateLivraison).ToShortDateString());
                            }
                            break;
                        case 3:
                            if (casTest.NiveauPriorite != null)
                            {
                                dr.SetField("PrioriteCasTest", casTest.NiveauPriorite.nomNivPri);
                            }
                            else
                            {
                                dr.SetField("PrioriteCasTest", "");
                            }
                            break;
                        case 4:
                            if (casTest.Difficulte != null)
                            {
                                dr.SetField("DifficulteCasTest", casTest.Difficulte.nomDiff);
                            }
                            else
                            {
                                dr.SetField("DifficulteCasTest", "");
                            }
                            break;
                        
                        default:
                            break;
                    }
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
            
            if (!modifierProjet)
            {
                //Ajout du projet dans la Base de Données
                string message = CtrlProjet.AjouterProjet(codeProjet, nomProjet, chefProjet, dateCreationProjet, dateLivraisonProjet, versionJeuProjet, descProjet, objProjet, DiversProjet);
                Response.Write("<script type=\"text/javascript\">alert('"+message+"');</script>");
            }
            else
            {
                //Modification du Projet
                string message = CtrlProjet.ModifierProjet(codeProjet, nomProjet, chefProjet, dateCreationProjet, dateLivraisonProjet, versionJeuProjet, descProjet, objProjet, DiversProjet);
                Response.Write("<script type=\"text/javascript\">alert('" + message + "');</script>");
            }
        }

        protected void txtJeuProjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Active textbox Version de Jeu lorsqu'un Jeu est sélectionné
            if (txtJeuProjet.SelectedIndex != -1)
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
                txtVersionJeuProjet.SelectedIndex = -1;
                txtVersionJeuProjet.Enabled = false;
            }
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {

        }




 
    }
}