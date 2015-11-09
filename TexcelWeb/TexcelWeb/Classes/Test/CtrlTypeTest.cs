using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    public class CtrlTypeTest: CtrlController
    {
        public static List<TypeTest> GetLstTypeTest()
        {
            List<TypeTest> lstTypeTest = new List<TypeTest>();

            foreach (TypeTest tT in context.tblTypeTest)
            {
                lstTypeTest.Add(tT);
            }
            return lstTypeTest;
        }
    }
}