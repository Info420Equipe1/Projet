using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Personnel;

namespace TexcelWeb.Interfaces
{
    public partial class renouvPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            setFieldLength();
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Utilisateur uti = new Utilisateur();
            uti = (Utilisateur)Session["utilisateur"];
            try
            {
                CtrlUtilisateur.ModifMotDePasse(uti, txtMotPasse.Text);
                this.Form.Dispose();
                //CtrlUtilisateur.SetCurrentUser(uti);
                Response.Redirect("login.aspx");
            }
            catch(Exception)
            {
                Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue');</script>");
            }
        }
        private void setFieldLength()
        {
            int maxLengthPassword = CtrlUtilisateur.GetMaxLength<Utilisateur>(user => user.motPasse);
            txtMotPasse.MaxLength = maxLengthPassword;
            txtMotPasse2.MaxLength = maxLengthPassword;
        }
    }
}