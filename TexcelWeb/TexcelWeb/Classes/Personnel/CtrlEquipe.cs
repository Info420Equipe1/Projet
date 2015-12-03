using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;

namespace TexcelWeb.Classes.Personnel
{
    public class CtrlEquipe : CtrlController
    {
        public static Equipe getEquipeById(int _id)
        {
            Equipe selectedEquipe = context.Equipe.Where(x => x.idEquipe == _id).First();
            return selectedEquipe;
        }

        public static Equipe getEquipeByNomAndCodeProjet(string nomEquipe, string codeProjet)
        {
            Equipe selectedEquipe = context.Equipe.Where(x => x.nomEquipe == nomEquipe && x.codeProjet == codeProjet).First();
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
                return "liaisonCasTestReussi";
            }
            catch (Exception)
            {
                return "liaisonCasTestEchoue";
            }
        }

        public static string removeCasTestEquipe(Equipe equipe)
        {
            equipe.CasTest = null;
            try
            {
                context.SaveChanges();
                return "liaisonCasTestNullReussi";
            }
            catch (Exception)
            {
                return "liaisonCasTestNullEchoue";
            }
        }
        //Retourne la liste des equipes pour un Projet en utilisant le codeProjet
        public static List<Equipe> lstEquipeByCodeProjet(string codeProjet)
        {
            List<Equipe> lstEquipe = new List<Equipe>();

            foreach (Equipe equipe in context.Equipe)
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

        //Retourne une liste de projet pour un chef d'équipe
        public static List<cProjet> lstProjetByChefEquipe(string _nomChefEquipe)
        {
            List<cProjet> lstProjet = new List<cProjet>();

            foreach (cProjet projet in CtrlProjet.GetListProjet())
            {
                foreach (CasTest castest in projet.CasTest)
                {
                    foreach (Equipe equipe in castest.Equipe)
                    {
                        if ((equipe.Employe.prenomEmploye+" "+equipe.Employe.nomEmploye) == _nomChefEquipe)
                        {
                            if (!lstProjet.Contains(projet))
                            {
                                lstProjet.Add(projet);
                            }
                        }
                    }
                }
            }
            return lstProjet;
        }
    }
}