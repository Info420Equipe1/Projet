using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Test;

namespace TexcelWeb.Classes.Test
{
    public class CtrlCasTest : CtrlController
    {
        

        //Ajouter lorsque il faut lier avec un projet et un type test
        public static bool Ajouter(string _code, string _nom, cProjet _proj, Difficulte _diff, NiveauPriorite _prio, DateTime _crea, DateTime _livr, TypeTest _tT, string _desc)
        {
            CasTest casTest = new CasTest();
            casTest.codeCasTest = _code;
            casTest.nomCasTest = _nom;
            casTest.codeProjet = _proj.codeProjet;
            casTest.idDiff = _proj.idVersion;
            casTest.idNivPri = _prio.idNivPri;
            casTest.dateCreation = _crea;
            casTest.dateLivraison = _livr;
            casTest.idTest = _tT.idTest;
            casTest.descCasTest = _desc;


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

        public static bool Modifier(string _code, string _nom, cProjet _proj, Difficulte _diff, NiveauPriorite _prio, DateTime _crea, DateTime _livr, TypeTest _tT, string _desc, CasTest _casTest)
        {
            _casTest.codeCasTest = _code;
            _casTest.nomCasTest = _nom;
            _casTest.codeProjet = _proj.codeProjet;
            _casTest.idDiff = _proj.idVersion;
            _casTest.idNivPri = _prio.idNivPri;
            _casTest.dateCreation = _crea;
            _casTest.dateLivraison = _livr;
            _casTest.idTest = _tT.idTest;
            _casTest.descCasTest = _desc;

            try
            {
                context.tblCasTest.Add(_casTest);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Rechercher un Cas de test avec le CodeCasTest
        public static CasTest GetCasTestByCode(string codeCasTest)
        {
            return context.tblCasTest.Where(x => x.codeCasTest == codeCasTest).First();
        }

        //Rechercher un Cas de test avec le NomCasTest
        public static CasTest GetCasTestByNom(string nomCasTest)
        {
            return context.tblCasTest.Where(x => x.nomCasTest == nomCasTest).First();
        }
    }
}