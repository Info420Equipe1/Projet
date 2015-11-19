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
        static string monObject;
        static List<GridViewRow> lstRowCocher = new List<GridViewRow>();
        static List<object> lstMesSelection = new List<object>();

        public CtrlRecherche()
        {
           
        }

        public static void SauvegarderDonnees(GridView _monGV)
        {            
            monGV = _monGV;
           
        }

        public static void CopierElement()
        {
            lstRowCocher.Clear();
            // Iteration à travers le gridview
            foreach (GridViewRow row in monGV.Rows)
            {
                // accès à mon checkbox
                CheckBox cb = (CheckBox)row.FindControl("ChkBox");
                if (cb != null && cb.Checked)
                {
                    if (lstRowCocher.Contains(row) == false)
                    {
                        DeterminerTypeObject(row.Cells[1].Text);                                         
                        ConvertirDonneeLst();
                    }                  
                }              
            }
            
        }
        private static void ConvertirDonneeLst()
        {
            if (lstRowCocher.Count != 0 && lstRowCocher != null)
            {
                switch (monObject)
                {
                    case "Projet":
                        foreach (GridViewRow o in lstRowCocher)
                        {
                            lstMesSelection.Add(CtrlProjet.getProjetByCode(o.Cells[1].Text));
                        }
                        break;

                    case "CasTest":
                       //...                      
                        break;

                    default:
                        //...
                        break;
                }

            }
        }

        private static string DeterminerTypeObject(string _idUnique)
        {           
           if(CtrlProjet.getProjetByCode(_idUnique) != null)
           {
               monObject = "Projet";           
           }
           else if(CtrlCasTest.GetCasTestByCode(_idUnique) != null)
	       {
               monObject = "CasTest";
	       }

           if (monObject == null)
           {
               monObject = "bin ca marche pas hahahah";
           }
           return monObject;
        }
    }
}

