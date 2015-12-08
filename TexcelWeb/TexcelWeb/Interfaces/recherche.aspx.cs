using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes.Personnel;
using TexcelWeb.Classes;
using System.IO;
using System.Data;
using System.Web.Services;

namespace TexcelWeb
{
    public partial class recherche : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CtrlController.GetCurrentUser() == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Utilisateur currentUser = CtrlController.GetCurrentUser();
                txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
            }
            if (Page.IsPostBack == false)
            {
                Session["modifProjet"] = false;
                ChargerPage();
            }         
        }

        private void ChargerPage()
        {
            Utilisateur currentUser = CtrlController.GetCurrentUser();
            txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
            DateTime date = Convert.ToDateTime(currentUser.dateDernModif);
            txtDerniereConnexion.InnerText = date.ToString("d");
            List<string> filterNames = CtrlFiltreDataSource.GetAllNomFiltre();
            filterNames.Sort();
            foreach (string nom in filterNames)
            {
                ddlFiltre.Items.Add(nom);
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
                    ddlFiltre.Items.Remove("Projet");
                }
                if (!lstDroits.Contains(21) && !lstDroits.Contains(22))
                {
                    boxCasTest.Visible = false;
                    menuCasTest.Visible = false;
                    lienCasTest.Visible = false;
                    ddlFiltre.Items.Remove("CasTest");
                }
                if (!lstDroits.Contains(23) && !lstDroits.Contains(24))
                {
                    boxBilletTravail.Visible = false;
                    menuBilletTravail.Visible = false;
                    lienBilletChefEquipe.Visible = false;
                    lienGestionBillets.Visible = false;
                    ddlFiltre.Items.Remove("BilletTravail");
                }
            }
            AfficherGV(ddlFiltre.Text);
        }

        private void AfficherGV(string _filtre)
        {
            txtChampRecherche.Text = txtChampRecherche.Text.Trim();
            gvRecherche.DataSourceID = CtrlFiltreDataSource.GetDataSourceName(ddlFiltre.Text);
            switch (_filtre)
            {
                case "Projet":              
                    edsProjet.Where = "it.[tagProjet] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "CasTest":
                    edsCasTest.Where = "it.[tagCasTest] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "JeuProjet":
                    edsJeuProjet.Where = "it.[tagJeuProjet] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "ProjetGenre":
                    edsProjetGenre.Where = "it.[tagProjetGenre] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "ProjetTheme":
                    edsProjetTheme.Where = "it.[tagProjetTheme] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "ProjetClassification":
                    edsProjetClassification.Where = "it.[tagProjetClassification] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "ProjetEquipe":
                    edsProjetEquipe.Where = "it.[tagProjetEquipe] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "EmployeEquipe":
                    edsEmployeEquipe.Where = "it.[tagEmployeEquipe] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "EmployeTypeTest":
                    edsEmployeTypeTest.Where = "it.[tagEmployeTypeTest] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "EmployeBilletTravail":
                    edsEmployeBilletTravail.Where = "it.[tagEmployeBilletTravail] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "BilletTravailPriorite":
                    edsBilletTravailPriorite.Where = "it.[tagBilletTravailPriorite] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "BilletTravailStatut":
                    edsBilletTravailStatut.Where = "it.[tagBilletTravailStatut] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "ProjetCasTest":
                    edsProjetCasTest.Where = "it.[tagProjetCasTest] like '%" + txtChampRecherche.Text + "%'";
                    break;
                case "CasTestBilletTravail":
                    edsCasTestBilletTravail.Where = "it.[tagCasTestBilletTravail] like '%" + txtChampRecherche.Text + "%'";
                    break;
            }
            gvRecherche.DataBind();
        }      

        // copier tous les éléments de  la liste qui sont coché
        protected void btn_Copier(object sender, EventArgs e)
        {
            CtrlRecherche.SauvegarderDonnees(gvRecherche);
            CtrlRecherche.CopierElement();
        }
   
        protected void ddlFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            //qqchose avant??
            CtrlRecherche.SauvegarderDonnees(gvRecherche);
        }

        protected void btnRechercher_Click(object sender, EventArgs e)
        {
            AfficherGV(ddlFiltre.Text);
        }

        protected void gvRecherche_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlFiltre.Text)
            {
                case "Projet":
                    Session["modifProjet"] = true;
                    Session["modifCodeProjet"] = gvRecherche.SelectedRow.Cells[0].Text;
                    HttpContext.Current.Response.Redirect("creerProjet.aspx");
                    break;
                case "CasTest":
                    CasTest casTest = CtrlCasTest.GetCasTestByCode(gvRecherche.SelectedRow.Cells[0].Text);
                    Session["casTest"] = casTest;
                    HttpContext.Current.Response.Redirect("creerCasTest.aspx");
                    break;
            }
        }

        protected void gvRecherche_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackEventReference(gvRecherche, "Select$" + e.Row.RowIndex);
                /*TableCell tc = new TableCell();
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                e.Row.Cells.Add(tc);

                LinkButton lnkDetails = new LinkButton();
                lnkDetails.Height = 10;
                lnkDetails.Width = 10;
                lnkDetails.Controls.Add(new Image { ImageUrl = "../img/loupe.png" });
                lnkDetails.Click += new EventHandler(lnkDetails_Click);
                e.Row.Cells[5].Controls.Add(lnkDetails);*/
            }
        }

        protected void gvRecherche_DataBound(object sender, EventArgs e)
        {
            if (gvRecherche.Rows.Count != 0)
            {
                if (gvRecherche.DataSourceID != "")
                {
                    switch (ddlFiltre.SelectedItem.Text)
                    {
                        case "Projet":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Code du Projet";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Nom du Projet";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[2].Controls[0])).Text = "Chef de Projet";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[3].Controls[0])).Text = "Date de Creation";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[4].Controls[0])).Text = "Date de Livraison";
                            foreach (GridViewRow row in gvRecherche.Rows)
                            {
                                if (row.Cells[3].Text != "&nbsp;")
                                {
                                    row.Cells[3].Text = Convert.ToDateTime(row.Cells[3].Text).ToString("yyyy-MM-dd");
                                    row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                                }
                                if (row.Cells[4].Text != "&nbsp;")
                                {
                                    row.Cells[4].Text = Convert.ToDateTime(row.Cells[4].Text).ToString("yyyy-MM-dd");
                                    row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                                }
                            }
                            break;
                        case "CasTest":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Code du CasTest";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Nom du CasTest";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[2].Controls[0])).Text = "Date de Creation";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[3].Controls[0])).Text = "Date de Livraison";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[4].Controls[0])).Text = "Code du Projet";
                            foreach (GridViewRow row in gvRecherche.Rows)
                            {
                                if (row.Cells[2].Text != "&nbsp;")
                                {
                                    row.Cells[2].Text = Convert.ToDateTime(row.Cells[2].Text).ToString("yyyy-MM-dd");
                                    row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                                }
                                if (row.Cells[3].Text != "&nbsp;")
                                {
                                    row.Cells[3].Text = Convert.ToDateTime(row.Cells[3].Text).ToString("yyyy-MM-dd");
                                    row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                                }
                            }
                            break;
                        case "JeuProjet":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom du projet";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Nom du jeu";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[2].Controls[0])).Text = "Version du jeu";
                            break;
                        case "ProjetGenre":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom du projet";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Nom du genre";
                            break;
                        case "ProjetTheme":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom du projet";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Nom du thème";
                            break;
                        case "ProjetClassification":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom du projet";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Code de classification";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[2].Controls[0])).Text = "Nom de la classification";
                            break;
                        case "ProjetEquipe":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom de l'équipe";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Nom du projet";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[2].Controls[0])).Text = "Nom du chef de projet";
                            break;
                        case "EmployeEquipe":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom de l'employé";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Nom de l'équipe";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[2].Controls[0])).Text = "Nom du chef d'équipe";
                            break;
                        case "EmployeTypeTest":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom de l'employé";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Nom du type de test";
                            break;
                        case "EmployeBilletTravail":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom de l'employé";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Titre du billet de travail";
                            break;
                        case "BilletTravailPriorite":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Titre du billet de travail";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Niveau de priorité";
                            break;
                        case "BilletTravailStatut":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Titre du billet de travail";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Statut";
                            break;
                        case "ProjetCasTest":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom du projet";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Nom du cas de test";
                            break;
                        case "CasTestBilletTravail":
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[0].Controls[0])).Text = "Nom du cas de test";
                            ((LinkButton)(gvRecherche.HeaderRow.Cells[1].Controls[0])).Text = "Titre du billet de travail";
                            break;
                    }
                }
            }
            else
            {
                DataTable table = new DataTable();
                table.Columns.Add("Résultat de la recherche");
                table.Rows.Add("Aucune résultat.");
                gvRecherche.DataSource = table;
                gvRecherche.DataSourceID = "";
                gvRecherche.DataBind();
            }
        }
    }
}