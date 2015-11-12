using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Personnel;

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
                //lsbProjets.DataTextField = "nomProjet";
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

            lsbCasTestProjet.DataSource = projet.CasTest;
            lsbCasTestProjet.DataTextField = "nomCasTest";
            lsbCasTestProjet.DataBind();
            //foreach (CasTest casTest in projet.CasTest)
            //{
            //    lsbCasTestProjet.Items.Add(casTest.nomCasTest);
            //}
        }

        protected void btnAllRight_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lsbCasTestProjet.Items)
            {
                if (!lsbCasTestEquipe.Items.Contains(item))
                {
                    lsbCasTestEquipe.Items.Add(item);
                }
            }
        }

        protected void btnRight_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lsbCasTestProjet.Items)
            {
                if (item.Selected == true)
                {
                    if (!lsbCasTestEquipe.Items.Contains(item))
                    {
                        lsbCasTestEquipe.Items.Add(item);
                    }
                }
            }
        }

        protected void btnLeft_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsbCasTestEquipe.Items.Count; i++)
            {
                if (lsbCasTestEquipe.Items[i].Selected == true)
                {
                    lsbCasTestEquipe.Items.RemoveAt(i);
                }
            }
        }

        protected void btnAllLeft_Click(object sender, EventArgs e)
        {
            lsbCasTestEquipe.Items.Clear();
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string nomEquipe = lsbEquipes.SelectedItem.Text;
            List<string> lstCasTest = new List<string>();
            
            for (int i = 0; i < lsbCasTestEquipe.Items.Count; i++)
            {
                lstCasTest.Add(lsbCasTestEquipe.Items[i].Text);
            }

            //message = CtrlEquipe.lierEquipeCasTest(nomEquipe, lstCasTest);


        }
    }
}