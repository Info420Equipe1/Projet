using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Personnel;
using TexcelWeb.Classes;

namespace TexcelWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnConnexion.Click += btnConnexion_Click;
            setFieldLength();
        }

        void btnConnexion_Click(object sender, EventArgs e)
        {
            string nomUtilisateur = String.Format("{0}", Request.Form["txtNomUtilisateur"]);
            string motPasse = String.Format("{0}", Request.Form["txtMotPasse"]);
            string mess = CtrlLogin.VerifierLogin(nomUtilisateur, motPasse);
            switch (mess)
            {
                case "connexionreussie":
                    //Connexion Réussi
                    this.Form.Dispose();
                    Response.Redirect("recherche.aspx");
                    break;

                case "changermotdepasse":
                    Session["utilisateur"] = CtrlUtilisateur.getUtilisateur(String.Format("{0}", Request.Form["txtNomUtilisateur"]));
                    this.Form.Dispose();
                    Response.Redirect("renouvPassword.aspx");
                    break;

                case "motdepasseincorrect":
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Oops!\", \"Le mot de passe ne correspond pas.\", \"error\");", true);
                    break;

                case "testeur":
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Oops!\", \"Vous n'avez pas les droits requis pour accéder à ces données. Contactez votre administrateur.\", \"error\");", true);
                    break;

                case "utilisateurinexistant":
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Oops!\", \"L'utilisateur n'existe pas.\", \"error\");", true);
                    break;

                default:
                    Response.Write("<script type=\"text/javascript\">alert('Error 404, File not found');</script>");
                    break;
            }
        }

        private void setFieldLength()
        {
            int maxLengthNomUtilisateur = CtrlUtilisateur.GetMaxLength<Utilisateur>(user => user.nomUtilisateur);
            int maxLengthMotPasse = CtrlUtilisateur.GetMaxLength<Utilisateur>(user => user.motPasse);
            txtNomUtilisateur.MaxLength = maxLengthNomUtilisateur;
            txtMotPasse.MaxLength = maxLengthMotPasse;
        }
    }
}