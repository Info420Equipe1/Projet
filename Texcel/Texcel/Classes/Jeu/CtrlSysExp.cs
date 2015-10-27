using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Jeu;

namespace Texcel.Classes.Jeu
{
    class CtrlSysExp : CtrlController
    {
        private static SysExp sysExp;
        
        public static int GetCount()
        {
            return context.tblSysExp.Count();
        }

        public static List<SysExp> Rechercher()
        {
            List<SysExp> lstSysExp = new List<SysExp>();
            foreach (SysExp sysExp in context.tblSysExp)
            {
                lstSysExp.Add(sysExp);
            }
            return lstSysExp;         
        }   

        public static SysExp GetSysExp(string _nomSysExp)
        {
           SysExp monSe = context.tblSysExp.Where(x => x.nomSysExp == _nomSysExp).First();

           return monSe;
        }
        // On ajoute un nouveau système d'exploitation dans la table tblSysExp
        public static bool Ajouter(string _nomSysExp, string _codeSysExp, string _commSysExp)
        {
            if (!Verifier(_nomSysExp))
            {
                sysExp = new SysExp();
                sysExp.nomSysExp = _nomSysExp;
                sysExp.codeSysExp = _codeSysExp;
                //sysExp.descSysExp = _commSysExp;
                return Enregistrer(sysExp);
            }
            /*if(Rechercher(_nomSysExp).First().commSysExp != _commSysExp)
            {
                
            }*/
            return false;
        }

        public static bool Verifier(string _nomSysExp)
        {
            if (context.tblSysExp.Where(x => x.nomSysExp == _nomSysExp).Count() != 0)
            {
                return true;    //lorsque le système d'exploitation existe  
            }
            return false;   // lorsque le système d'exploitation n'existe pas 
        }

        // Rechercher un système d'exploitation dans la table tblSysExp
        public static List<SysExp> Rechercher(string _nomSysExp)
        {
            List<SysExp> lstSysExp = new List<SysExp>(); ;
            foreach (SysExp sysExp in context.tblSysExp.Where(x => x.nomSysExp == _nomSysExp))
            {
                lstSysExp.Add(sysExp);
            }
            return lstSysExp;
        }

        // On enregistre dans la table le nouveau système d'exploitation
        private static bool Enregistrer(SysExp _sysExp)
        {
            context.tblSysExp.Add(_sysExp);
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors de l'ajout du Système d'Exploitation. Les données n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
        }

<<<<<<< HEAD
        public static void modif(string _nom, string _code, string _comm, SysExp _sysExp, string _nomEd, EditionSysExp _ed, string _nomVersion, VersionSysExp _ver)
        {
            SysExp sysExp = _sysExp;
            sysExp.codeSysExp = _code;
            sysExp.nomSysExp = _nom;
            VersionSysExp ver = _ver;
            ver.noVersion = _nomVersion;
            ver.commSysExp = _comm;
            EditionSysExp ed = _ed;
            ed.nomEdition = _nomEd;
            context.SaveChanges();

        }
        // requete qui marche pas mais pourquoi?
        //public static List<SysExp> GetSysExp(string _editionSysExp,string _versionSysExp)
        //{          
        //        return (
        //            from a in context.tblSysExp
        //            from b in a.EditionSysExp
        //            from c in b.VersionSysExp
        //            where b.nomEdition == _editionSysExp
        //            where c.noVersion == _versionSysExp
        //            select new SysExp()
        //            {
        //                idSysExp = a.idSysExp,
        //                nomSysExp = a.nomSysExp,
        //                codeSysExp = a.codeSysExp,
        //                EditionSysExp = a.EditionSysExp,
        //                Plateforme = a.Plateforme
        //            }).ToList();
          
        //}
=======
>>>>>>> origin/sprint2
    }
}
