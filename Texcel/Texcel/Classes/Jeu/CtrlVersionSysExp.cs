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
            return context.tblVersionSysExp.Count();
        }

        // On ajoute une nouvelle version dans la table tblVersionSysExp
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

        // Rechercher une version dans la table tblVersionSysExp
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

        // On enregistre dans la table le nouveau GenreJeu nouvellement ajouté
        private static bool Enregistrer(VersionSysExp _versionSysExp)
        {
            context.tblVersionSysExp.Add(_versionSysExp);
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

        public static List<String> RechercherpourListe(string _nomEdSysExp)
        {
            List<String> lstVersion = new List<String>();
            foreach (VersionSysExp ver in context.tblVersionSysExp.Where(x => x.EditionSysExp.nomEdition == _nomEdSysExp))
            {
                lstVersion.Add(ver.noVersion);
            }
            List<String> Distinct = lstVersion.Distinct().ToList();
            return Distinct;
            //Cette classe existe déjà
        }
    }
}
