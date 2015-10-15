using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texcel.Classes;
using Texcel.Classes.Test;

namespace Texcel.Classes.Personnel
{
    class CtrlEmploye:CtrlController
    {
        public static string Ajouter(string _nomEmp, string _prenomEmp,string _adresseEmp, string _telPrimEmp,string _TelSecEmp, string _compPart, DateTime _dateEmbEmp)
        {
            //Nouvel employé
            Employe emp = new Employe();
            emp.nomEmploye = _nomEmp;
            emp.prenomEmploye = _prenomEmp;
            emp.adressePostale = _adresseEmp;
            emp.numTelPrincipal = _telPrimEmp;
            emp.numTelSecondaire = _TelSecEmp;
            emp.dateEmbauche = _dateEmbEmp;
            emp.competenceParticuliere = _compPart;

            

            try
            {
                context.tblEmploye.Add(emp);
                context.SaveChanges();
                LierTypeTest(emp);
                return "Le jeu a été ajouté avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout du Jeu. Les données n'ont pas été enregistrées.";
            }
        }

        public static string Modifier(string _nomEmp, string _prenomEmp,string _adresseEmp, string _telPrimEmp,string _TelSecEmp, string _compPart, DateTime _dateEmbEmp, Employe _emp)
        {
            Employe employe = _emp;
            employe.nomEmploye = _nomEmp;
            employe.prenomEmploye = _prenomEmp;
            employe.adressePostale = _adresseEmp;
            employe.numTelPrincipal = _telPrimEmp;
            employe.numTelSecondaire = _TelSecEmp;
            employe.dateEmbauche = _dateEmbEmp;
            employe.competenceParticuliere = _compPart;

            try
            {
                
                context.SaveChanges();
                LierTypeTest(employe);
                return "Le jeu a été modifié avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout du Jeu. Les données n'ont pas été enregistrées.";
            }
        }

        public static void LierTypeTest(Employe _emp)
        {
            foreach (KeyValuePair<TypeTest, int> typeTest in CtrlTypeTest.getlstTypeTestLstBox)
            {
                if (typeTest.Value == 1)
                {
                    _emp.TypeTest.Add(typeTest.Key);
                    context.SaveChanges();
                }
                else
                {
                    _emp.TypeTest.Remove(typeTest.Key);
                    context.SaveChanges();
                }
            }
        }

        //Liste des employées
        public static List<Employe> listEmploye()
        {
            List<Employe> listEmploye = new List<Employe>();

            foreach (Employe emp in context.tblEmploye)
            {
                listEmploye.Add(emp);
            }

            return listEmploye;
        }

        //Trouver un employé a l'aide de son nom et prenom
        public static Employe emp(string _nomPren)
        {
            Employe emp = context.tblEmploye.Where(x => x.nomEmploye + " " + x.prenomEmploye == _nomPren).First();
            
            return emp;
        }

        //Employés qui sont chef d'équipe
        public static List<Employe> listEmployeChefEquipe()
        {
            List<Employe> listEmp = new List<Employe>();
            foreach (Groupe gr in context.tblGroupe.Where(x => x.nomGroupe == "Chef d'équipe"))
            {
                foreach (Utilisateur uti in gr.Utilisateur)
                {
                    foreach (Employe emp in listEmploye())
                    {
                        if (emp.idEmploye == uti.idEmploye)
                        {
                            listEmp.Add(emp);
                        }
                    }
                }
            }

            return listEmp;
        }

    }
}
