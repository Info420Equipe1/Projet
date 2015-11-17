using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Test
{
    class CtrlCasTest : CtrlController
    {
        public static CasTest getCasTest(string _nom)
        {
            CasTest casTest = context.tblCasTest.Where(x => x.nomCasTest == _nom).First();
            return casTest;
        }
    }
}
