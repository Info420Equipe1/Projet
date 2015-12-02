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
        List<cProjet> lstProjetChefEquipeActuel;
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
            lstProjetChefEquipeActuel = CtrlEquipe.lstProjetByChefEquipe(employe.prenomEmploye + " " + employe.nomEmploye);
            foreach (cProjet projet in lstProjetChefEquipeActuel)
            {
                cmbProjet.Items.Add(projet.nomProjet);
            }
        }

        protected void cmbProjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            cProjet projet;
            foreach (cProjet pro in lstProjetChefEquipeActuel)
	        {
		        if (pro.nomProjet == cmbProjet.SelectedItem.Text)
	            {
                    projet = pro;
	            }
	        }
            
            //foreach (Equipe equipe in projet.)
            //{
                
            //}
        }
    }
}