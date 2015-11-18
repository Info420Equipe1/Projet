using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
using System.IO;
using System.Data;

namespace TexcelWeb.Classes
{
    public class CtrlRecherche
    {
        static GridView monGV;
        static List<object> lstLigneCocher = new List<object>();
        public CtrlRecherche()
        {
           
        }

        public static void SauvegarderDonnees(GridView _monGV)
        {
            monGV = _monGV;
        }

        public static void VerifierChkBox()
        {
            lstLigneCocher.Clear();
            // Iteration à travers le gridview
            foreach (GridViewRow row in monGV.Rows)
            {
                // accès à mon checkbox
                CheckBox cb = (CheckBox)row.FindControl("ChkBox");
                if (cb != null && cb.Checked)
                {
                    if (lstLigneCocher.Contains(row) == false)
                    {
                        
                        string cid = row.Cells[1].Text;                       
                        lstLigneCocher.Add(row);
                        afficher();
                    }                  
                        
                }
            }
          

        }

        private static void afficher()
        {
            foreach (object item in lstLigneCocher)
	        {
                GridViewRow gr = (GridViewRow)item;
                for (int i = 0; i < gr.Cells.Count; i++)
                {
                    string cid = gr.Cells[i].Text;
                }
	        }
        }
       

    }
}

