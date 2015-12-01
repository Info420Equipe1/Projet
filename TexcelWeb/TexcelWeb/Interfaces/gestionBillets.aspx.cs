using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Test;

namespace TexcelWeb.Interfaces
{
    public partial class gestionBillets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dT = new DataTable();
            dT.Columns.AddRange(new DataColumn[7] { 
                new DataColumn("TitreBillet", typeof(string)),
                new DataColumn("Priorité", typeof(DropDownList)),
                new DataColumn("Statut", typeof(DropDownList)),
                new DataColumn("Type de Test", typeof(DropDownList)),
                new DataColumn("Durée", typeof(string)),
                new DataColumn("Testeur", typeof(DropDownList)),
                new DataColumn("CasTest", typeof(string))});
            dT.Rows.Add(dT.NewRow());
            dT.Rows[0].SetField("TitreBillet", "No Record Available");

            dgvBillets.Visible = true;
            dgvBillets.DataSource = dT;
            dgvBillets.DataBind();
            dgvBillets.HeaderRow.Visible = true;
                      

        }

        protected void ddlPriorite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlStatut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTypeTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTesteur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvBillets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //DropDownList ddListPriorite = (DropDownList)e.Row.FindControl("ddlPriorite");
            //DataList dt = dt.,
            //ddListPriorite.DataSource = dt;

        }

    }
}