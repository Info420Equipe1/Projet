using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.IO;

namespace Texcel.Classes.Personnel
{
    class CtrlFileEmployes
    {
        private static XmlDocument xmlDoc = new XmlDocument();
        
        public static int IsEmpty()
        {
            try
            {
                xmlDoc.Load("NouveauxEmployes.xml");
                int count = xmlDoc.SelectNodes("NouveauxEmployes/Employe").Count;
                return count;
            }
            catch (FileNotFoundException)
            {
                return -1;
            }       
        }

        public static List<Employe> GetEmployesFromFile()
        {
            List<Employe> employes = new List<Employe>();
            xmlDoc.Load("NouveauxEmployes.xml");
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                Employe employe = new Employe();
                employe.nomEmploye = node["Nom"].InnerText;
                employe.prenomEmploye = node["Prenom"].InnerText;
                employe.adressePostale = node["Adresse"].InnerText;
                employe.numTelPrincipal = node["TelPri"].InnerText;
                employe.numTelSecondaire = node["TelSec"].InnerText;
                employe.dateEmbauche = Convert.ToDateTime(node["DateEmbauche"].InnerText);
                employes.Add(employe);
            }
            return employes;
        }

        public static void DeleteEmployeFromFile(Employe _employe, int _index)
        {
            xmlDoc.Load("NouveauxEmployes.xml");
            XmlNodeList nodes = xmlDoc.SelectNodes("NouveauxEmployes/Employe");
            nodes[_index].ParentNode.RemoveChild(nodes[_index]);
            xmlDoc.Save("NouveauxEmployes.xml");
        }
    }
}
