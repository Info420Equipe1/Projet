using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Test;
using System.IO;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Metadata.Edm;
using TexcelWeb.Classes;
using System.Data;
using System.Web.UI.HtmlControls;
using TexcelWeb.Classes.Projet;

namespace TexcelWeb.Classes.Test
{
    public class CtrlCasTest : CtrlController
    {
        static CasTest casTestEnCours;
        static List<FileInfo> lstFichier = new List<FileInfo>();
        
           
        public static CasTest getCasTestEnCours
        {
            get { return casTestEnCours; }
        }
        
        public static bool Ajouter(CasTest _cT)
        {
            try
            {
                context.CasTest.Add(_cT);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Ajouter lorsque il faut lier avec un projet et un type test
        public static bool Ajouter(string _code, string _nom, cProjet _proj, Difficulte _diff, NiveauPriorite _prio, DateTime _crea, string _livr, TypeTest _tT, string _desc, string _obj, string _divers)
        {
            CasTest casTest = new CasTest();
            casTest.codeCasTest = _code;
            casTest.nomCasTest = _nom;
            if (_proj != null)
            {
                casTest.codeProjet = _proj.codeProjet;
            }
            if (_diff != null)
            {
                casTest.idDiff = _diff.idDiff;
            }
            if (_prio != null)
            {
                casTest.idNivPri = _prio.idNivPri;
            }
            
            casTest.dateCreation = _crea;
            if (_livr != "")
            {
                casTest.dateLivraison = Convert.ToDateTime(_livr);
            }
            if (_tT != null)
            {
                casTest.idTest = _tT.idTest;
            }
            
            casTest.descCasTest = _desc;
            casTest.objCasTest = _obj;
            casTest.divCasTest = _divers;
            CreerDossier(casTest);

            try
            {
                context.CasTest.Add(casTest);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Modifier(string _nom, cProjet _proj, Difficulte _diff, NiveauPriorite _prio, DateTime _crea, string _livr, TypeTest _tT, string _desc, string _obj, string _divers, CasTest _casTest)
        {
           
            _casTest.nomCasTest = _nom;
            if (_proj != null)
            {
                _casTest.codeProjet = _proj.codeProjet;
            }
            else
            {
                _casTest.cProjet = null;
            }
            if (_diff != null)
            {
                _casTest.idDiff = _diff.idDiff;
            }
            else
            {
                _casTest.Difficulte = null;
            }
            if (_prio != null)
            {
                _casTest.idNivPri = _prio.idNivPri;
            }
            else
            {
                _casTest.NiveauPriorite = null;
            }
            _casTest.dateCreation = _crea;
            if (_livr != "")
            {
                _casTest.dateLivraison = Convert.ToDateTime(_livr);
            }
            if (_tT != null)
            {
                _casTest.idTest = _tT.idTest;
            }
            else
            {
                _casTest.TypeTest = null;
            }
            _casTest.descCasTest = _desc;
            _casTest.objCasTest = _obj;
            _casTest.divCasTest = _divers;

            try
            {
                
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Rechercher un Cas de test avec le CodeCasTest
        public static CasTest GetCasTestByCode(string codeCasTest)
        {
            try
            {
                return context.CasTest.Where(x => x.codeCasTest == codeCasTest).First();
            }
            catch (Exception)
            {

                return null;
            }
           
        }

        //Rechercher un Cas de test avec le NomCasTest
        public static CasTest GetCasTestByNom(string nomCasTest)
        {
            return context.CasTest.Where(x => x.nomCasTest == nomCasTest).First();
        }

        public static List<CasTest> GetLstCasTest()
        {
            List<CasTest> lst = new List<CasTest>();

            foreach (CasTest casTest in context.CasTest)
            {
                lst.Add(casTest);
            }
            return lst;
        }

        public static void CreerDossier(CasTest _casTest)
        {
            string path = HttpContext.Current.Server.MapPath(@"~/cProjets/" + _casTest.codeProjet + "/" + _casTest.codeCasTest);
            if (!(Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static int GetMaxLength<TEntity>(Expression<Func<TEntity, string>> property)
           where TEntity : CasTest
        {
            var adapter = (IObjectContextAdapter)context;
            ObjectContext objectContext = adapter.ObjectContext;

            var test = objectContext.MetadataWorkspace.GetItems(DataSpace.CSpace);

            if (test == null)
                return -1;

            Type entType = typeof(TEntity);
            string propertyName = ((MemberExpression)property.Body).Member.Name;

            var q = test
                .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                .SelectMany(meta => ((EntityType)meta).Properties
                .Where(p => p.Name == propertyName && p.TypeUsage.EdmType.Name == "String"));

            var queryResult = q.Where(p =>
            {
                var match = p.DeclaringType.Name == entType.Name;
                if (!match)
                    match = entType.Name == p.DeclaringType.Name;

                return match;

            })
                .Select(sel => sel.TypeUsage.Facets["MaxLength"].Value)
                .ToList();

            if (queryResult.Any())
            {
                int result = Convert.ToInt32(queryResult.First());
                return result;
            }
            return -1;
        }

        public static void CopierCasTestEnCours(string _code, string _nom, cProjet _proj, Difficulte _diff, NiveauPriorite _prio, 
            DateTime _crea, DateTime _livr, TypeTest _tT, string _desc)
        {
            casTestEnCours = new CasTest();
            casTestEnCours.codeCasTest = _code;
            casTestEnCours.nomCasTest = _nom;
            casTestEnCours.cProjet = _proj;
            casTestEnCours.Difficulte = _diff;
            casTestEnCours.NiveauPriorite = _prio;
            casTestEnCours.dateCreation = _crea;
            casTestEnCours.dateLivraison = _livr;
            casTestEnCours.TypeTest = _tT;
            casTestEnCours.descCasTest = _desc; 

        }
   
        public static string[] GetPaths(CasTest _casTest)
        {
            string[] filePaths = Directory.GetFiles(HttpContext.Current.Server.MapPath(@"~/cProjets/" + _casTest.codeProjet + "/" + _casTest.codeCasTest));

            return filePaths;
        }

        public static List<FileInfo> GetFile(CasTest _casTest)
        {
            string path = HttpContext.Current.Server.MapPath(@"~/cProjets/" + _casTest.codeProjet + "/" + _casTest.codeCasTest);
            CtrlCopier.CreationDossierParentCasTest(_casTest, path);

            string[] filePaths = Directory.GetFiles(HttpContext.Current.Server.MapPath(@"~/cProjets/" + _casTest.codeProjet + "/" + _casTest.codeCasTest));
             
            List<FileInfo> file = new List<FileInfo>();

            for (int i = 0; i < filePaths.GetLength(0); i++)
            {
                file.Add(new FileInfo(filePaths[i]));
            }
            return file;
           
        }
           
        // Remplir une liste de tous les fichiers des cas de test cochés préalablement
        public static List<FileInfo> PopulateLstPathsFile(List<CasTest> _lstCasTest)
        {
            lstFichier.Clear();
            foreach (CasTest ct in _lstCasTest)
            {
                List<FileInfo>  mesfichiers = GetFile(ct);

                if (mesfichiers.Count != 0)
                {
                    for (int i = 0; i < mesfichiers.Count; i++)
                    {
                        lstFichier.Add(mesfichiers[i]);
                    }  
                }                                              
            }

            return lstFichier;
        }  

        public static void Supprimer(List<CasTest> _lst)
        {
            foreach (CasTest casTest in _lst)
            {
                
                foreach (Equipe equ in casTest.Equipe)
                {
                    equ.CasTest.Remove(casTest);
                }
                foreach (BilletTravail bT in casTest.BilletTravail)
                {
                    bT.CasTest = null;
                }
                context.CasTest.Remove(casTest);
            }
            context.SaveChanges();
        }
  
      
    }
}