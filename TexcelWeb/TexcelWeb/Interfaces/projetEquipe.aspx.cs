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
            if (!IsPostBack)
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
                    lsbProjets.DataSource = CtrlProjet.GetListProjetChefProjet(currentUser.Employe.prenomEmploye + " " + currentUser.Employe.nomEmploye);
                    lsbProjets.DataTextField = "nomProjet";
                    lsbProjets.DataBind();
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
            lsbCasTestProjet.DataTextField = "nomCasTest";
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
                    lsbCasTestEquipe.DataTextField = "nomCasTest";
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
                for (int i = 0; i < lsbCasTestEquipe.Items.Count; i++)
                {
                    if (lsbCasTestEquipe.Items[i].Selected == true)
                    {
                        lsbCasTestEquipe.Items.RemoveAt(i);
                    }
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

                        //Alert ne saffiche pas.... 
                        Response.Write("<script type=\"text/javascript\">alert('Liaison des cas de test à une équipe avec succès');</script>");
                    }
                    else
                    {
                        CtrlEquipe.removeCasTestEquipe(equipe);

                        //
                        Response.Write("<script type=\"text/javascript\">alert('Cas de test supprimés de l'équipe avec succès');</script>");
                    }
                }
                else
                {
                    //Pas d'équipe de selectionné
                    Response.Write("<script type=\"text/javascript\">alert('Veuillez selectionner une équipe dans la liste');</script>");
                }
            }
            else
            {
                //Pas de projet de selectionné
                Response.Write("<script type=\"text/javascript\">alert('Veuillez selectionner un projet dans la liste');</script>");
            }
        }

        
    }
}