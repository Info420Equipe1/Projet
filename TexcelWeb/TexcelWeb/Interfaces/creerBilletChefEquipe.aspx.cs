using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Personnel;
using TexcelWeb.Classes.Projet;

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
                showEmptyDataGrid();
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
            cProjet projet = CtrlProjet.GetProjet(cmbProjet.Text);
            List<Equipe> lstEquipe = CtrlEquipe.lstEquipeByCodeProjet(projet.codeProjet);
            List<CasTest> lstCasTest = new List<CasTest>();
            foreach (Equipe equipe in lstEquipe)
            {
                cmbEquipe.Items.Add(equipe.nomEquipe);
                foreach (CasTest casTest in equipe.CasTest)
                {
                    lstCasTest.Add(casTest);
                }
            }
            dataGridCasTest.DataSource = lstCasTest;
            dataGridCasTest.DataBind();
        }
        private void showEmptyDataGrid()
        {
            DataTable dT = new DataTable();
            dT.Columns.AddRange(new DataColumn[6] { new DataColumn("CodeCasTest", typeof(string)), new DataColumn("NomCasTest", typeof(string)), new DataColumn("PrioriteCasTest", typeof(string)), new DataColumn("DifficulteCasTest", typeof(string)), new DataColumn("DateLivraisonCasTest", typeof(string)), new DataColumn("Options", typeof(TemplateField)) });
            dT.Rows.Add(dT.NewRow());
            dT.Rows[0].SetField("NomCasTest", "No Record Available");
            dataGridCasTest.Visible = true;
            dataGridCasTest.DataSource = dT;
            dataGridCasTest.DataBind();
            dataGridCasTest.HeaderRow.Visible = true;
        }

        protected void btnCreerBillet_Click(object sender, EventArgs e)
        {
            Response.Redirect("creerBilletTravail.aspx");
        }
    }
}