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

        public CtrlRecherche()
        {

        }

        public static void SauvegarderDonnees(GridView _monGV)
<<<<<<< HEAD
        {            
            monGV = _monGV;           
=======
        {
            monGV = _monGV;

>>>>>>> origin/sprint3
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

<<<<<<< HEAD
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

           if (monObject == null)
           {
               monObject = null; // ca marche pas
           }
         
=======
        public static Object DetermineObject(string _idUnique)
        {
            if (CtrlProjet.getProjetByCode(_idUnique) != null)
            {
                monObject = CtrlProjet.getProjetByCode(_idUnique);
            }
            else if (CtrlCasTest.GetCasTestByCode(_idUnique) != null)
            {
                monObject = CtrlCasTest.GetCasTestByCode(_idUnique);
            }
            if (monObject == null)
            {
                monObject = null; // ca marche pas
            }
            return monObject;
>>>>>>> origin/sprint3
        }
    }
}
