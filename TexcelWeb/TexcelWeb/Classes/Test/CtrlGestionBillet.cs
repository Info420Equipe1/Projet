using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Personnel;

namespace TexcelWeb.Classes.Test
{
    public class CtrlGestionBillet
    {
        // Les choix des dropdownlist
        static cProjet ProjChoisi;
        static Equipe EquipChoisi;
        static Employe TesteurChoisi;
        static List<cProjet> lstProjAfficher;
        static List<Equipe> lstEquipeAfficher;
        static List<Employe> lstTesteurAfficher;


        // Mes accesseurs
        public static List<cProjet> getLstProj
        {
            get { return lstProjAfficher; }
        }
        public static List<Equipe> getLstEquipe
        {
            get { return lstEquipeAfficher; }
        }
        public static List<Employe> getLstTesteur
        {
            get { return lstTesteurAfficher; }
        }
        public static cProjet getProjChoisi
        {
            get { return ProjChoisi; }
        }
        public static Equipe getEquipChoisi
        {
            get { return EquipChoisi; }
        }
        public static Employe getTesteurChoisi
        {
            get { return TesteurChoisi; }
        }
      
        public static void SaveLstProjetAffiche()
        {
            try
            {
                lstProjAfficher = (CtrlController.GetCurrentUser()).Employe.cProjet.Cast<cProjet>().ToList();
                //lstProjAfficher = CtrlProjet.GetListProjetChefProjetByNoEmp(CtrlController.GetCurrentUser().noEmploye);
            }
            catch (Exception)
            {
              // erreur
            }
           
        }
        public static void SaveLstEquipeAffiche()
        {
            try
            {
                //lstEquipeAfficher = (List<Equipe>)ProjChoisi.Employe.Equipe1;
                lstEquipeAfficher = CtrlEquipe.lstEquipeByCodeProjet(ProjChoisi.codeProjet);
            }
            catch (Exception)
            {
                      //erreur          
            }
            
        }
        public static void SaveLstTesteurAffiche()
        {
            try
            {      
                lstTesteurAfficher = EquipChoisi.Employe1.Cast<Employe>().ToList();
            }
            catch (Exception)
            {
                //erreur          
            }
        }
        public static void SaveProjetChoisi(int _index)
        {
            ProjChoisi = lstProjAfficher.ElementAt(_index);
        }
        public static void SaveEquipeChoisi(int _index)
        {
            EquipChoisi = lstEquipeAfficher.ElementAt(_index);
        }
        public static void SaveEmployeChoisi()
        {

        }


    }
}