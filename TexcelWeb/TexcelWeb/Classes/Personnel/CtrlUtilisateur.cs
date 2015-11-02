using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Personnel
{
    public class CtrlUtilisateur : CtrlController
    {
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