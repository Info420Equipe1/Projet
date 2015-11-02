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
        public static string Ajouter(string _nom, Int16 _nbEmp, string _desc, Employe _empChefEquipe, List<Employe> _listEmp, cProjet _proj)
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
                LierEmploye(_listEmp, equipe, _proj);
                return "L'équipe a été ajoutée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout de l'Équipe. Les données n'ont pas été enregistrées.";
            }
        }
        public static string Modifier(int idEquipe, string nomEquipe, Int16 nbTesteur, string commEquipe, Employe chefEquipe, List<Employe> lstTesteur)
        {
            Equipe equipe = getSelectedEquipe(idEquipe);
            equipe.nomEquipe = nomEquipe;
            equipe.nbTesteur = nbTesteur;
            equipe.descEquipe = commEquipe;
            equipe.Employe = chefEquipe;
            equipe.Employe1 = lstTesteur;

            try
            {
                context.SaveChanges();
                return "L'équipe a été modifiée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification de l'Équipe. Les données n'ont pas été enregistrées.";
            }
        }

        //Lier les employés à l'équipe
        private static void LierEmploye(List<Employe> _emp, Equipe _equipe, cProjet _proj)
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
