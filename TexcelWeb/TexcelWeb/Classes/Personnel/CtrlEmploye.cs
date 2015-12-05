using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Personnel
{
    public class CtrlEmploye : CtrlController
    {
        
        public static Employe getEmployeById(string id)
        {
            Employe emp = context.Employe.Where(x => x.noEmploye == id).First();
            return emp;
        }

        //Retourne un employe a l'aide de son nom complet
        public static Employe getEmployeByName(string _nomEmp)
        {
            Employe emp = context.Employe.Where(x => x.prenomEmploye + " " + x.nomEmploye == _nomEmp).First();
            return emp;
        }
        //Retourne un id d'employe a l'aide de son nom complet
        public static string getIdEmploye(string _nomEmp)
        {
            Employe emp = context.Employe.Where(x => x.prenomEmploye + " " + x.nomEmploye == _nomEmp).First();
            return emp.noEmploye;
        }

        public static List<Employe> getLstChefProjet()
        {
            List<Employe> lstChefProjet = new List<Employe>();

            //Ajout dans la liste de tous les Employe qui ont comme groupe chef de Projet dans la BD
            foreach (Utilisateur user in context.Utilisateur)
            {
                foreach (Groupe groupe in user.Groupe)
	            {
		            if (groupe.idGroupe == 2)
                    {
                        Employe chefProjet = CtrlEmploye.getEmployeById(user.noEmploye);
                        lstChefProjet.Add(chefProjet);
                    }
	            }             
            }
            return lstChefProjet;
        }
        public static List<Employe> getLstTesteur()
        {
            List<Employe> lstTesteur = new List<Employe>();

            //Ajout dans la liste de tous les Employe qui ont comme groupe chef de Projet dans la BD
            foreach (Utilisateur user in context.Utilisateur)
            {
                foreach (Groupe groupe in user.Groupe)
                {
                    if (groupe.idGroupe == 4)
                    {
                        Employe testeur = CtrlEmploye.getEmployeById(user.noEmploye);
                        lstTesteur.Add(testeur);
                    }
                }
            }
            return lstTesteur;
        }

        //public static List<Employe> getLstTesteurByEquipe(string _idEquipe)
        //{
        //    List<cProjet> lstProjet = new List<cProjet>();

        //    Equipe monEquipe = CtrlEmploye.getEmployeById(_idEquipe);

        //    foreach (cProjet proj in chefProjet.cProjet)
        //    {
        //        lstProjet.Add(proj);
        //    }

        //    return lstProjet;
        //}




    }
}