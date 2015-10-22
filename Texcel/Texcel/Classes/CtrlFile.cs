using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Texcel.Classes
{
    class CtrlFile
    {
        private static XmlDocument xmlDoc = new XmlDocument();
        

        public static bool IsEmpty()
        {
            xmlDoc.Load("NouveauxEmployes.xml");
            int count = xmlDoc.SelectNodes("NouveauxEmployes/Employe").Count;
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
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
    }
}
