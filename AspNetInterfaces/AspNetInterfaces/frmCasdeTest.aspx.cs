using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetInterfaces
{
    public partial class frmCasdeTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string[]> stringList = new List<string[]>();
            string[] lstString = new string[5];
            lstString[0] = "Documentation du Cas de Test";
            lstString[1] = "txt";
            lstString[2] = "180mb";
            lstString[3] = "Marcel Leblond";
            lstString[4] = "2015/10/27";
            stringList.Add(lstString);

            lstString = new string[5];
            lstString[0] = "Presentation";
            lstString[1] = "pptx";
            lstString[2] = "200mb";
            lstString[3] = "Tougo Tremblay";
            lstString[4] = "2015/10/26";
            stringList.Add(lstString);

            lstString = new string[5];
            lstString[0] = "Liste Operation";
            lstString[1] = "txt";
            lstString[2] = "200mb";
            lstString[3] = "Benoit Simard";
            lstString[4] = "2015/10/26";
            stringList.Add(lstString);

            lstString = new string[5];
            lstString[0] = "ReadME";
            lstString[1] = "txt";
            lstString[2] = "80mb";
            lstString[3] = "Louis-Alexandre Munger";
            lstString[4] = "2015/10/26";
            stringList.Add(lstString);

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("Fichier", System.Type.GetType("System.String"));
            //dt.Columns[0]. //ajuster la largeur ...... putain
            dt.Columns.Add("Type", System.Type.GetType("System.String"));
            dt.Columns.Add("Taille", System.Type.GetType("System.String"));
            dt.Columns.Add("Auteur", System.Type.GetType("System.String"));
            dt.Columns.Add("Dernière Modification", System.Type.GetType("System.String"));

            foreach (string[] s in stringList)
            {
                //foreach (string str in s)
                //{
                    dr = dt.NewRow();
                    dr["Fichier"] = s[0];
                    dr["Type"] = s[1];
                    dr["Taille"] = s[2];
                    dr["Auteur"] = s[3];
                    dr["Dernière Modification"] = s[4];
                    dt.Rows.Add(dr);
                //}
            }

            dt.AcceptChanges();
            DataGridBilletTravail.DataSource = dt;
            DataGridBilletTravail.DataBind();
        }
    }
}