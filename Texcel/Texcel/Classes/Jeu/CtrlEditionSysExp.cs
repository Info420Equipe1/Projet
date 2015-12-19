using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texcel.Classes.Jeu
{
    //
    //
    //Controle EditionSysExp
    //Cette classe contient toutes les méthodes et traitements en lien avec les éditions.
    //
    //
    class CtrlEditionSysExp : CtrlController
    {
        //Objet Edition global
        private static EditionSysExp editionSysExp;


        // Ajoute une nouvelle édition dans la table tblEditionSysExp, vérifie si elle existe et si l'ajout réussit. Retourne un booléen pour confirmer l'ajout.
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

        // Vérifie si l'édition existe.
        public static bool Verifier(SysExp sysExp, string _nomEdition)
        {
            if (Rechercher(sysExp, _nomEdition).Count != 0)
            {
                return true;    //lorsque l'edition existe  
            }
            return false;   // lorsque l'edition n'existe pas 
        }

        // Recherche une édition dans la table tblEditionSysExp.
        public static List<EditionSysExp> Rechercher(SysExp sysExp, string _nomEdition)
        {
            List<EditionSysExp> lstEditionSysExp = new List<EditionSysExp>();
            List<EditionSysExp> lstEditionSysExp2 = new List<EditionSysExp>();
            foreach (EditionSysExp editionSysExp in context.EditionSysExp.Where(x => x.nomEdition == _nomEdition))
            {
                if (editionSysExp.idSysExp == sysExp.idSysExp)
                {
                    lstEditionSysExp.Add(editionSysExp); 
                }
            }
            return lstEditionSysExp;
        }

        // Enregistre dans la table la nouvelle edition et retourne un booléen pour confirmer.
        private static bool Enregistrer(EditionSysExp _editionSysExp)
        {
            context.EditionSysExp.Add(_editionSysExp);
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

        // Recherche les éditions par nom et retourne une liste de celles-ci.
        public static List<EditionSysExp> RechercherpourListe(string _nomSysExp)
        {
            List<EditionSysExp> lstEdition = new List<EditionSysExp>();
            foreach (EditionSysExp plat in context.EditionSysExp.Where(x => x.SysExp.nomSysExp == _nomSysExp))
            {
                lstEdition.Add(plat);
            }
            return lstEdition;
        }

        // Recherche une édition avec l'ID du système d'exploitation auquel il est lié et son nom puis le retourne.
        public static EditionSysExp GetEditionSysExp(string _nomEdition, int _idSysExp)
        {
            EditionSysExp monEdition = context.EditionSysExp.Where(x => x.idSysExp == _idSysExp && x.nomEdition ==_nomEdition).First();
           return monEdition;
        }
      
    }
}
