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
        }

        void btnConnexion_Click(object sender, EventArgs e)
        {
            if (String.Format("{0}", Request.Form["txtNomUtilisateur"]) != null)
            {
                if (String.Format("{0}", Request.Form["txtMotPasse"]) != null)
                {
                    string nomUtilisateur = String.Format("{0}", Request.Form["txtNomUtilisateur"]);
                    string motPasse = String.Format("{0}", Request.Form["txtMotPasse"]);
                    if (CtrlLogin.VerifierLogin(nomUtilisateur, motPasse).Contains("Connexion réussie!"))
                    {
                        this.Form.Dispose();
                        System.Web.HttpContext.Current.Response.Redirect("/Interfaces/creerProjet.aspx");
                    }
                    else
                    {
                        //Connexion Échouée
                    }
                }
                else
                {
                    //Aucun texte dans le mot de passe
                }
            }
            else
            {
                //Aucun texte dans le nom utilisateur
            }
        }
    }
}