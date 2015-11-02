using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Personnel
{
    public class CtrlUtilisateur : CtrlController
    {
        public static bool ValidationConnexion(string NomUtilisateur, string MotPasse)
        {
            //dbContext.Database.Connection.Open();
            foreach (Utilisateur user in context.tblUtilisateur)
            {
                if ((NomUtilisateur == user.nomUtilisateur) && (MotPasse == user.motPasse))
                {
                    //dbContext.Database.Connection.Close();
                    return true;
                }
            }
            //dbContext.Database.Connection.Close();
            return false;
        }
        public static List<Employe> getLstChefProjet()
        {
            List<Employe> lstChefProjet = new List<Employe>();
            List<string> lstNomChefProjet = new List<string>();
            //dbContext.Database.Connection.Open();
            foreach (Projet Projet in context.tblProjet)
	        {
		        lstNomChefProjet.Add(Projet.chefProjet);
	        }
            foreach (Employe emp in context.tblEmploye)
            {
                foreach (string NomEmp in lstNomChefProjet)
	            {
		            if (emp.nomEmploye == NomEmp)
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