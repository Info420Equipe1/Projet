using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Projet;

namespace TexcelWeb.Classes.Test
{
    public class CtrlGestionBillet
    {
        // Les choix des dropdownlist
        static cProjet ProjChoisi;
        static Equipe EquipChoisi;
        static Employe EmpChoisi;
        static List<cProjet> lstProjAfficher;
        static List<Equipe> lstEquipeAfficher;
        static List<Employe> lstEmpAfficher;


        // Mes accesseurs
        public static List<cProjet> getLstProj
        {
            get { return lstProjAfficher; }
        }
        public static List<Equipe> getLstEquipe
        {
            get { return lstEquipeAfficher; }
        }
        public static List<Employe> getLstEmpl
        {
            get { return lstEmpAfficher; }
        }
        public static cProjet getProjChoisi
        {
            get { return ProjChoisi; }
        }
        public static Equipe getEquipChoisi
        {
            get { return EquipChoisi; }
        }
        public static Employe getEmpChoisi
        {
            get { return EmpChoisi; }
        }
      
        public static void SaveLstProjetAffiche()
        {
            lstProjAfficher = CtrlProjet.GetListProjetChefProjetByNoEmp(CtrlController.GetCurrentUser().noEmploye);
        }
        public static void SaveLstEquipeAffiche()
        {

        }
        public static void SaveLstEmployeAffiche()
        {

        }
        public static void SaveProjetChoisi(int _index)
        {
            ProjChoisi = lstProjAfficher.ElementAt(_index);
        }
        public static void SaveEquipeChoisi()
        {

        }
        public static void SaveEmployeChoisi()
        {

        }


    }
}