using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes.Personnel;
using System.Drawing;

namespace TexcelWeb.Interfaces
{
    public partial class billetsTravail : System.Web.UI.Page
    {   
        private static List<bool> VerifSelec = new List<bool>();
        private static List<bool> VerifTerm = new List<bool>();
        private static Utilisateur user;
        private static int cpt = 0;
        
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Premier loading de la page
                if (CtrlController.GetCurrentUser() == null)
                {
                    //Not logged in
                    Response.Redirect("login.aspx");
                }
                else
                {
                    //Formatage Bienvenue, [NomUtilisateur] et la Date
                    user = CtrlController.GetCurrentUser();
                    txtCurrentUserName.InnerText = user.nomUtilisateur;
                    RemplirChamps();
                }
            }
        }

        private void RemplirChamps()
        {
            List<BilletTravail> lstBilletTravail = CtrlBilletTravail.GetLstBilletTravail(CtrlEmploye.getEmployeById(user.noEmploye.ToString()));
            int cpt = new int();
            cpt = 0;
            DataTable dT = new DataTable();
            dT.Columns.AddRange(new DataColumn[7] { new DataColumn("Titre", typeof(string)), new DataColumn("Priorite", typeof(string)), new DataColumn("Difficulte", typeof(string)), new DataColumn("DateLivraison", typeof(string)), new DataColumn("TypeTest", typeof(string)), new DataColumn("Duree", typeof(string)), new DataColumn("Projet", typeof(string)) });

            if (lstBilletTravail.Count() != 0)
            {
                foreach (BilletTravail bT in lstBilletTravail)
                {
                    if (bT.CasTest != null)
                    {
                        DataRow dR = dT.NewRow();
                        dR["Titre"] = bT.titreBilletTravail;
                        dR["Priorite"] = bT.NiveauPriorite.nomNivPri;

                        dR["Difficulte"] = bT.CasTest.Difficulte.nomDiff;
                        if (bT.dateLivraison != null)
                        {
                            dR["DateLivraison"] = ((DateTime)bT.dateLivraison).ToShortDateString();
                        }
                        else
                        {
                            dR["DateLivraison"] = "Aucune date";
                        }
                        dR["TypeTest"] = bT.CasTest.TypeTest.nomTest;

                        dR["Duree"] = bT.dureeBilletTravail;
                        dR["Projet"] = bT.CasTest.cProjet.nomProjet;
                        dT.Rows.Add(dR);
                        if (bT.idNivPri == 1)
                        {
                            cpt++;
                        }
                        if (bT.noEmploye != null)
                        {
                            VerifSelec.Add(true);
                        }
                        else
                        {
                            VerifSelec.Add(false);
                        }
                        if (bT.idStatut == 5)
                        {
                            VerifTerm.Add(true);
                        }
                        else
                        {
                            VerifTerm.Add(false);
                        }
                    }
                }

                lblNbrBilletPersonnel.Text = lstBilletTravail.Count.ToString();
                lblNbrBillet.Text = cpt.ToString();

            }
            else
            {
                dT.Rows.Add(dT.NewRow());
                dT.Rows[0].SetField("Titre", "No Record Available");
                lblNbrBillet.Text = "0";
                lblNbrBilletPersonnel.Text = "0";
                GridView1.Enabled = false;
            }
            ViewState["dtbl"] = dT;
            GridView1.DataSource = dT;
            GridView1.DataBind();
        }

        private void CBSelec_CheckedChanged(object sender, EventArgs e)
        {
            bool verifChecked = false;
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                verifChecked = true;
            }
            GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
            if (CtrlBilletTravail.SelectionneBillet(CtrlBilletTravail.GetBillet(row.Cells[0].Text), verifChecked, CtrlEmploye.getEmployeById(user.noEmploye.ToString())))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Attention!\", \"Billet selectionné.\", \"error\");", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Attention!\", \"Billet déselectionné.\", \"error\");", true);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox checkBoxSel = (e.Row.FindControl("CBSelec") as CheckBox);
                CheckBox checkBoxTerm = (e.Row.FindControl("CBTer") as CheckBox);
                if (e.Row.Cells[1].Text == "Basse")
                {
                    e.Row.BackColor = Color.LightGreen;
                }
                else if (e.Row.Cells[1].Text == "Normale")
                {
                    e.Row.BackColor = Color.Khaki;
                }
                else if (e.Row.Cells[1].Text == "Elevee")
                {
                    e.Row.BackColor = Color.FromArgb(255, 105, 107); ;
                }
                if (VerifSelec.Count() != 0)
                {
                    if (VerifSelec[cpt] == true)
                    {
                        checkBoxSel.Checked = true;
                    }
                    if (VerifTerm[cpt] == true)
                    {
                        checkBoxTerm.Checked = true;
                        checkBoxSel.Enabled = false;
                    }
                    cpt++;
                }
            }
        }

        protected void lnkCasDeTest_Click(object sender, EventArgs e)
        {
            BilletTravail bT = CtrlBilletTravail.GetBillet((sender as LinkButton).CommandArgument);
            CasTest casTest = CtrlCasTest.GetCasTestByCode(bT.codeCasTest);
            Session["CasTestConsulTesteur"] = casTest;
            this.Form.Dispose();
            Response.Redirect("creerCasTest.aspx");
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            cpt = 0;
            DataTable dataTable = ViewState["dtbl"] as DataTable;
            string sortingDirection = string.Empty;

            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                sortingDirection = "Asc";
            }
            
            DataView sortedView = new DataView(dataTable);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            GarderEtatsCheckBoxSorting(sortedView);
            GridView1.DataSource = sortedView;
            GridView1.DataBind();
        }

        private SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }

        private void GarderEtatsCheckBoxSorting(DataView _dT)
        {
            VerifSelec.Clear();
            VerifTerm.Clear();
            foreach (DataRowView dR in _dT)
            {
                if (CtrlBilletTravail.GetBillet(dR[0].ToString()).noEmploye != null)
                {
                    VerifSelec.Add(true);
                }
                else
                {
                    VerifSelec.Add(false);
                }
                if (CtrlBilletTravail.GetBillet(dR[0].ToString()).termine == 1)
                {
                    VerifTerm.Add(true);
                }
                else
                {
                    VerifTerm.Add(false);
                }
            }
        }

        protected void lnkBilletTravail_Click(object sender, EventArgs e)
        {
            BilletTravail bT = CtrlBilletTravail.GetBillet((sender as LinkButton).CommandArgument);
            Session["BilletTravailConsulTesteur"] = bT;
            this.Form.Dispose();
            Response.Redirect("creerBilletTravail.aspx");
        }

        protected void CBTer_CheckedChanged(object sender, EventArgs e)
        {
            bool verifChecked = false;
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                verifChecked = true;
            }
            GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
            CheckBox checkBoxSelec = (row.FindControl("CBSelec") as CheckBox);
            if (checkBoxSelec.Checked == true)
            {
                if (CtrlBilletTravail.TermineBillet(CtrlBilletTravail.GetBillet(row.Cells[0].Text), verifChecked))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Attention!\", \"Billet terminé.\", \"error\");", true);
                    checkBoxSelec.Enabled = false;
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Attention!\", \"Billet non terminé.\", \"error\");", true);
                    checkBoxSelec.Enabled = true;
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Attention!\", \"Vous devez sélectionné le billet.\", \"error\");", true);
                checkBox.Checked = false;
            }
        }
    }
}