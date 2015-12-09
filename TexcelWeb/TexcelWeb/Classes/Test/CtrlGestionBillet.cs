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

        public static bool SaveProjetChoisi(int _index)
        {
            if (_index < lstProjAfficher.Count && _index >= 0)
            {
                ProjChoisi = lstProjAfficher.ElementAt(_index);
                return true;
            }
            else
            {
                ProjChoisi = null;
                return false;
            }
           
            
           
        }
        public static bool SaveEquipeChoisi(int _index)
        {
            if (_index < lstEquipeAfficher.Count && _index >= 0)
            {
                EquipChoisi = lstEquipeAfficher.ElementAt(_index);
                return true;
            }
            else
            {
                EquipChoisi = null;
                return false;
            }
        }
        public static bool SaveTesteurChoisi(int _index)
        {
            if (_index < lstTesteurAfficher.Count && _index >= 0)
            {
                TesteurChoisi = lstTesteurAfficher.ElementAt(_index);
                return true;
            }
            else
            {
                TesteurChoisi = null;
                return false;
            }
            
        }


    }
}