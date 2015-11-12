using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes;

namespace TexcelWeb.Interfaces
{
    public partial class projetEquipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
	        {
		        Utilisateur currentUser = CtrlController.GetCurrentUser();

                lsbProjets.DataSource = CtrlProjet.GetListProjetChefProjet(currentUser.Employe.prenomEmploye + " " + currentUser.Employe.nomEmploye);
                lsbProjets.DataTextField = "nomProjet";
                lsbProjets.DataBind();
	        }
        }

        protected void lsbProjets_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomProjet = lsbProjets.SelectedItem.ToString();
            cProjet projet = CtrlProjet.GetProjet(nomProjet);
            //foreach (Equipe equipe in projet)
            //{
                
            //}

            foreach (CasTest casTest in projet.CasTest)
            {
                //lsbCasTestProjet.Items.Add(casTest.nomCasTest);
            }
        }
    }
}