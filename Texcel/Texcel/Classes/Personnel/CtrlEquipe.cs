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
        public static string Ajouter(string _nom, Int16 _nbEmp, string _desc, Employe _empChefEquipe, List<Employe> _listEmp)
        {
            Equipe equipe = new Equipe();
            
            equipe.nomEquipe = _nom;
            equipe.nbTesteur = _nbEmp;
            equipe.idChefEquipe = _empChefEquipe.idEmploye;
            equipe.descEquipe = _desc;

            try
            {
                context.tblEquipe.Add(equipe);
                context.SaveChanges();
                LierEmploye(_listEmp, equipe);
                return "Équipe créé";
            }
            catch (Exception)
            {
                return "Une erreur c'est produite";
            }
        }

        //Lier les employés à l'équipe
        private static void LierEmploye(List<Employe> _emp, Equipe _equipe)
        {
            foreach (Employe emp in _emp)
            {
                _equipe.Employe1.Add(emp);
                context.SaveChanges();
            }
        }
        public static Equipe getSelectedEquipe(int _id)
        {
            Equipe selectedEquipe = context.tblEquipe.Where(x => x.idEquipe == _id).First();
            return selectedEquipe;
        }
    }
}
