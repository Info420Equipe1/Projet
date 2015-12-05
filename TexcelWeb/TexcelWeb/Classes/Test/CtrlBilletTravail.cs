using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TexcelWeb.Classes.Personnel;

namespace TexcelWeb.Classes.Test
{
    public class CtrlBilletTravail : CtrlController
    {
        //Ajouter un billet de travail
        public static string AjouterBillet(string titreBillet, string dureeBillet, string dateCreationBillet, string dateLivraisonBillet, string testeurAssigneBillet, string statutBillet, string prioriteBillet, string dateTerminaisonBillet, string nomCasTest, string descBillet)
        {
            if (billetExist(titreBillet))
            {
                return "billetExiste";
            }

            //Creation du billet
            BilletTravail billet = new BilletTravail();

            //Ajout de l'Information
            billet.titreBilletTravail = titreBillet;
            billet.dureeBilletTravail = Convert.ToDouble(dureeBillet);
            billet.dateCreation = (Convert.ToDateTime(dateCreationBillet)).Date;
            
            if (dateLivraisonBillet != "")
            {
                billet.dateLivraison = (Convert.ToDateTime(dateLivraisonBillet)).Date;
            }
            if (testeurAssigneBillet != "Aucun")
	        {
                Employe emp = CtrlEmploye.getEmployeByName(testeurAssigneBillet);
                billet.Employe = emp;
	        }
            if (statutBillet != "")
	        {
                Statut statut = CtrlStatut.getStatutByName(statutBillet);
                billet.Statut = statut;
                if (statut.nomStatut == "Terminé")
                {
                    billet.dateFin = (Convert.ToDateTime(dateTerminaisonBillet)).Date;
                }
	        }
            if (prioriteBillet != "")
            {
                NiveauPriorite priorite = CtrlNivPriorite.getNiveauPrioriteByName(prioriteBillet);
                billet.NiveauPriorite = priorite;
            }

            CasTest casTestBillet = CtrlCasTest.GetCasTestByNom(nomCasTest);
            billet.CasTest = casTestBillet;
            billet.descBilletTravail = descBillet;


            try
            {
                Enregistrer(billet);
                return "billetajoute";
            }
            catch (Exception)
            {
                return "erreur";
            }
        }

        private static void Enregistrer(BilletTravail _billet)
        {
            //Ajouter un billet dans la BD
            context.BilletTravail.Add(_billet);
            context.SaveChanges();
        }

        //Retourne un billet à l'aide d'un id de billet
        public static BilletTravail getBilletById(int _id)
        {
            try
            {
                BilletTravail billet = context.BilletTravail.Where(x => x.idBilletTravail == _id).First();
                return billet;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //retourne une liste de tous les billets de travail
        public static List<BilletTravail> GetListBillet()
        {
            List<BilletTravail> lstBilletTravail = new List<BilletTravail>();

            foreach (BilletTravail billet in context.BilletTravail)
            {
                lstBilletTravail.Add(billet);
            }
            return lstBilletTravail;
        }

        //Verifier si le billet exist
        private static bool billetExist(string titreBillet)
        {
            foreach (BilletTravail billet in context.BilletTravail)
            {
                if (billet.titreBilletTravail == titreBillet)
                {
                    return true;
                }
            }
            return false;
        }

        //Retourne la longueur d'un champs
        public static int GetMaxLength<TEntity>(Expression<Func<TEntity, string>> property)
           where TEntity : BilletTravail
        {
            var adapter = (IObjectContextAdapter)context;
            ObjectContext objectContext = adapter.ObjectContext;

            var test = objectContext.MetadataWorkspace.GetItems(DataSpace.CSpace);

            if (test == null)
                return -1;

            Type entType = typeof(TEntity);
            string propertyName = ((MemberExpression)property.Body).Member.Name;

            var q = test
                .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                .SelectMany(meta => ((EntityType)meta).Properties
                .Where(p => p.Name == propertyName && p.TypeUsage.EdmType.Name == "String"));

            var queryResult = q.Where(p =>
            {
                var match = p.DeclaringType.Name == entType.Name;
                if (!match)
                    match = entType.Name == p.DeclaringType.Name;

                return match;

            })
                .Select(sel => sel.TypeUsage.Facets["MaxLength"].Value)
                .ToList();

            if (queryResult.Any())
            {
                int result = Convert.ToInt32(queryResult.First());
                return result;
            }
            return -1;
        }

        public static List<BilletTravail> GetLstBilletTravail(Employe _emp)
        {
            List<BilletTravail> lst = new List<BilletTravail>();
            //Billet selectionné
            foreach (BilletTravail bT in context.BilletTravail)
            {
                if (bT.noEmploye == _emp.noEmploye)
                {
                    lst.Add(bT);
                }
            }
            //Billets assigné
            foreach (BilletTravail bT in _emp.BilletTravail)
            {
                lst.Add(bT);
            }

            return lst;
	
        }

        public static BilletTravail GetBillet(string _nom)
        {
            try
            {
                BilletTravail billet = context.BilletTravail.Where(x => x.titreBilletTravail == _nom).First();
                return billet;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool SelectionneBillet(BilletTravail _bT, bool _verifChecked)
        {
            if (_verifChecked == true)
            {
                //Le testeur a choissi ce billet
                return true;
            }
            else
            {
                //Le testeur abandonne le billet
                return false;
            }
           
        }
    }
}