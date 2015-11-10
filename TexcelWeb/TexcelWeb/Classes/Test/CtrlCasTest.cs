using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Test;

namespace TexcelWeb.Classes.Test
{
    public class CtrlCasTest : CtrlController
    {
        //Rechercher un Cas de test avec le CodeCasTest
        public static CasTest GetCasTestByCode(string codeCasTest)
        {
            return context.tblCasTest.Where(x => x.codeCasTest == codeCasTest).First();
        }

        //Ajouter lorsque il faut lier avec un projet et un type test
        public static bool Ajouter(string _code, string _nom, cProjet _proj, TypeTest _tT)
        {
            CasTest casTest = new CasTest();
            casTest.codeCasTest = _code;
            casTest.nomCasTest = _nom;
            casTest.idTypeTest = _tT.idTypeTest;
            casTest.codeProjet = _proj.codeProjet;

            try
            {
                context.tblCasTest.Add(casTest);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}