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
        static bool VerifSelec = false;
        static Utilisateur user;
        protected void Page_Load(object sender, EventArgs e)
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

        public void RemplirChamps()
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
                        dR["DateLivraison"] = "YO";
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
                        VerifSelec = true;
                    }
                    else
                    {
                        VerifSelec = false;
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
            }

            GridView1.DataSource = dT;
            GridView1.DataBind();


        }

        protected void CBSelec_CheckedChanged(object sender, EventArgs e)
        {
            bool verifChecked = false;
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                verifChecked = true;
            }
            GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
            if (CtrlBilletTravail.SelectionneBillet(CtrlBilletTravail.GetBillet(row.Cells[0].Text), verifChecked))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Oops!\", \"Billet selectionné.\", \"error\");", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal(\"Oops!\", \"Billet déselectionné.\", \"error\");", true);
            }
            
            
        }

      

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox checkBox = (e.Row.FindControl("CBSelec") as CheckBox);
                if (VerifSelec == true)
                {
                    checkBox.Checked = true;
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

    }
}