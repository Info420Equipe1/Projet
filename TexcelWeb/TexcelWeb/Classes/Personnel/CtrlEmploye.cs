using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Personnel
{
    public class CtrlEmploye : CtrlController
    {
        
        public static Employe getEmployeById(int id)
        {
            Employe emp = context.tblEmploye.Where(x => x.noEmploye == id).First();
            return emp;
        }
        public static List<Employe> getLstChefProjet()
        {
            List<Employe> lstChefProjet = new List<Employe>();
            List<string> lstNomChefProjet = new List<string>();
            //dbContext.Database.Connection.Open();

            //Ajout dans la liste de tous les Employe qui ont comme groupe chef de Projet dans la BD
            foreach (Utilisateur user in context.tblUtilisateur)
            {
                foreach (Groupe groupe in user.Groupe)
	            {
		            if (groupe.idGroupe == 2)
                    {
                        lstNomChefProjet.Add(user.Employe.prenomEmploye + " " + user.Employe.nomEmploye);
                    }
	            }
                
            }
            foreach (cProjet Projet in context.tblProjet)
            {
                if (Projet.chefProjet != null)
                {
                    if (!lstNomChefProjet.Contains(Projet.chefProjet))
                    {
                        lstNomChefProjet.Add(Projet.chefProjet);
                    }
                }
            }
            foreach (Employe emp in context.tblEmploye)
            {
                foreach (string NomEmp in lstNomChefProjet)
                {
                    if (emp.prenomEmploye + " " + emp.nomEmploye == NomEmp)
                    {
                        lstChefProjet.Add(emp);
                    }
                }

            }
            //dbContext.Database.Connection.Close();
            return lstChefProjet;
        }
    }
}