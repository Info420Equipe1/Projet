using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Personnel;

namespace TexcelWeb
{
    public partial class creerBilletChefEquipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CtrlController.GetCurrentUser() == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {   
                    Utilisateur currentUser = CtrlController.GetCurrentUser();
                    txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
                }
                fillDropDownList();
            }
        }
        private void fillDropDownList()
        {
            Employe employe = (CtrlController.GetCurrentUser()).Employe;
            foreach (cProjet projet in CtrlEquipe.lstProjetByChefEquipe(employe.prenomEmploye+" "+employe.nomEmploye))
            {
                cmbProjet.Items.Add(projet.nomProjet);
            }
        }
    }
}