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
            btnEnregistrer.Click += btnEnregistrer_Click;
            //foreach (Employe Emp in CtrlUtilisateur.getLstChefProjet())
            //{
            //    txtChefProjetCasTest.Items.Add(Emp.nomEmploye + " " + Emp.prenomEmploye);
            //}
        }

        void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string codeProjet = String.Format("{0}", Request.Form["txtCodeCasTest"]);
            string nomProjet = String.Format("{0}", Request.Form["txtNomCasTest"]);
            string chefProjet = String.Format("{0}", Request.Form["txtChefProjetCasTest"]);
            string dateCreationProjet = String.Format("{0}", Request.Form["txtDateCreationCasTest"]);
            string dateLivraisonProjet = String.Format("{0}", Request.Form["txtDateLivraisonCasTest"]);
            string versionJeuProjet = String.Format("{0}", Request.Form["txtVersionJeuCasTest"]);
            string descProjet = String.Format("{0}", Request.Form["rtxtDescriptionCasTest"]);
            string objProjet = String.Format("{0}", Request.Form["rtxtObjectifCasTest"]);
            string DiversProjet = String.Format("{0}", Request.Form["rtxtDiversCasTest"]);

            //foreach (DataGridItem dgItem in (this.FindControl("dataGridListeCasTest")))
            //{
                
            //}
        }
    }
}