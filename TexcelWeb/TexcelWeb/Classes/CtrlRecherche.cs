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
        static object monObject;
        static List<object> lstMesSelection = new List<object>();

        public static void SauvegarderDonnees(GridView _monGV)
        {
            monGV = _monGV;
        }

        public static void CopierElement()
        {
            lstMesSelection.Clear();
            // Iteration à travers le gridview
            foreach (GridViewRow row in monGV.Rows)
            {
                // accès à mon checkbox
                CheckBox cb = (CheckBox)row.FindControl("ChkBox");
                if (cb != null && cb.Checked)
                {
                    DetermineObject(row.Cells[1].Text);
                    RemplirDonneeLst();
                }
            }
        }
        private static void RemplirDonneeLst()
        {
            lstMesSelection.Add(monObject);
        }

        private static void DetermineObject(string _idUnique)
        {           
           if(CtrlProjet.getProjetByCode(_idUnique) != null)
           {
               monObject = CtrlProjet.getProjetByCode(_idUnique);         
           }
           else if(CtrlCasTest.GetCasTestByCode(_idUnique) != null)
	       {
               monObject = CtrlCasTest.GetCasTestByCode(_idUnique);
	       }
         
        }
    }
}
