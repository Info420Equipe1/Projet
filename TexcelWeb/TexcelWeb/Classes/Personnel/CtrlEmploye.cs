using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Personnel
{
    //
    //
    //Control Employe
    //Cette classe contient tous les méthodes et traitements en lien avec les employes.
    //
    //

    public class CtrlEmploye : CtrlController
    {
        //Retourne un Employe à l'aide d'un ID
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

        //Retourne la liste de tous les chefs de projet
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

        //Retourne la liste des employes
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

    }
}