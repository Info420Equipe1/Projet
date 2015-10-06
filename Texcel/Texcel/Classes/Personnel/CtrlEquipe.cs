using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Personnel
{
    class CtrlEquipe: CtrlController
    {

        //Enregistré équipe
        public static void Ajouter(string _nom, Int16 _nbEmp, string _desc, List<Employe> _listEmp)
        {
            Equipe equipe = new Equipe();
            
            equipe.nomEquipe = _nom;
            equipe.nbTesteur = _nbEmp;

            context.tblEquipe.Add(equipe);
            context.SaveChanges();

            LierEmploye(_listEmp, equipe);
        }

        //Lier les employés à l'équipe
        private static void LierEmploye(List<Employe> _emp, Equipe _equipe)
        {
            foreach (Employe emp in _emp)
            {
                _equipe.Employe.Add(emp);
                context.SaveChanges();
            }
        }
    }
}
