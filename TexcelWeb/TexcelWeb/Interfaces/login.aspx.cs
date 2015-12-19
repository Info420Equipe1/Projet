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

        // Effectue la connection, vérifie si elle s'est bien effectuée et retourne un message d'état.
        void btnConnexion_Click(object sender, EventArgs e)
        {
            string nomUtilisateur = String.Format("{0}", Request.Form["txtNomUtilisateur"]);
            string motPasse = String.Format("{0}", Request.Form["txtMotPasse"]);
            string message = CtrlLogin.VerifierLogin(nomUtilisateur, motPasse);
            switch (message)
            {
                case "connexionreussie":
                    // Connexion réussie.
                    this.Form.Dispose();
                    Response.Redirect("recherche.aspx");
                    break;

                case "changermotdepasse":
                    // Le mot de passe doit être renouvelé.
                    Session["utilisateur"] = CtrlUtilisateur.getUtilisateur(String.Format("{0}", Request.Form["txtNomUtilisateur"]));
                    this.Form.Dispose();
                    Response.Redirect("renouvPassword.aspx");
                    break;

                case "motdepasseincorrect":
                    // Le mot de passe est incorrect.
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Oops!\", \"Le mot de passe ne correspond pas.\", \"error\");", true);
                    break;

                case "testeur":
                    // Redirige vers le formulaire attitré au testeur.
                    this.Form.Dispose();
                    Response.Redirect("billetsTravail.aspx");
                    break;

                case "utilisateurinexistant":
                    // L'utilisateur n'existe pas.
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Oops!\", \"L'utilisateur n'existe pas.\", \"error\");", true);
                    break;

                default:
                    // Si le code se rend là : ??????????????????????????????????????????????
                    Response.Write("<script type=\"text/javascript\">alert('Une erreur inconnue est survenue.');</script>");
                    break;
            }
        }

        // Initialise la longueur des champs à la création du formulaire.
        private void setFieldLength()
        {
            int maxLengthNomUtilisateur = CtrlUtilisateur.GetMaxLength<Utilisateur>(user => user.nomUtilisateur);
            int maxLengthMotPasse = CtrlUtilisateur.GetMaxLength<Utilisateur>(user => user.motPasse);
            txtNomUtilisateur.MaxLength = maxLengthNomUtilisateur;
            txtMotPasse.MaxLength = maxLengthMotPasse;
        }
    }
}