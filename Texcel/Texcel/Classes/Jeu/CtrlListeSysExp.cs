using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Texcel.Classes.Jeu
{
    class CtrlListeSysExp : CtrlController
    {
        //Créer la liste des SysExp + Editions + version
        public static List<AllSysExp> GetSysExp()
        {
            /* var allSysExp = from sysExp in context.tblSysExp
                                           join edition in context.tblEditionSysExp
                                               on sysExp.idSysExp equals edition.idEdition into ed
                                           from p in ed.DefaultIfEmpty()
                                           join version in context.tblVersionSysExp
                                               on p.idEdition equals version.idEdition into ve
                                           from q in ve.DefaultIfEmpty()
                                           select new GetAllSysExp() { codeSysExp = sysExp.codeSysExp, commSysExp = sysExp.commSysExp, nomEdition = p.nomEdition, nomSysExp = sysExp.nomSysExp, noVersion = q.noVersion}; */

            List<AllSysExp> lstSysExp = context.AllSysExp.ToList();
            return lstSysExp;
            //return allSysExp.ToList();
        }
    }
}
