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
    //
    //
    //Control Gestion Billet
    //Cette classe contient tous les méthodes et traitements en lien avec la gestion de billet.
    //
    //
    public class CtrlGestionBillet : CtrlController
    {
        // Les choix des dropdownlist
        private static cProjet ProjChoisi;
        private static Equipe EquipChoisi;
        private static Employe TesteurChoisi;
        private static List<cProjet> lstProjAfficher;
        private static List<Equipe> lstEquipeAfficher;
        private static List<Employe> lstTesteurAfficher;

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
                lstProjAfficher = CtrlEquipe.lstProjetByChefEquipe(CtrlController.GetCurrentUser().noEmploye);
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void SaveLstEquipeAffiche()
        {
            try
            {
                lstEquipeAfficher = CtrlEquipe.lstEquipeByCodeProjet(ProjChoisi.codeProjet);
            }
            catch (Exception)
            {
                return;         
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
                return;        
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

        public static void SaveAllBilletsTravail()
        {
            context.SaveChanges();
        }
    }
}