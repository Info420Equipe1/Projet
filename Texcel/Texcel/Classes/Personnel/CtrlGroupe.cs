using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Texcel.Classes.Personnel
{
    //
    //
    //Control Groupe
    //Cette classe contient tous les méthodes et traitements en lien avec les groupes
    //
    //

    class CtrlGroupe : CtrlController
    {
        //Retourne la liste de tous les groupes de l'application
        public static List<Groupe> GetAllGroupe()
        {
            List<Groupe> lstAllGroupe = new List<Groupe>();

            foreach (Groupe groupe in context.Groupe)
            {
                lstAllGroupe.Add(groupe);
            }
            return lstAllGroupe;
        }

        //Retourne un groupe en fonction d'un nom
        public static Groupe GetGroupByName(string groupeName)
        {
            Groupe groupeResult = new Groupe();
            foreach (Groupe groupe in CtrlGroupe.GetAllGroupe())
            {
                if (groupe.nomGroupe == groupeName)
                {
                    groupeResult = groupe;
                }
            }
            return groupeResult;
        }
    }
}
