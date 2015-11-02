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
    public partial class creerProjet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilisateur currentUser = CtrlController.GetCurrentUser();
            txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
            foreach (Employe Emp in CtrlUtilisateur.getLstChefProjet())
	        {
                txtChefProjetCasTest.Items.Add(Emp.nomEmploye + " " + Emp.prenomEmploye);
	        }
        }
    }
}