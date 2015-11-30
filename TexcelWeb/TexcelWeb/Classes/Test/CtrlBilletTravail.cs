﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    public class CtrlBilletTravail : CtrlController
    {
        //Ajouter un billet de travail
        public static string AjouterBillet(string titreBillet, string dureeBillet, string dateCreationBillet, string dateLivraisonBillet, string testeurAssigneBillet, string statutBillet, string prioriteBillet, string dateTerminaisonBillet, string descBillet)
        {
            if (billetExist(titreBillet))
            {
                return "billetExiste";
            }
            BilletTravail billet = new BilletTravail();

            //billet.titreBillet = titreBillet;

            DateTime date = DateTime.ParseExact(dureeBillet, "hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);
            //billet.dureeBilletTravail = date.ToString();

            billet.dateCreation = (Convert.ToDateTime(dateCreationBillet)).Date;

            if (dateLivraisonBillet != "")
            {
                billet.dateLivraison = (Convert.ToDateTime(dateLivraisonBillet)).Date;
            }
            if (testeurAssigneBillet != "")
	        {
                //Repair
		        //billet.noEmploye = thuglife
	        }
            if (statutBillet != "")
	        {
		        //+ DATE DE FIN SI STATUT = TERMINER
	        }

            //if (prioriteBillet)
            //{
            //    //Recherche Priorité
            //}

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
            context.tblBilletTravail.Add(_billet);
            context.SaveChanges();
        }

        //Retourne un billet à l'aide d'un id de billet
        public static BilletTravail getBilletById(int _id)
        {
            try
            {
                BilletTravail billet = context.tblBilletTravail.Where(x => x.idBilletTravail == _id).First();
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

            foreach (BilletTravail billet in context.tblBilletTravail)
            {
                lstBilletTravail.Add(billet);
            }
            return lstBilletTravail;
        }

        //Verifier si le billet exist
        private static bool billetExist(string titreBillet)
        {
            foreach (BilletTravail billet in context.tblBilletTravail)
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
    }
}