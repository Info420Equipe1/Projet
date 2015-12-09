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
using TexcelWeb.Classes.Test;

namespace TexcelWeb
{
    public partial class creerBilletChefEquipe : System.Web.UI.Page
    {
        static List<CasTest> lstCasTest;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilisateur currentUser = CtrlController.GetCurrentUser();
            if (!IsPostBack)
            {
                if (CtrlController.GetCurrentUser() == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {   
                    txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
                }
                fillDropDownList();
                cmbEquipe.Enabled = false;
                if (cmbProjet.Text !="Aucun")
                {
                    this.cmbProjet_SelectedIndexChanged(this, e);
                }
                showEmptyDataGrid();
            }
            foreach (Groupe groupe in currentUser.Groupe)
            {
                List<int> lstDroits = CtrlController.GetDroits(groupe);
                if (!lstDroits.Contains(19) && !lstDroits.Contains(20))
                {
                    boxProjet.Visible = false;
                    menuProjet.Visible = false;
                    lienAjouterProjet.Visible = false;
                    lienProjetEquipe.Visible = false;
                }
                else if (groupe.idGroupe == 1)
                {
                    lienProjetEquipe.Visible = false;
                    boxCasTest.Visible = false;
                    menuCasTest.Visible = false;
                    lienCasTest.Visible = false;
                }
                if (!lstDroits.Contains(21) && !lstDroits.Contains(22))
                {
                    boxCasTest.Visible = false;
                    menuCasTest.Visible = false;
                    lienCasTest.Visible = false;
                }
                else if (groupe.idGroupe == 2)
                {
                    lienAjouterProjet.Visible = false;
                }
                if (!lstDroits.Contains(24))
                {
                    boxBilletTravail.Visible = false;
                    menuBilletTravail.Visible = false;
                    lienBilletChefEquipe.Visible = false;
                    lienGestionBillets.Visible = false;
                }
                else if (groupe.idGroupe == 3)
                {
                    boxProjet.Visible = false;
                    menuProjet.Visible = false;
                    lienAjouterProjet.Visible = false;
                    lienProjetEquipe.Visible = false;
                    boxCasTest.Visible = false;
                    menuCasTest.Visible = false;
                    lienCasTest.Visible = false;
                }
            }
        }
        private void fillDropDownList()
        {
            Employe employe = (CtrlController.GetCurrentUser()).Employe;
            List<cProjet> lstProjetChefEquipeActuel = CtrlEquipe.lstProjetByChefEquipe(employe.noEmploye);
            if (lstProjetChefEquipeActuel.Count != 0)
            {
                foreach (cProjet projet in lstProjetChefEquipeActuel)
                {
                    cmbProjet.Items.Add(projet.nomProjet);
                }
            }
            else
            {
                ListItem lst = new ListItem("Aucun");
                cmbProjet.Items.Add(lst);
                cmbProjet.SelectedIndex = cmbProjet.Items.IndexOf(lst);
            }
        }

        protected void cmbProjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem lst = new ListItem("Aucune");
            cmbEquipe.Items.Clear();
            cmbEquipe.Items.Add(lst);
            if (cmbProjet.Text != "Aucun")
            {
                cProjet projet = CtrlProjet.GetProjet(cmbProjet.Text);
                List<Equipe> lstEquipe = CtrlEquipe.lstEquipeByCodeProjet(projet.codeProjet);
                lstCasTest = new List<CasTest>();
                foreach (Equipe equipe in lstEquipe)
                {
                    cmbEquipe.Items.Add(equipe.nomEquipe);
                    foreach (CasTest casTest in equipe.CasTest)
                    {
                        if (!lstCasTest.Contains(casTest))
                        {
                            lstCasTest.Add(casTest);
                        }
                    }
                }
                cmbEquipe.Enabled = true;
            }
            else
            {
                cmbEquipe.Enabled = false;
            }
            cmbEquipe.SelectedIndex = cmbEquipe.Items.IndexOf(lst);
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
                hgc.Attributes["href"] = "creerBilletTravail.aspx?codeCasTest=" + gvr.Cells[0].Text;
                HtmlAnchor hgc2 = (HtmlAnchor)gvr.Cells[5].FindControl("btnConsulterCasTest");
                hgc2.Attributes["href"] = "creerCasTest.aspx?codeCasTestConsult=" + gvr.Cells[0].Text + "&consulteBillet=true";
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
            
            string nomProjet = cmbProjet.Text;
            string nomEquipe = cmbEquipe.Text;

            if (nomProjet!= "Aucun")
            {
                if (nomEquipe != "Aucune")
                {
                    List<CasTest> lstCasTestAAfficher = new List<CasTest>();
                    foreach (CasTest castest in lstCasTest)
                    {
                        try
                        {
                            Equipe equipe = castest.Equipe.Where(x => x.nomEquipe == nomEquipe).First();
                            foreach (CasTest casdeTest in equipe.CasTest)
                            {
                                lstCasTestAAfficher.Add(casdeTest);
                            }
                        }
                        catch (Exception)
                        {
                            //Aucune equipe dans le cas de test
                        }
                    }
                    if (lstCasTestAAfficher.Count != 0)
                    {
                        ajoutDonnesDataGrid(lstCasTestAAfficher);
                    }
                    else
                    {
                        showEmptyDataGrid();
                    }
                }
                else
                {
                    List<CasTest> lstCasTestAAfficher = new List<CasTest>();
                    cProjet projet = CtrlProjet.GetProjet(nomProjet);
                    foreach (CasTest casTest in projet.CasTest)
                    {
                        lstCasTestAAfficher.Add(casTest);
                    }
                    if (lstCasTestAAfficher.Count != 0)
                    {
                        ajoutDonnesDataGrid(lstCasTestAAfficher);
                    }
                    else
                    {
                        showEmptyDataGrid();
                    }
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Attention!\", \"Le chef d'équipe actuel ne travail sur aucun projet. Pour créer un billet de travail, le chef d'équipe doit obligatoirement être chef d'une ou plusieurs équipes au sein d'un projet.\", \"warning\");", true);
            }
        }
    }
}