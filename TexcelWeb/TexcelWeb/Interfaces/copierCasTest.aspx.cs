using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TexcelWeb.Interfaces
{
	public partial class copierCasTest : System.Web.UI.Page
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
        
        }

        private void AfficherGV(string _filtre)
        {
            switch (_filtre)
            {
                case "Projet":
                    gvCopierCasTest.DataSourceID = "edsProjet";
                    gvCopierCasTest.DataBind();
                    gvCopierCasTest.HeaderRow.Cells[1].Text = "Code du Projet";
                    gvCopierCasTest.HeaderRow.Cells[2].Text = "Nom du Projet";
                    gvCopierCasTest.HeaderRow.Cells[3].Text = "Chef de Projet";
                    gvCopierCasTest.HeaderRow.Cells[4].Text = "Date de Creation";
                    gvCopierCasTest.HeaderRow.Cells[5].Text = "Date de Livraison";
                    break;

                case "CasTest":
                    gvCopierCasTest.DataSourceID = "edsCasTest";
                    gvCopierCasTest.DataBind();
                    gvCopierCasTest.HeaderRow.Cells[1].Text = "Code du CasTest";
                    gvCopierCasTest.HeaderRow.Cells[2].Text = "Nom du CasTest";
                    gvCopierCasTest.HeaderRow.Cells[4].Text = "Date de Creation";
                    gvCopierCasTest.HeaderRow.Cells[5].Text = "Date de Livraison";
                    gvCopierCasTest.HeaderRow.Cells[3].Text = "Code du Projet";
                    break;

                default:
                    break;
            }

        }





        
	}
}