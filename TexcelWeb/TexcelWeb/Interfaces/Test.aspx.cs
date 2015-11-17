using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;

namespace TexcelWeb.Interfaces
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();

            foreach (cProjet proj in CtrlProjet.GetListProjet())
            {
                DropDownList1.Items.Add(proj.nomProjet);
            }

            foreach (CasTest casTest in CtrlCasTest.GetLstCasTest())
            {
                DropDownList2.Items.Add(casTest.nomCasTest);
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CasTest casTest = CtrlCasTest.GetCasTestByNom(String.Format("{0}", Request.Form["DropDownList2"]));
            Session["casTest"] = casTest;
            CreerCasTest ccc = new CreerCasTest();
            
            Response.Redirect("creerCasTest.aspx");
        }
    }
}