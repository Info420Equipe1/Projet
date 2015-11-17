using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
using System.IO;
using System.Data;
using System.Web.Services;

namespace TexcelWeb
{
    public partial class recherche : System.Web.UI.Page
    {    
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargerPage();
        }

        private void ChargerPage()
        {
            ddlFiltre.Items.Clear();
            ddlFiltre.Items.Add("CasTest");
            ddlFiltre.Items.Add("Projet");
            AfficherGV(ddlFiltre.Text);
        }

        private void AfficherGV(string _filtre)
        {
            //DataTable data = CtrlProjet.GetListProjet()
            gvRecherche.DataSourceID = "EntityDataSource";
            gvRecherche.DataBind();
            gvRecherche.HeaderRow.Cells[1].Text = "Code du projet";
            gvRecherche.HeaderRow.Cells[3].Text = "Chef de projet";
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Chk = (CheckBox)sender;
        }
    }
}