using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Personnel;
using TexcelWeb.Classes.Projet;

namespace TexcelWeb
{
    public partial class creerBilletChefEquipe : System.Web.UI.Page
    {
        static List<CasTest> lstCasTest;
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
            List<cProjet> lstProjetChefEquipeActuel = CtrlEquipe.lstProjetByChefEquipe(employe.prenomEmploye + " " + employe.nomEmploye);
            foreach (cProjet projet in lstProjetChefEquipeActuel)
            {
                cmbProjet.Items.Add(projet.nomProjet);
            }
        }

        protected void cmbProjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            cProjet projet = CtrlProjet.GetProjet(cmbProjet.Text);
            List<Equipe> lstEquipe = CtrlEquipe.lstEquipeByCodeProjet(projet.codeProjet);
            lstCasTest = new List<CasTest>();
            cmbEquipe.Items.Clear();
            foreach (Equipe equipe in lstEquipe)
            {
                cmbEquipe.Items.Add(equipe.nomEquipe);
                foreach (CasTest casTest in equipe.CasTest)
                {
                    lstCasTest.Add(casTest);
                }
            }
        }
        private void ajoutDonnesDataGrid(List<CasTest> lstCasTest)
        {
            //Emplissage du gridView pour les cas de test
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("CodeCasTest");
            dt.Columns.Add("NomCasTest");
            dt.Columns.Add("DateLivraisonCasTest");
            dt.Columns.Add("PrioriteCasTest");
            dt.Columns.Add("DifficulteCasTest");
            dt.Columns.Add("Options");

            foreach (CasTest casTest in lstCasTest)
            {
                DataRow dr = dt.NewRow();

                dr.SetField("CodeCasTest", casTest.codeCasTest);
                dr.SetField("NomCasTest", casTest.nomCasTest);
                if (casTest.dateLivraison != null)
                {
                    dr.SetField("DateLivraisonCasTest", ((DateTime)casTest.dateLivraison).ToShortDateString());
                }
                if (casTest.NiveauPriorite != null)
                {
                    dr.SetField("PrioriteCasTest", casTest.NiveauPriorite.nomNivPri);
                }
                else
                {
                    dr.SetField("PrioriteCasTest", "");
                }
                if (casTest.Difficulte != null)
                {
                    dr.SetField("DifficulteCasTest", casTest.Difficulte.nomDiff);
                }
                else
                {
                    dr.SetField("DifficulteCasTest", "");
                }
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
            dataGridCasTest.DataSource = ds;
            dataGridCasTest.DataBind();

            foreach (GridViewRow gvr in dataGridCasTest.Rows)
            {
                HtmlAnchor hgc = (HtmlAnchor)gvr.Cells[5].FindControl("btnAjouterBilletCasTest");
                hgc.Attributes["href"] = "creerBilletTravail.aspx?codeCasTest=" + gvr.Cells[0].Text+"&equipe="+cmbEquipe.Text;
                HtmlAnchor hgc2 = (HtmlAnchor)gvr.Cells[5].FindControl("btnConsulterCasTest");
                hgc2.Attributes["href"] = "creerBilletTravail.aspx?codeCasTest=" + gvr.Cells[0].Text + "&equipe=" + cmbEquipe.Text + "&consulteBillet=true";
            }
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

        protected void dataGridCasTest_DataBound(object sender, EventArgs e)
        {
            //((LinkButton)(dataGridCasTest.HeaderRow.Cells[0].Controls[0])).Text = "Code";
            //((LinkButton)(dataGridCasTest.HeaderRow.Cells[1].Controls[0])).Text = "Nom Cas de Test";
            //((LinkButton)(dataGridCasTest.HeaderRow.Cells[2].Controls[0])).Text = "Date livraison";
            //((LinkButton)(dataGridCasTest.HeaderRow.Cells[3].Controls[0])).Text = "Priorité";
            //((LinkButton)(dataGridCasTest.HeaderRow.Cells[4].Controls[0])).Text = "Difficulté";
            //((LinkButton)(dataGridCasTest.HeaderRow.Cells[5].Controls[0])).Text = "Options";
        }

        protected void btnRechercher_Click(object sender, EventArgs e)
        {
            List<CasTest> lstCasTestAAfficher = new List<CasTest>();
            string nomProjet = cmbProjet.Text;
            string nomEquipe = cmbEquipe.Text;

            if (nomProjet!= "")
            {
                if (nomEquipe != "")
                {
                    foreach (CasTest castest in lstCasTest)
                    {
                        foreach (Equipe equipe in castest.Equipe)
                        {
                            if (nomEquipe == equipe.nomEquipe)
                            {
                                lstCasTestAAfficher.Add(castest);
                            }
                        }
                        
                    }
                    ajoutDonnesDataGrid(lstCasTestAAfficher);
                }
            }
        }
    }
}