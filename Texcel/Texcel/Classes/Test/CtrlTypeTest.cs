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
            bool yo = true;
            // Mettre une 1 dans le dictionnary_value si L'employé possède le typetest
            foreach (TypeTest tTAll in lstTypeTest())
            {
                yo = false;
                foreach (TypeTest tT in lstTypeTestAssEmp(_emp))
                {
                    if (tTAll == tT)
                    {
                        lstTypeTestLstBox.Add(tT, 1);
                        yo = true;
                    }
                }
                if (yo == false)
                {
                    lstTypeTestLstBox.Add(tTAll, 0);
                }
            }
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
            TypeTest monTT = context.tblTypeTest.Where(x => x.nomTypeTest == _nomTypeTest).First();

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

        public static bool Verifier(string _nom)
        {
            foreach (TypeTest tT in context.tblTypeTest)
            {
                if (tT.nomTypeTest == _nom)
                {
                    return true;
                }
            }
            return false;
        }

        public static string Ajouter(string _nom, string _com)
        {
            TypeTest typeTest = new TypeTest();
            typeTest.nomTypeTest = _nom;
            typeTest.descTypeTest = _com;

            try
            {
                context.tblTypeTest.Add(typeTest);
                context.SaveChanges();
                return "Le type test a été créé";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout du Type de test. Les données n'ont pas été enregistrées.";
            }
        }

        public static string Modifier(string _nom, string _com)
        {
            TypeTest typeTest = GetTypeTest(_nom);
            typeTest.descTypeTest = _com;

            try
            {
                context.SaveChanges();
                return "Le type de test a été modifié avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification du Type de test. Les données n'ont pas été enregistrées.";
            }
        }
    }
}
