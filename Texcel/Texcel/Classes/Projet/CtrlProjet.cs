using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
