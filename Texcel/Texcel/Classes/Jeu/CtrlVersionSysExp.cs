using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texcel.Classes.Jeu
{
    class CtrlVersionSysExp : CtrlController
    {
        private static VersionSysExp versionSysExp;

        // Obtenir le nombre d'itération dans la table tblVersionSysExp
        public static int GetCount()
        {
            return context.VersionSysExp.Count();
        }

        // Ajoute une nouvelle version dans la table tblVersionSysExp, vérifie si elle existe et si l'ajout réussit. Retourne un booléen pour confirmer l'ajout.
        public static bool Ajouter(SysExp sysExp, EditionSysExp editionSysExp, string _noVersion, string _commSysExp)
        {
            if (!Verifier(sysExp, _noVersion, editionSysExp.nomEdition) && _noVersion != "")
            {
                versionSysExp = new VersionSysExp();
                versionSysExp.noVersion = _noVersion;
                versionSysExp.idEdition = editionSysExp.idEdition;
                versionSysExp.commSysExp = _commSysExp;
                return Enregistrer(versionSysExp);
            }
            return false;
            
        }

        // Vérifie si la version existe.
        public static bool Verifier(SysExp sysExp, string _noVersion, string editionSysExp)
        {
            List<VersionSysExp> lstVersionSysExp = Rechercher(sysExp, editionSysExp);
            foreach (VersionSysExp versionSysExp in lstVersionSysExp)
            {
                if (versionSysExp.noVersion == _noVersion)
                {
                    return true;
                }
            }
            return false;
        }

        // Recherche une version dans la table tblVersionSysExp.
        public static List<VersionSysExp> Rechercher(SysExp sysExp, string _nomEdition)
        {
            List<VersionSysExp> lstVersionSysExp = new List<VersionSysExp>();
            if (CtrlEditionSysExp.Verifier(sysExp, _nomEdition))
            {
                EditionSysExp editionSysExp = CtrlEditionSysExp.Rechercher(sysExp, _nomEdition).First();
                foreach (VersionSysExp versionSysExp in editionSysExp.VersionSysExp)
                {
                    if (versionSysExp.idEdition == editionSysExp.idEdition && editionSysExp.idSysExp == sysExp.idSysExp)
                    {
                        lstVersionSysExp.Add(versionSysExp); 
                    }
                } 
            }
            return lstVersionSysExp;
        }

        // Enregistre dans la table la nouvelle edition et retourne un booléen pour confirmer.
        private static bool Enregistrer(VersionSysExp _versionSysExp)
        {
            context.VersionSysExp.Add(_versionSysExp);
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors de l'ajout de la Version du Système d'Exploitation. Les données n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        // Recherche versions reliées à une édition et retourne une liste de celles-ci.
        public static List<String> RechercherpourListe(string _nomEdSysExp)
        {
            List<String> lstVersion = new List<String>();
            foreach (VersionSysExp ver in context.VersionSysExp.Where(x => x.EditionSysExp.nomEdition == _nomEdSysExp))
            {
                lstVersion.Add(ver.noVersion);
            }
            List<String> Distinct = lstVersion.Distinct().ToList();
            return Distinct;
            //Cette fonction existe déjà
        }

        // Recherche une version avec l'ID d'édition et le numéro de version.
        public static VersionSysExp GetVersionSysExp(int _idEdition,string _noVersion)
        {
            VersionSysExp vSE = context.VersionSysExp.Where(x => x.idEdition == _idEdition && x.noVersion == _noVersion).First();
            
            return vSE;
        }
    }
}
