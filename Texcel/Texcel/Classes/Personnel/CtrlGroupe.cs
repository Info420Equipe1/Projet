using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Texcel.Classes.Personnel
{
    class CtrlGroupe : CtrlController
    {
        public static List<Groupe> GetAllGroupe()
        {
            List<Groupe> lstAllGroupe = new List<Groupe>();

            foreach (Groupe groupe in context.tblGroupe)
            {
                lstAllGroupe.Add(groupe);
            }
            return lstAllGroupe;
        }
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
