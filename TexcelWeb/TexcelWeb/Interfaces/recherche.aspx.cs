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
            if (Page.IsPostBack == false)
            {
                ChargerPage();
            }
            
        }

        private void ChargerPage()
        {      
            AfficherGV(ddlFiltre.Text);
            CtrlRecherche.SauvegarderDonnees(gvRecherche);            
        }

        private void AfficherGV(string _filtre)
        {
            //DataTable data = CtrlProjet.GetListProjet()
            gvRecherche.DataSourceID = "EntityDataSource";
            gvRecherche.DataBind();
            gvRecherche.HeaderRow.Cells[1].Text = "Code du projet";
            gvRecherche.HeaderRow.Cells[3].Text = "Chef de projet";
        }

        protected void ChkBox_CheckedChanged(object sender, EventArgs e)
        {
            // ca va etre un bouton ajouter les checkbox coché pas sur le changement
            CtrlRecherche.SauvegarderDonnees(gvRecherche);           
            CtrlRecherche.VerifierChkBox();
        }
     

        protected void ddlFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlFiltre.SelectedIndex)
            {
                case 0:
                    //caller le bon datasource
                    break;

                case 1:
                    //caller le bon datasource
                    break;

                default:
                    //caller le bon datasource
                    break;
            }
        }
    }
}