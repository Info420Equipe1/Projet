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
            Response.Write("<script>alert('Fire');</script>");
            //CheckBox chk = (CheckBox)sender;
            //GridViewRow gr = (GridViewRow)chk.Parent.Parent;
            //lblNbrBillet.Text = GridView1.DataKeys[gr.RowIndex].Value.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //        if (row.RowIndex == GridView1.SelectedIndex)
        //        {
        //            row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
        //            row.ToolTip = string.Empty;
        //        }
        //        else
        //        {
        //            row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
        //            row.ToolTip = "Cliquez pour selectionner cette colonne";
        //        }
        //    }
        //}

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
        //        e.Row.ToolTip = "Cliquez pour selectionner cette colonne";
        //    }
        //}

        //protected void btnVisualiser_Click(object sender, EventArgs e)
        //{
        //    Session["BilletTravail"] = CtrlBilletTravail.GetBillet(GridView1.SelectedRow.Cells[0].Text);
        //}
    }
}