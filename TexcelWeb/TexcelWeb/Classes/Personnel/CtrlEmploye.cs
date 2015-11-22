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

            //Ajout dans la liste de tous les Employe qui ont comme groupe chef de Projet dans la BD
            foreach (Utilisateur user in context.tblUtilisateur)
            {
                foreach (Groupe groupe in user.Groupe)
	            {
		            if (groupe.idGroupe == 2)
                    {
                        lstNomChefProjet.Add(user.noEmploye.ToString());
                    }
	            }
                
            }
            foreach (cProjet projet in context.tblProjet)
            {
                if (projet.chefProjet != null)
                {
                    Employe chefEquipe = CtrlEmploye.getEmployeById(projet.chefProjet);
                    if (!lstNomChefProjet.Contains(chefEquipe.nomEmploye + ", " + chefEquipe.prenomEmploye))
                    {
                        lstNomChefProjet.Add(chefEquipe.nomEmploye + ", " + chefEquipe.prenomEmploye);
                    }
                }
            }
            foreach (Employe emp in context.tblEmploye)
            {
                foreach (string NomEmp in lstNomChefProjet)
                {
                    if (emp.noEmploye.ToString() == NomEmp)
                    {
                        lstChefProjet.Add(emp);
                    }
                }

            }
            return lstChefProjet;
        }
    }
}