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

        protected void monGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:
                        //...
                        break;

                    case DataControlRowType.DataRow:
                        e.Row.Attributes.Add("onmouseover", "self.MouseOverOldColor=this.style.backgroundColor;this.style.backgroundColor='#C0C0C0'");
                        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=self.MouseOverOldColor");

                        int nbCellules = e.Row.Cells.Count;
                        for (int i = 1; i < nbCellules - 1; i++)
                        {
                            e.Row.Cells[i].Attributes["onclick"] = this.Page.ClientScript.GetPostBackEventReference(this.gvRecherche, "Select$" + e.Row.RowIndex);
                        }
                        break;
                }
            }
            catch
            {
                //...throw
            }
        }


    }
}