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
        static List<CasTest> lstCasTestCopie = new List<CasTest>();
        static CasTest monCT;
        static List<FileInfo> lstFichier = new List<FileInfo>();

        static bool dossierParent = false;
        static bool dossierParentcT = false;

        public static void SauvegarderDonnees(GridView _monGV)
        {
            monGV = _monGV;
        }

        public static void Coche_Dechoche(bool _SiCocher, GridView _monGV)
        {           
            foreach (GridViewRow row in _monGV.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("ChkBox");
                if (_SiCocher == true)
                {
                    // on coche tout
                    cb.Checked = true;
                }
                else
                {
                    //on décoche tout
                    cb.Checked = false;
                }
                
            }
            SauvegarderDonnees(_monGV);
        }

        public static List<CasTest> getLstCasTestCoche()
        {
            lstCasTestCopie.Clear();
            // Iteration à travers le gridview
            foreach (GridViewRow row in monGV.Rows)
            {
                // accès à mon checkbox
                CheckBox cb = (CheckBox)row.FindControl("ChkBox");
                if (cb != null && cb.Checked)
                {
                    PopulateLstCasTestCoche(row.Cells[1].Text);               
                }
            }
            return lstCasTestCopie;
        }
   
        // Chercher l'objet et le mettre dans la liste correspondante
        private static void PopulateLstCasTestCoche(string _idUnique)
        {                     
            if (CtrlCasTest.GetCasTestByCode(_idUnique) != null)
            {
                monCT = CtrlCasTest.GetCasTestByCode(_idUnique);
                lstCasTestCopie.Add(monCT);
            }                       
        }
        public static void CreerLstFichier(List<CasTest> _lstCt)
        {
            lstFichier.Clear();
            lstFichier = CtrlCasTest.PopulateLstPathsFile(_lstCt);
        }

        public static void CreationDossierParentProjet(cProjet _proj, string _path)
        {
            if (!(Directory.Exists(_path)))
            {
                Directory.CreateDirectory(_path);
            }

        }
        public static void CreationDossierParentCasTest(CasTest _cT, string _path)
        {
            if (!(Directory.Exists(_path)))
            {
                Directory.CreateDirectory(_path);
            }

        }
        public static void CreationDossier(cProjet _proj, CasTest _cT)
        {
            string pathDossierProjet = HttpContext.Current.Server.MapPath(@"~/cProjets/" + _proj.codeProjet);
            if (!(Directory.Exists(pathDossierProjet)) || dossierParent == true)
            {
                CreationDossierParentProjet(_proj, pathDossierProjet);
                dossierParent = true;
            }

            string pathDossierCasTest = HttpContext.Current.Server.MapPath(@"~/cProjets/" + _proj.codeProjet + "/" + _cT.codeCasTest);
            if (!(Directory.Exists(pathDossierCasTest)) || dossierParentcT == true)
            {
                CreationDossierParentCasTest(_cT, pathDossierCasTest);
                dossierParentcT = true;
            }

            dossierParent = false;
            dossierParentcT = false;
        }
        public static void SaveFileToFolder(CasTest _casTest, FileInfo _file)
        {
            // _casTest.codeProjet = null ????
            File.Copy(_file.FullName, (HttpContext.Current.Server.MapPath(@"~/cProjets/" + _casTest.codeProjet + "/" + _casTest.codeCasTest + "/") + _file.Name), true);
        }
       
    }
}