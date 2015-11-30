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
            dT.Columns.AddRange(new DataColumn[4] { new DataColumn("File Name", typeof(string)), new DataColumn("Extansion", typeof(string)), new DataColumn("Taille", typeof(string)), new DataColumn("Derniere modification", typeof(string)) });
            dT.Rows.Add(dT.NewRow());
            dT.Rows[0].SetField("File Name", "No Record Available");
            GridView1.Visible = true;
            GridView1.DataSource = dT;
            GridView1.DataBind();
            GridView1.HeaderRow.Visible = true;
        }
    }
}