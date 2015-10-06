using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texcel.Classes.Jeu
{
    class CtrlEditionSysExp : CtrlController
    {
        private static EditionSysExp editionSysExp;

        // Obtenir le nombre d'itération dans la table tblEditionSysExp
        public static int GetCount()
        {
            return context.tblEditionSysExp.Count();
        }

        // On ajoute une nouvelle edition dans la table tblEditionSysExp
        public static bool Ajouter(SysExp _sysExp, string _nomEdition)
        {
            if (!Verifier(_sysExp, _nomEdition) && _nomEdition != "")
            {
                editionSysExp = new EditionSysExp();
                editionSysExp.nomEdition = _nomEdition;
                editionSysExp.idSysExp = _sysExp.idSysExp;
                return Enregistrer(editionSysExp);
            }
            return false;
        }

        public static bool Verifier(SysExp sysExp, string _nomEdition)
        {
            if (Rechercher(sysExp, _nomEdition).Count != 0)
            {
                return true;    //lorsque l'edition existe  
            }
            return false;   // lorsque l'edition n'existe pas 
        }

        // Rechercher une edition dans la table tblEditionSysExp
        public static List<EditionSysExp> Rechercher(SysExp sysExp, string _nomEdition)
        {
            List<EditionSysExp> lstEditionSysExp = new List<EditionSysExp>();
            List<EditionSysExp> lstEditionSysExp2 = new List<EditionSysExp>();
            foreach (EditionSysExp editionSysExp in context.tblEditionSysExp.Where(x => x.nomEdition == _nomEdition))
            {
                if (editionSysExp.idSysExp == sysExp.idSysExp)
                {
                    lstEditionSysExp.Add(editionSysExp); 
                }
            }
            return lstEditionSysExp;
        }

        /*public static List<EditionSysExp> RechercherSysExp(string _nomSysExp)
        {
            List<EditionSysExp> lstEditionSysExp = new List<EditionSysExp>();
            foreach (EditionSysExp editionSysExp in context.tblEditionSysExp.Where(x => x.SysExp.nomSysExp == _nomSysExp))
            {
                lstEditionSysExp.Add(editionSysExp);
            }
            return lstEditionSysExp;
        }*/

        // On enregistre dans la table la nouvelle edition
        private static bool Enregistrer(EditionSysExp _editionSysExp)
        {
            context.tblEditionSysExp.Add(_editionSysExp);
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                MessageBox.Show("Une erreur est survenue lors de l'ajout de l'édition du Système d'Exploitation. Les données n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static List<EditionSysExp> RechercherpourListe(string _nomSysExp)
        {
            List<EditionSysExp> lstEdition = new List<EditionSysExp>();
            foreach (EditionSysExp plat in context.tblEditionSysExp.Where(x => x.SysExp.nomSysExp == _nomSysExp))
            {
                lstEdition.Add(plat);
            }
            return lstEdition;
            //Cette classe existe déjà
        }
      
    }
}
