using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Texcel.Classes
{
    class CtrlAdmin : CtrlController
    {
        public static System.Data.Entity.DbSet<AllSysExp> GetAllSysExpView()
        {
            return context.AllSysExp;
        }
        public static System.Data.Entity.DbSet<AllPlateforme> GetAllPlateformeView()
        {
            return context.AllPlateforme;
        }
        public static System.Data.Entity.DbSet<cJeu> GetAllJeuView()
        {
            return context.tblJeu;
        }
        public static System.Data.Entity.DbSet<AllEquipe> GetAllEquipeView()
        {
            return context.AllEquipe;
        }
        public static System.Data.Entity.DbSet<Employe> GetAllEmployeView()
        {
            return context.tblEmploye;
        }
        public static System.Data.Entity.DbSet<AllTesteurs> GetAllTesteursView()
        {
            return context.AllTesteurs;
        }
        public static void refreshEntity()
        {
            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }
    }
}
