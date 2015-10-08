using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texcel.Classes.Test;

namespace Texcel.Classes.Test
{
    class CtrlTypeTest : CtrlController
    {
        private static Dictionary<TypeTest, int> lstTypeTestLstBox = new Dictionary<TypeTest, int>();

        public static  Dictionary<TypeTest, int> getlstTypeTestLstBox
        {
            get { return lstTypeTestLstBox; }
            
        }
             
        public static void  PopulateLstTypeTest()
        {
            lstTypeTestLstBox.Clear();
            foreach (TypeTest tT in context.tblTypeTest)
            {
                lstTypeTestLstBox.Add(tT, 0);
            }   
        }

        // Pour charger les infos quand l'employé existe
        public static void PopulateLstTypeTest(Employe _emp)
        {
            lstTypeTestLstBox.Clear();

            // Mettre une 1 dans le dictionnary_value si L'employé possède le typetest
           
           
        }
        // on change la value dans le dictionnaire pour la déplacer dans l'autre list
        public static Dictionary<TypeTest, int> ModifierLstBox(TypeTest _tT,bool _option)
        {
            // si option est true sa veut dire qu'on veut ajouter à l'employé
            if (_option)
            {
                lstTypeTestLstBox[_tT] = 1; 
            }
            else
            {
                lstTypeTestLstBox[_tT] = 0;
            }
           
            return lstTypeTestLstBox;
        }

       
        // Rechercher un type de test avec un string
        public static TypeTest GetTypeTest(string _nomTypeTest)
        {
            TypeTest monTT = context.tblTypeTest.Where(x => x.nomTest == _nomTypeTest).First();

            return monTT;      
        }


        //Rechercher les types test associé a un employé
        public static List<TypeTest> lstTypeTestAssEmp(Employe _emp)
        {
            List<TypeTest> lstTypTest = new List<TypeTest>();
            foreach (TypeTest typTes in _emp.TypeTest)
            {
                lstTypTest.Add(typTes);
            }

            return lstTypTest;
        }

        //Liste de tous les types test
        public static List<TypeTest> lstTypeTest()
        {
            List<TypeTest> lstTypTest = new List<TypeTest>();

            foreach (TypeTest typTest in context.tblTypeTest)
            {
                lstTypTest.Add(typTest);
            }
            return lstTypTest;
        }
    }
}
