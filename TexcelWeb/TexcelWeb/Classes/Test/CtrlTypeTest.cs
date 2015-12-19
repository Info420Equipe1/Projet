using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    //
    //
    //Control Type Test
    //Cette classe contient tous les méthodes et traitements en lien avec les types de test.
    //
    //

    public class CtrlTypeTest: CtrlController
    {
        //Retourne la liste de tous les types de test disponible
        public static List<TypeTest> GetLstTypeTest()
        {
            List<TypeTest> lstTypeTest = new List<TypeTest>();

            foreach (TypeTest tT in context.TypeTest)
            {
                lstTypeTest.Add(tT);
            }
            return lstTypeTest;
        }

        //Retourne un type de test en fonction du nom
        public static TypeTest GetTypeTest(string _nomTypeTest)
        {
            TypeTest tT = context.TypeTest.Where(x => x.nomTest == _nomTypeTest).First();
            return tT;
        }
    }


}