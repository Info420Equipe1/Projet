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
    }
}