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
        bool modifierProjet;
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

                    string codeProjet = (string)Session["modifCodeProjet"];
                    cProjet projet = CtrlProjet.getProjetByCode(codeProjet);

                    txtCodeProjet.Text = projet.codeProjet;
                    txtNomProjet.Text = projet.nomProjet;
                    ListItem lst = new ListItem();
                    lst.Text = projet.chefProjet;
                    txtChefProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);
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



                    //Emplissage du gridView pour les cas de test
                    if (projet.CasTest.Count != 0)
                    {
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("CodeCasTest");
                        dt.Columns.Add("NomCasTest");
                        dt.Columns.Add("DateLivraisonCasTest");
                        dt.Columns.Add("PrioriteCasTest");
                        dt.Columns.Add("DifficulteCasTest");
                        foreach (CasTest casTest in projet.CasTest)
	                    {
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < 5; i++)
			                {
			                    switch (i)
                                    {
                                        case 0:
                                            dr.SetField("CodeCasTest", casTest.codeProjet);
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
                            
                        
                        //Savoir sil faut afficher plus d'une page dans le gridview
                        //if (projet.CasTest.Count <=5)
                        //{
                        //    int cpt = 1;
                        //    foreach (CasTest casTest in projet.CasTest)
                        //    {
                        //        for (int i = 0; i < 5; i++)
                        //        {
                        //            switch (i)
                        //            {
                        //                case 0:
                        //                    dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = casTest.codeCasTest;
                        //                    break;
                        //                case 1:
                        //                    dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = casTest.nomCasTest;
                        //                    break;
                        //                case 2:
                        //                    if (casTest.dateLivraison != null)
                        //                    {
                        //                        dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = ((DateTime)casTest.dateLivraison).ToShortDateString();
                        //                    }
                        //                    break;
                        //                case 3:
                        //                    if (casTest.NiveauPriorite != null)
                        //                    {
                        //                        dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = casTest.NiveauPriorite.nomNivPri;
                        //                    }
                        //                    else
                        //                    {
                        //                        dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = "";
                        //                    }
                        //                    break;
                        //                case 4:
                        //                    if (casTest.Difficulte != null)
                        //                    {
                        //                        dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = casTest.Difficulte.nomDiff;
                        //                    }
                        //                    else
                        //                    {
                        //                        dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = "";
                        //                    }
                        //                    break;
                        //                default:
                        //                    break;
                        //            }
                        //        }
                        //        cpt++;
                        //    }
                        //}
                        //else
                        //{
                        //    int nbPage = (int)(projet.CasTest.Count/5);
                        //    CasTest[,] tabPageCasTest = new CasTest[nbPage, 5];
                        //    int cpt = 0;
                        //    for (int i = 0; i < nbPage; i++)
                        //    {
                        //        for (int j = 0; j < 5; j++)
                        //        {
                        //            tabPageCasTest[i, j] = projet.CasTest.ElementAt(cpt);
                        //            cpt++;
                        //        }
                        //    }
                        //    Session["tabPageCasTest"] = tabPageCasTest;

                        //    cpt = 1;
                        //    //Emplissage de la premiere page
                        //    foreach (CasTest casTest in projet.CasTest)
                        //    {
                        //        for (int i = 0; i < 5; i++)
                        //        {
                        //            if (cpt<6)
                        //            {
                        //                switch (i)
                        //                {
                        //                    case 0:
                        //                        dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = casTest.codeCasTest;
                        //                        break;
                        //                    case 1:
                        //                        dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = casTest.nomCasTest;
                        //                        break;
                        //                    case 2:
                        //                        if (casTest.dateLivraison != null)
                        //                        {
                        //                            dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = ((DateTime)casTest.dateLivraison).ToShortDateString();
                        //                        }
                        //                        break;
                        //                    case 3:
                        //                        if (casTest.NiveauPriorite != null)
                        //                        {
                        //                            dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = casTest.NiveauPriorite.nomNivPri;
                        //                        }
                        //                        else
                        //                        {
                        //                            dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = "";
                        //                        }
                        //                        break;
                        //                    case 4:
                        //                        if (casTest.Difficulte != null)
                        //                        {
                        //                            dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = casTest.Difficulte.nomDiff;
                        //                        }
                        //                        else
                        //                        {
                        //                            dataGridLstCasTest.Rows[cpt].Cells[i].InnerText = "";
                        //                        }
                        //                        break;
                        //                    default:
                        //                        break;
                        //                }
                        //            }
                        //        }
                        //        cpt++;
                        //    }
                        //}
                    }
                }
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
                //string alert = "alert('"+message+"');";
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", alert, true);
                Response.Write("<script type=\"text/javascript\">alert('"+message+"');</script>");
            }
            else
            {
                //Modification du Projet
                string message = CtrlProjet.ModifierProjet(codeProjet, nomProjet, chefProjet, dateCreationProjet, dateLivraisonProjet, versionJeuProjet, descProjet, objProjet, DiversProjet);
                Response.Write("<script type=\"text/javascript\">alert('" + message + "');</script>");
            }
            



            ////Rechercher de l'information dans le gridview
            //List<CasTest> lstCasTestProjet = new List<CasTest>();
            
            //Table dataGridLstCasTest = CtrlController.FindControlRecursive(Page, "dataGridLstCasTest") as Table;
            //Table dataGridLstCasTest = (Table)Page.FindControl("dataGridLstCasTest");
            //DataGrid data = CtrlController.FindControlRecursive(Page, "dataGridLstCasTest") as DataGrid;
            
            //foreach (HtmlTableRow rowItem in dataGridLstCasTest.Rows)
            //{
            //    if (rowItem.Cells[0].InnerText.ToString() != "Code")
            //    {
            //        lstCasTestProjet.Add(CtrlCasTest.GetCasTestByCode(rowItem.Cells[0].InnerText.ToString()));
            //    }
            //}
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


        protected void dataGridLstCasTest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataGridLstCasTest.PageIndex = e.NewPageIndex;
        }



 
    }
}