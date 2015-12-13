using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Projet;

namespace TexcelWeb.Interfaces
{
    public partial class gestionBillets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilisateur currentUser = CtrlController.GetCurrentUser();
            if (Page.IsPostBack == false)
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
                    CtrlController.SetCurrentUser(currentUser);
                    txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
                }
                ChargerPage();
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

        private void ChargerPage()
        {
            AfficherDdlProjetItem();
        }

        protected void AfficherDdlProjetItem()
        {
            ddlProjet.Items.Clear();           
            CtrlGestionBillet.SaveLstProjetAffiche();        
            // .selectedvalue va etre le code du projet
            ddlProjet.DataTextField = "nomProjet";
            // ddlProjet.DataValueField = "codeProjet";
            ddlProjet.DataSource = CtrlGestionBillet.getLstProj;
            ddlProjet.DataBind();
            // Ajouter une valeur par défaut au cas où il n'y aurait qu'une seule valeur dans le DDL
            ddlProjet.Items.Insert(ddlProjet.Items.Count,"Choisissez un projet");
            ddlProjet.SelectedValue = "Choisissez un projet";
        }

        protected void AfficherDdlEquipeItem()
        {
            ddlEquipe.Items.Clear();
            CtrlGestionBillet.SaveLstEquipeAffiche();
            // .selectedvalue va etre l'id de l'equipe
            ddlEquipe.DataTextField = "nomEquipe";
            // ddlEquipe.DataValueField = "idEquipe";
            ddlEquipe.DataSource = CtrlGestionBillet.getLstEquipe;
            ddlEquipe.DataBind();
            ddlEquipe.Enabled = true;
            // Ajouter une valeur par défaut au cas où il n'y aurait qu'une seule valeur dans le DDL
            ddlEquipe.Items.Insert(ddlEquipe.Items.Count, "Choisissez une équipe");
            ddlEquipe.SelectedValue = "Choisissez une équipe";
        }

        protected void AfficherDdlTesteurItem()
        {
            ddlTesteur.Items.Clear();
            CtrlGestionBillet.SaveLstTesteurAffiche();
            // .selectedvalue va etre le no du testeur
            ddlTesteur.DataTextField = "nomEmploye";
            // ddlTesteur.DataValueField = "noEmploye";
            ddlTesteur.DataSource = CtrlGestionBillet.getLstTesteur;
            ddlTesteur.DataBind();
            ddlTesteur.Enabled = true;

            // Ajouter une valeur par défaut au cas où il n'y aurait qu'une seule valeur dans le DDL
            ddlTesteur.Items.Insert(ddlTesteur.Items.Count, "Choisissez un testeur");
            ddlTesteur.SelectedValue = "Choisissez un testeur";
        }

        //*****************************DROP_DOWN_LIST DU HAUT **********************************************//
        protected void ddlProjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTesteur.Enabled = false;
            // enregistrer le projet qui a été sélectionné dans la classe controle
            if (CtrlGestionBillet.SaveProjetChoisi(ddlProjet.SelectedIndex))
            {
                AfficherDdlEquipeItem();
                // afficher qqchose dans le gridView
            }
            else
            {
                // ca veut  dire que  l'index choisi c'est "Choisissez.."
                // Donc il faut remettre la variable Equipe et TEsteur a null
                CtrlGestionBillet.SaveEquipeChoisi(-1);
                CtrlGestionBillet.SaveTesteurChoisi(-1);
                ddlEquipe.Enabled = false;
            }
            dgvBillets.DataSourceID = "edsBilletsTRavail";
            edsBilletsTravail.Where = "it.[tagBilletTravail] like '%" + ddlProjet.Text + "%'";
            dgvBillets.DataBind();
            if (ddlProjet.Text != "Choisissez un projet")
            {
                AfficherStatistiques(CtrlProjet.GetProjet(ddlProjet.Text));
            }
        }
        

        protected void ddlEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // enregistrer l'équipe qui a été sélectionné dans la classe controle
            if (CtrlGestionBillet.SaveEquipeChoisi(ddlEquipe.SelectedIndex))
            {
                AfficherDdlTesteurItem();
                // afficher qqchose dans le gridView
            }
            else
            {
                // ca veut  dire que  l'index choisi c'est "Choisissez.."
                // Donc il faut remettre la variable Testeur a null
                CtrlGestionBillet.SaveTesteurChoisi(-1);
                ddlTesteur.Enabled = false;
            }
            edsBilletsTravail.Where = "it.[tagBilletTravail] like '%" + ddlEquipe.Text + "%'";
        }

        protected void ddlTesteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CtrlGestionBillet.SaveTesteurChoisi(ddlTesteur.SelectedIndex))
            {
                // afficher quelque chose
            }
            else
            {
                // affiche rien car l'index choisi c'est "Choisissez.."
            }
            edsBilletsTravail.Where = "it.[tagBilletTravail] like '%" + ddlTesteur.Text + "%'";
        }
  
        //*************************************GRIDVIEW EVENT***************************************//
        protected void dgvBillets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (dgvBillets.Rows.Count >= 0)
            {
                foreach (GridViewRow row in dgvBillets.Rows)
                {
                    if (row.Cells[9].Text != "&nbsp;")
                    {
                        row.Cells[9].Text = Convert.ToDateTime(row.Cells[9].Text).ToString("yyyy-MM-dd");
                        row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                        if (Convert.ToInt32(row.Cells[10].Text) < 5)
                        {
                            row.BackColor = System.Drawing.Color.FromArgb(255, 105, 107);
                        }
                        else if (Convert.ToInt32(row.Cells[10].Text) >= 5 && Convert.ToInt32(row.Cells[10].Text) <= 8)
                        {
                            row.BackColor = System.Drawing.Color.Khaki;
                        }
                        else if (Convert.ToInt32(row.Cells[10].Text) > 8 && Convert.ToInt32(row.Cells[10].Text) <= 10)
                        {
                            row.BackColor = System.Drawing.Color.LightGreen;
                        }
                    }               
                }
            } 
        }

        protected void AfficherStatistiques(cProjet _projet)
        {
            lblNbCasTest.Text = CtrlProjet.nbCasTestduProjet(_projet).ToString();
            lblNbBillet.Text = CtrlProjet.nbBilletsduProjet(_projet).ToString();
            lblNbBilletEnCours.Text = CtrlProjet.nbBilletsduProjetparStatut(_projet, "En cours").ToString();
            lblNbBilletTermine.Text = CtrlProjet.nbBilletsduProjetparStatut(_projet, "Terminé").ToString();
            lblTempsTotal.Text = CtrlProjet.tempsEstimeGlobalduProjet(_projet) + " minute(s)";
            lblTempsInvesti.Text = CtrlProjet.tempsInvestiduProjet(_projet) + " minute(s)";
        }
    }
}