using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes;

namespace TexcelWeb.Classes.Test
{
        
    public class CtrlCopier
    {
        static GridView monGV;
        static List<cProjet> lstProjet = new List<cProjet>();
        static List<CasTest> lstCasTest = new List<CasTest>();
        static cProjet monProj;
        static CasTest monCT;

        public static void SauvegarderDonnees(GridView _monGV)
        {
            monGV = _monGV;
        }

        public static void CopierElement()
        {
            lstCasTest.Clear();
            lstProjet.Clear();
            // Iteration à travers le gridview
            foreach (GridViewRow row in monGV.Rows)
            {
                // accès à mon checkbox
                CheckBox cb = (CheckBox)row.FindControl("ChkBox");
                if (cb != null && cb.Checked)
                {
                    DetermineObject(row.Cells[1].Text);               
                }
            }
            EnvoyerLstObjetCopier();
        }
   
        // Chercher l'objet et le mettre dans la liste correspondante
        private static void DetermineObject(string _idUnique)
        {
            if (CtrlProjet.getProjetByCode(_idUnique) != null)
            {
                monProj = CtrlProjet.getProjetByCode(_idUnique);
                lstProjet.Add(monProj);                
            }
            else if (CtrlCasTest.GetCasTestByCode(_idUnique) != null)
            {
                monCT = CtrlCasTest.GetCasTestByCode(_idUnique);
                lstCasTest.Add(monCT);
            }

            if (monProj == null && monCT == null)
            {
                //ERREUR! 
            }
        }

        // Envoyer la liste d'élément cocher au bon controlleur
        private static void EnvoyerLstObjetCopier()
        {
            if (lstProjet.Count == 0 )
            {
                CtrlCasTest.SauvegarderLstCasTest(lstCasTest);
            }
            else
            {
               // on sauvegarde liste de projet
            }
        }
    }
}