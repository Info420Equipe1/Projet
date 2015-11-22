using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TexcelWeb.Classes.Personnel
{
    public class CtrlUtilisateur : CtrlController
    {
        public static bool VerifPremiereConn(Utilisateur _uti)
        {
            if (_uti.premierLogin == 0)
            {
                return true;
            }
            return false;
        }

        public static bool VerifApres6Mois(Utilisateur _uti)
        {

            DateTime now = DateTime.Now;
            DateTime timeAfter6 = Convert.ToDateTime(_uti.dateDernModif).AddMonths(6);
            if (now >= timeAfter6)
            {
                return true;
            }
            return false;
        }

        //Modifier mot de passe
        public static void ModifMotDePasse(Utilisateur _uti, string _motPasse)
        {
            _uti.motPasse = _motPasse;
            _uti.premierLogin = 1;
            _uti.dateDernModif = DateTime.Now;
            context.SaveChanges();
        }

        public static Utilisateur getUtilisateur(string _nomUti)
        {
            Utilisateur uti = context.tblUtilisateur.Where(x => x.nomUtilisateur == _nomUti).First();

            return uti;
        }

        public static int GetMaxLength<TEntity>(Expression<Func<TEntity, string>> property)
           where TEntity : Utilisateur
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