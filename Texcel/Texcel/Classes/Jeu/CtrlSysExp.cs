using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Jeu;

namespace Texcel.Classes.Jeu
{
    //
    //
    //Controle SysExp
    //Cette classe contient toutes les méthodes et traitements en lien avec les systèmes d'exploitation.
    //
    //
    class CtrlSysExp : CtrlController
    {
        private static SysExp sysExp;

        // Obtenir le nombre d'itération dans la table tblSysExp.
        public static int GetCount()
        {
            return context.SysExp.Count();
        }

        // Retourne la liste de tous les systèmes d'exploitation.
        public static List<SysExp> getListSysExp()
        {
            List<SysExp> lstSysExp = new List<SysExp>();
            foreach (SysExp sysExp in context.SysExp)
            {
                lstSysExp.Add(sysExp);
            }
            return lstSysExp;         
        }   

        // Recherche un système d'exploitation par son nom et le retourne.
        public static SysExp GetSysExp(string _nomSysExp)
        {
           SysExp monSysExp = context.SysExp.Where(x => x.nomSysExp == _nomSysExp).First();

           return monSysExp;
        }

        // Ajoute un nouveau système d'exploitation dans la table tblSysExp, vérifie s'il existe et si l'ajout réussit. Retourne un booléen pour confirmer l'ajout.
        public static bool Ajouter(string _nomSysExp, string _codeSysExp, string _commSysExp)
        {
            if (!Verifier(_nomSysExp))
            {
                sysExp = new SysExp();
                sysExp.nomSysExp = _nomSysExp;
                sysExp.codeSysExp = _codeSysExp;
                return Enregistrer(sysExp);
            }
            return false;
        }

        // Vérifie si le système d'exploitation existe.
        public static bool Verifier(string _nomSysExp)
        {
            if (context.SysExp.Where(x => x.nomSysExp == _nomSysExp).Count() != 0)
            {
                return true;    //lorsque le système d'exploitation existe  
            }
            return false;   // lorsque le système d'exploitation n'existe pas 
        }

        // Enregistre dans la table le nouveau système d'exploitation et retourne un booléen pour confirmer.
        private static bool Enregistrer(SysExp _sysExp)
        {
            context.SysExp.Add(_sysExp);
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

        // Modifie les données d'un systeme d'exploitation.
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
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                //erreur de l'enregistrement
                return;
            }
        }

    }
}
