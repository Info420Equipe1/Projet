using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;


namespace TexcelWeb
{
    public partial class CreerCasTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargerDropDownList();
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //if (txtNomCasTest.Text == "")
            //{
            //    Response.Write("<script type=\"text/javascript\">alert('hahahahahhaha');</script>");
            //    txtNomCasTest.Text = "sdcscds";
            //    string yyy = txtCodeCasTest.Text;
            //}
        }

        protected void ChargerDropDownList()
        {
            dropDownProjet.Items.Clear();
            dropDownTypeTestCasTest.Items.Clear();

            foreach (cProjet proj in CtrlProjet.GetListProjet())
            {
                dropDownProjet.Items.Add(proj.nomProjet);
            }
            foreach (TypeTest tT in CtrlTypeTest.GetLstTypeTest())
            {
                dropDownTypeTestCasTest.Items.Add(tT.nomTypeTest);
            }
        }
    }
}