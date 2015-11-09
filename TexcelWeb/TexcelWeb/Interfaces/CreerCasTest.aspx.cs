using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TexcelWeb
{
    public partial class CreerCasTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (txtNomCasTest.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('hahahahahhaha');</script>");
                txtNomCasTest.Text = "sdcscds";
                string yyy = txtCodeCasTest.Text;
            }
        }
    }
}