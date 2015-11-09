using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Personnel;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes;
using System.Web.UI.HtmlControls;

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
            string codeProjet = String.Format("{0}", Request.Form["txtCodeProjet"]);
            string nomProjet = String.Format("{0}", Request.Form["txtNomProjet"]);
            string chefProjet = String.Format("{0}", Request.Form["txtChefProjetProjet"]);
            string dateCreationProjet = String.Format("{0}", Request.Form["txtDateCreationProjet"]);
            string dateLivraisonProjet = String.Format("{0}", Request.Form["txtDateLivraisonProjet"]);
            string versionJeuProjet = String.Format("{0}", Request.Form["txtVersionJeuProjet"]);
            string descProjet = String.Format("{0}", Request.Form["rtxtDescriptionProjet"]);
            string objProjet = String.Format("{0}", Request.Form["rtxtObjectifProjet"]);
            string DiversProjet = String.Format("{0}", Request.Form["rtxtDiversProjet"]);

            string message = CtrlProjet.AjouterProjet(codeProjet, nomProjet, chefProjet, dateCreationProjet, dateLivraisonProjet, versionJeuProjet, descProjet, objProjet, DiversProjet);
            
            //List<CasTest> lstCasTestProjet = new List<CasTest>();
            
            //Table dataGridLstCasTest = CtrlController.FindControlRecursive(Page, "dataGridLstCasTest") as Table;
            //Table dataGridLstCasTest = (Table)Page.FindControl("dataGridLstCasTest");
            //DataGrid data = CtrlController.FindControlRecursive(Page, "dataGridLstCasTest") as DataGrid;
            
            //foreach (HtmlTableRow rowItem in dataGridLstCasTest.Rows)
            //{
            //    if (rowItem.Cells[0].InnerText.ToString() != "Code")
            //    {
            //        lstCasTestProjet.Add(CtrlCasTest.GetCasTestByCode(rowItem.Cells[0].InnerText.ToString()));
            //    }
            //}
        }
    }
}