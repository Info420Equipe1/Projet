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
            string nomUtilisateur = String.Format("{0}", Request.Form["txtNomUtilisateur"]);
            string motPasse = String.Format("{0}", Request.Form["txtMotPasse"]);
            string mess = CtrlLogin.VerifierLogin(nomUtilisateur, motPasse);
            if (mess.Contains("Connexion réussie"))
            {
                //Connexion Réussi
                this.Form.Dispose();
                Session["modifProjet"] = true;
                Session["modifCodeProjet"] = "GHWT";
                //HttpContext.Current.Response.Redirect("http://deptinfo420/Projet2015/Equipe1/Interfaces/recherche.aspx");
                HttpContext.Current.Response.Redirect("/Interfaces/recherche.aspx");
            }
            else if (mess.Contains("Vous devez changer de mot de passe"))
            {
                Session["utilisateur"] = CtrlUtilisateur.getUtilisateur(String.Format("{0}", Request.Form["txtNomUtilisateur"]));
                this.Form.Dispose();
                Response.Redirect("renouvPassword.aspx");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Connection échoué');</script>");
            }


        }
    }
}