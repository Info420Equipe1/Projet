using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Personnel;

namespace TexcelWeb.Interfaces
{
    public partial class projetEquipe : System.Web.UI.Page
    {
        static string actualSelectedCodeProjet;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilisateur currentUser = CtrlController.GetCurrentUser();
            if (!IsPostBack)
	        {
                //Premier loading de la page
                Session["modifProjet"] = false;
                if (CtrlController.GetCurrentUser() == null)
                {
                    //Not logged in
                    Response.Redirect("login.aspx");
                }
                else
                {
                    //Formatage Bienvenue, [NomUtilisateur] et la Date
                    txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
                    lsbProjets.DataSource = CtrlProjet.GetListProjetChefProjet(currentUser.Employe.prenomEmploye + " " + currentUser.Employe.nomEmploye);
                    lsbProjets.DataTextField = "nomProjet";
                    lsbProjets.DataBind();
                }
	        }
            
            foreach (Groupe groupe in currentUser.Groupe)
            {
                List<int> lstDroits = CtrlController.GetDroits(groupe);
                if (!lstDroits.Contains(19) && !lstDroits.Contains(20))
                {
                    boxProjet.Visible = false;
                    menuProjet.Visible = false;
                    lienAjouterProjet.Visible = false;
                    lienProjetEquipe.Visible = false;
                }
                else if (groupe.idGroupe == 1)
                {
                    lienProjetEquipe.Visible = false;
                    boxCasTest.Visible = false;
                    menuCasTest.Visible = false;
                    lienCasTest.Visible = false;
                }
                if (!lstDroits.Contains(21) && !lstDroits.Contains(22))
                {
                    boxCasTest.Visible = false;
                    menuCasTest.Visible = false;
                    lienCasTest.Visible = false;
                }
                else if (groupe.idGroupe == 2)
                {
                    lienAjouterProjet.Visible = false;
                }
                if (!lstDroits.Contains(24))
                {
                    boxBilletTravail.Visible = false;
                    menuBilletTravail.Visible = false;
                    lienBilletChefEquipe.Visible = false;
                    lienGestionBillets.Visible = false;
                }
                else if (groupe.idGroupe == 3)
                {
                    boxProjet.Visible = false;
                    menuProjet.Visible = false;
                    lienAjouterProjet.Visible = false;
                    lienProjetEquipe.Visible = false;
                    boxCasTest.Visible = false;
                    menuCasTest.Visible = false;
                    lienCasTest.Visible = false;
                }
            }
        }

        protected void lsbProjets_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomProjet = lsbProjets.SelectedItem.ToString();
            cProjet projet = CtrlProjet.GetProjet(nomProjet);
            List<Equipe> lstEquipe = new List<Equipe>();
            actualSelectedCodeProjet = projet.codeProjet;

            //Vider les champs d'information equipe
            txtNomEquipe.Text = "";
            txtChefEquipe.Text = "";
            txtNbTesteurs.Text = "";
            lsbCasTestEquipe.Items.Clear();

            //Emplissage de la liste des equipes pour un projet
            foreach (Equipe equipe in CtrlEquipe.lstEquipeByCodeProjet(projet.codeProjet))
            {
                lstEquipe.Add(equipe);
            }

            //DataSource de la liste des équipes pour un projet
            lsbEquipes.DataSource = lstEquipe;
            lsbEquipes.DataTextField = "nomEquipe";
            lsbEquipes.DataBind();

            //DataSource de la liste des cas de test du projet
            lsbCasTestProjet.DataSource = projet.CasTest;
            lsbCasTestProjet.DataTextField = "codeCasTest";
            lsbCasTestProjet.DataBind();
        }

        protected void lsbEquipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbEquipes.SelectedIndex != -1)
            {
                string nomEquipe = lsbEquipes.SelectedItem.Text;
                Equipe equipe = CtrlEquipe.getEquipeByNomAndCodeProjet(nomEquipe, actualSelectedCodeProjet);

                //DataSource de la liste des cas de test pour une equipe
                //List<CasTest> lstCasTest = CtrlEquipe.lstCasTestByEquipe(equipe);
                if (equipe.CasTest != null)
                {
                    lsbCasTestEquipe.DataSource = equipe.CasTest;
                    lsbCasTestEquipe.DataTextField = "codeCasTest";
                    lsbCasTestEquipe.DataBind();
                }
                else
                {
                    lsbCasTestEquipe.Items.Clear();
                }

                //Emplissage des information à propos de l'équipe
                txtNomEquipe.Text = equipe.nomEquipe;
                txtChefEquipe.Text = equipe.Employe.prenomEmploye +" "+ equipe.Employe.nomEmploye;
                txtNbTesteurs.Text = equipe.nbTesteur.ToString();
            }
        }

        protected void btnAllRight_Click(object sender, EventArgs e)
        {
            if (lsbEquipes.SelectedIndex != -1)
            {
                foreach (ListItem item in lsbCasTestProjet.Items)
                {
                    if (!lsbCasTestEquipe.Items.Contains(item))
                    {
                        lsbCasTestEquipe.Items.Add(item);
                    }
                }
            }
        }

        protected void btnRight_Click(object sender, EventArgs e)
        {
            if (lsbEquipes.SelectedIndex != -1)
            {
                if (lsbCasTestProjet.SelectedIndex != -1)
                {
                    foreach (ListItem item in lsbCasTestProjet.Items)
                    {
                        if (item.Selected == true)
                        {
                            if (!lsbCasTestEquipe.Items.Contains(item))
                            {
                                lsbCasTestEquipe.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }

        protected void btnLeft_Click(object sender, EventArgs e)
        {
            if (lsbCasTestEquipe.SelectedIndex != -1)
            {
                List<int> lstIndex = new List<int>();
                for (int i = 0; i < lsbCasTestEquipe.Items.Count; i++)
                {
                    if (lsbCasTestEquipe.Items[i].Selected == true)
                    {
                        lstIndex.Add(i);
                    }
                }
                lstIndex.Sort();
                lstIndex.Reverse();
                foreach (int index in lstIndex)
                {
                    lsbCasTestEquipe.Items.RemoveAt(index);
                }
            }
        }

        protected void btnAllLeft_Click(object sender, EventArgs e)
        {
            if (lsbCasTestEquipe.Items.Count != 0)
            {
                lsbCasTestEquipe.Items.Clear();
            }
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (lsbProjets.SelectedIndex != -1)
            {
                if (lsbEquipes.SelectedIndex != -1)
                {
                    string nomEquipe = lsbEquipes.SelectedItem.Text;
                    Equipe equipe = CtrlEquipe.getEquipeByNomAndCodeProjet(nomEquipe, actualSelectedCodeProjet);
                    if (lsbCasTestEquipe.Items.Count != 0)
                    {
                        List<string> lstCasTest = new List<string>();

                        for (int i = 0; i < lsbCasTestEquipe.Items.Count; i++)
                        {
                            lstCasTest.Add(lsbCasTestEquipe.Items[i].Text);
                        }

                        string message = CtrlEquipe.lierEquipeCasTest(equipe, lstCasTest);

                        
                        switch (message)
                        {
                            case "liaisonCasTestReussi":
                                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Liaison réussi!\", \"Liaison d'une équipe à des cas de test avec succès\", \"success\");", true);
                                break;
                            case "liaisonCasTestEchoue":
                                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Oops!\", \"Une erreur est survenue lors de la liaison des cas test à l'équipe.\", \"error\");", true);
                                break;
                            default:
                                break;
                        }
                    }
                    else if(equipe.CasTest.Count != 0)
                    {
                        string message = CtrlEquipe.removeCasTestEquipe(equipe);

                        switch (message)
                        {
                            case "liaisonCasTestNullReussi":
                                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Suppression réussi!\", \"Cas de test supprimés de l'équipe avec succès.\", \"success\");", true);
                                break;
                            case "liaisonCasTestNullEchoue":
                                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Oops!\", \"Une erreur est survenue lors de la suppression des cas test de l'équipe.\", \"error\");", true);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        //Aucun cas de test à ajouter à une equipe qui ne possède aucun cas de test
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Attention!\", \"Veuillez ajouter des cas de test pour l'équipe car l'équipe ne possède aucun cas de test.\", \"warning\");", true);
                    }
                }
                else
                {
                    //Pas d'équipe de selectionné
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Attention!', 'Veuillez selectionner une équipe dans la liste afin de lui lier des cas de test.', 'warning');", true);
                }
            }
            else
            {
                //Pas de projet de selectionné
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Attention!', 'Veuillez selectionner un projet dans la liste afin de choisir une équipe.', 'warning');", true);
            }
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("recherche.aspx");
        }

        protected void chkCasTestNonAssocier_CheckedChanged(object sender, EventArgs e)
        {
            cProjet projet = CtrlProjet.getProjetByCode(actualSelectedCodeProjet);
            List<CasTest> lstCasTest = new List<CasTest>();

            lsbCasTestProjet.Items.Clear();

            if (chkCasTestNonAssocier.Checked)
            {
                //Pour chaque cas test sans equipe, on l'affiche
                foreach (CasTest castest in projet.CasTest)
                {
                    if (castest.Equipe.Count == 0)
                    {
                        lstCasTest.Add(castest);
                    }
                }
                lsbCasTestProjet.DataSource = lstCasTest;
                lsbCasTestProjet.DataTextField = "nomCasTest";
                lsbCasTestProjet.DataBind();
            }
            else
            {
                lsbCasTestProjet.DataSource = projet.CasTest;
                lsbCasTestProjet.DataTextField = "nomCasTest";
                lsbCasTestProjet.DataBind();
            }
            
        }

        
    }
}