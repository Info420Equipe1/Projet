using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texcel.Classes.Projet;

namespace Texcel.Classes.Projet
{
    class CtrlProjet: CtrlController
    {
        //Retourne un Nom de projet à partir d'un code projet
        public static string getNomProjet(string codeProjet)
        {
            cProjet projet = context.tblProjet.Where(x => x.codeProjet == codeProjet).First();
            return projet.nomProjet;
        }

        public static cProjet getProjet(string _nom)
        {
            cProjet projet = context.tblProjet.Where(x => x.nomProjet == _nom).First();
            return projet;
        }

        public static List<cProjet> listDeProjet()
        {
            List<cProjet> listProjet = new List<cProjet>();

            foreach (cProjet proj in context.tblProjet)
            {
                listProjet.Add(proj);
            }

            return listProjet;
        }
    }
}
