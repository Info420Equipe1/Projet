using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Personnel
{
    public class CtrlEmploye : CtrlController
    {
        
        public static Employe getEmployeById(int id)
        {
            Employe emp = context.tblEmploye.Where(x => x.noEmploye == id).First();
            return emp;
        }
    }
}