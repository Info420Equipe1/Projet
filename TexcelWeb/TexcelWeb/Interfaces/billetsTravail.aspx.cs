using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TexcelWeb.Interfaces
{
    public partial class billetsTravail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dT = new DataTable();
            dT.Columns.AddRange(new DataColumn[6] { new DataColumn("Titre", typeof(string)), new DataColumn("Priorite", typeof(string)), new DataColumn("DateFin", typeof(string)), new DataColumn("TypeTest", typeof(string)), new DataColumn("Duree", typeof(string)), new DataColumn("Projet", typeof(string)) });
            dT.Rows.Add(dT.NewRow());
            dT.Rows[0].SetField("Titre", "No Record Available");
            GridView1.Visible = true;
            GridView1.DataSource = dT;
            GridView1.DataBind();
            GridView1.HeaderRow.Visible = true;
            lblNbrBillet.Text = "yo";
            lblNbrBilletPersonnel.Text = "yo";
        }
    }
}