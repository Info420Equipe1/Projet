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

        public static Equipe getEquipeByNom(string _nom)
        {
            Equipe selectedEquipe = context.tblEquipe.Where(x => x.nomEquipe == _nom).First();
            return selectedEquipe;
        }

        public static void lierEquipeCasTest(string nomEquipe, List<string> casTest)
        {
            List<CasTest> lstCasTestEquipe = new List<CasTest>();

            foreach (string nomCasTest in casTest)
            {
                lstCasTestEquipe.Add(CtrlCasTest.GetCasTestByNom(nomCasTest));
            }

            //Equipe equipe = CtrlEquipe.getEquipeById();
        }
    }
}