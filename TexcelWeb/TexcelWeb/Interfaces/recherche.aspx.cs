using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
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
                ChargerPage();
            }         
        }

        private void ChargerPage()
        {
            Utilisateur currentUser = CtrlController.GetCurrentUser();
            txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
            DateTime date = Convert.ToDateTime(currentUser.dateDernModif);
            txtDerniereConnexion.InnerText = date.ToString("d");
            
            AfficherGV(ddlFiltre.Text);
            CtrlRecherche.SauvegarderDonnees(gvRecherche);            
        }

        private void AfficherGV(string _filtre)
        {
            switch (_filtre)
            {
                case "Projet":
                    gvRecherche.DataSourceID = "edsProjet";
                    edsProjet.Where = "it.[tagProjet] like '%" + txtChampRecherche.Text + "%'";
                    gvRecherche.DataBind();                
                    gvRecherche.HeaderRow.Cells[0].Text = "Code du Projet";
                    gvRecherche.HeaderRow.Cells[1].Text = "Nom du Projet";
                    gvRecherche.HeaderRow.Cells[2].Text = "Chef de Projet";
                    gvRecherche.HeaderRow.Cells[3].Text = "Date de Creation";
                    gvRecherche.HeaderRow.Cells[4].Text = "Date de Livraison";
                    break;              
                case "CasTest":
                    gvRecherche.DataSourceID = "edsCasTest";
                    edsProjet.Where = "it.[tagCasTest] like '%" + txtChampRecherche.Text + "%'";
                    gvRecherche.DataBind();
                    gvRecherche.HeaderRow.Cells[0].Text = "Code du CasTest";
                    gvRecherche.HeaderRow.Cells[1].Text = "Nom du CasTest";
                    gvRecherche.HeaderRow.Cells[2].Text = "Date de Creation";
                    gvRecherche.HeaderRow.Cells[3].Text = "Date de Livraison";
                    gvRecherche.HeaderRow.Cells[4].Text = "Code du Projet";
                    break;
                default:
                    break;
            }    
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
                    HttpContext.Current.Response.Redirect("/Interfaces/creerProjet.aspx");
                    break;
                case "CasTest":
                    CasTest casTest = CtrlCasTest.GetCasTestByCode(gvRecherche.SelectedRow.Cells[0].Text);
                    Session["casTest"] = casTest;
                    HttpContext.Current.Response.Redirect("/Interfaces/creerCasTest.aspx");
                    break;
            }
        }

        protected void gvRecherche_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(gvRecherche, "Select$" + e.Row.RowIndex);
            }
        }
    }
}