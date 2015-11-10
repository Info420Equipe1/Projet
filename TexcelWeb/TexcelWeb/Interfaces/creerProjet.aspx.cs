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

namespace TexcelWeb
{
    public partial class creerProjet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Formatage Bienvenue, [NomUtilisateur] et la Date
            Utilisateur currentUser = CtrlController.GetCurrentUser();
            txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
            DateTime date = Convert.ToDateTime(currentUser.dateDernModif);
            txtDerniereConnexion.InnerText = date.ToString("d");// est-ce bien DateDernModif pour la derniere connexion?

            //Emplissage du DropDownList Chef de Projet
            txtChefProjet.Items.Clear();
            foreach (Employe emp in CtrlEmploye.getLstChefProjet())
            {
                txtChefProjet.Items.Add(emp.prenomEmploye + " " + emp.nomEmploye);
            }

            //Variable qui laisse savoir si on modifie ou on ajoute un projet
            bool modifier = Convert.ToBoolean(Request["modifier"]);
            if (!modifier)
            {
                //Nom du Chef de Projet actuelle par defaut dans le Dropdownlist
                string nomChefProjet = currentUser.Employe.prenomEmploye + " " + currentUser.Employe.nomEmploye;
                ListItem lst = new ListItem();
                lst.Text = nomChefProjet;
                txtChefProjet.SelectedIndex = txtChefProjet.Items.IndexOf(lst);    
                

                //Date de création Aujourd'hui par défaut
                txtDateCreationProjet.Text = Convert.ToString(DateTime.Today.ToString("d"));

                

                //Emplissage du DropDownList Jeux
                txtJeuProjet.Items.Clear();
                foreach (cJeu jeu in CtrlJeu.LstJeu())
                {
                    txtJeuProjet.Items.Add(jeu.nomJeu);
                }
            }
            else
            {
                txtVersionJeuProjet.Enabled = true;

                string codeProjet = Request["codeProjet"];
                cProjet projet = CtrlProjet.getProjetByCode(codeProjet);
            }
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //Collecte de l'information pour le projet
            string codeProjet = String.Format("{0}", Request.Form["txtCodeProjet"]);
            string nomProjet = String.Format("{0}", Request.Form["txtNomProjet"]);
            string chefProjet = String.Format("{0}", Request.Form["txtChefProjet"]);
            string dateCreationProjet = String.Format("{0}", Request.Form["txtDateCreationProjet"]);
            string dateLivraisonProjet = String.Format("{0}", Request.Form["txtDateLivraisonProjet"]);
            string versionJeuProjet = String.Format("{0}", Request.Form["txtVersionJeuProjet"]);
            string descProjet = String.Format("{0}", Request.Form["rtxtDescriptionProjet"]);
            string objProjet = String.Format("{0}", Request.Form["rtxtObjectifProjet"]);
            string DiversProjet = String.Format("{0}", Request.Form["rtxtDiversProjet"]);

            //Ajout du projet dans la Base de Données
            string message = CtrlProjet.AjouterProjet(codeProjet, nomProjet, chefProjet, dateCreationProjet, dateLivraisonProjet, versionJeuProjet, descProjet, objProjet, DiversProjet);
            //
            //Sa fonctionne a merveille





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

 
    }
}