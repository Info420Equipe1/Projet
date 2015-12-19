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
        // S'execute au chargement de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            setFieldLength();
        }

        // S'exécute lorsque l'utilisateur a saisie les deux textBox et appuit sur le bouton enregistrer
        // Fait le changement du mot de passe dans la BD
        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Utilisateur utilisateur = new Utilisateur();
            utilisateur = (Utilisateur)Session["utilisateur"];
            try
            {
                CtrlUtilisateur.ModifMotDePasse(utilisateur, txtMotPasse.Text);
                this.Form.Dispose();
                Response.Redirect("login.aspx");
            }
            catch(Exception)
            {
                Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue');</script>");
            }
        }
        
        // Defini la quantité maximale de charactère autorisé dans les textBox
        private void setFieldLength()
        {
            int maxLengthPassword = CtrlUtilisateur.GetMaxLength<Utilisateur>(user => user.motPasse);
            txtMotPasse.MaxLength = maxLengthPassword;
            txtMotPasse2.MaxLength = maxLengthPassword;
        }
    }
}