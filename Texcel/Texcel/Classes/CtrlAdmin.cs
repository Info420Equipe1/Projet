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
        /*public static System.Data.Entity.DbSet<AllJeu> GetAllJeuView()
        {
            return context.AllPlateforme;
        }
        public static System.Data.Entity.DbSet<AllEquipe> GetAllEquipeView()
        {
            return context.AllPlateforme;
        }
        public static System.Data.Entity.DbSet<AllEmploye> GetAllEmployeView()
        {
            return context.AllPlateforme;
        }*/
    }
}
