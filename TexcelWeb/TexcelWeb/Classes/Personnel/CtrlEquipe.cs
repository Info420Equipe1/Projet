using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Test;

namespace TexcelWeb.Classes.Personnel
{
    public class CtrlEquipe : CtrlController
    {
        public static Equipe getEquipeById(int _id)
        {
            Equipe selectedEquipe = context.tblEquipe.Where(x => x.idEquipe == _id).First();
            return selectedEquipe;
        }

        public static Equipe getEquipeByNomAndCodeProjet(string nomEquipe, string codeProjet)
        {
            Equipe selectedEquipe = context.tblEquipe.Where(x => x.nomEquipe == nomEquipe && x.codeProjet == codeProjet).First();
            return selectedEquipe;
        }

        public static string lierEquipeCasTest(Equipe equipe, List<string> casTest)
        {
            List<CasTest> lstCasTestEquipe = new List<CasTest>();

            foreach (string nomCasTest in casTest)
            {
                lstCasTestEquipe.Add(CtrlCasTest.GetCasTestByNom(nomCasTest));
            }

            equipe.CasTest = lstCasTestEquipe;
            try
            {
                context.SaveChanges();
                return "La liaison des cas de test pour l'équipe " + equipe.nomEquipe + " a été effectué avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la liaison des cas de test pour l'équipe " + equipe.nomEquipe + ". Les données n'ont pas été enregistrées.";
            }
        }

        //Retourne la liste des equipes pour un Projet en utilisant le codeProjet
        public static List<Equipe> lstEquipeByCodeProjet(string codeProjet)
        {
            List<Equipe> lstEquipe = new List<Equipe>();

            foreach (Equipe equipe in context.tblEquipe)
            {
                if (equipe.codeProjet == codeProjet)
                {
                    lstEquipe.Add(equipe);
                }
            }
            return lstEquipe;
        }

        //Retourne une liste de cas de test d'une equipe pour un projet
        public static List<CasTest> lstCasTestByEquipe(Equipe _equipe)
        {
            List<CasTest> lstCasTest = new List<CasTest>();

            foreach (CasTest casTest in _equipe.CasTest)
            {
                if (casTest.codeProjet == _equipe.codeProjet)
                {
                    lstCasTest.Add(casTest);
                }
            }
            return lstCasTest;
        }
    }
}