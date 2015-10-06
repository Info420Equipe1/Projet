using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Texcel.Classes
{
    class CtrlController
    {
        protected static dbProjetE1Entities context = new dbProjetE1Entities();


        public static void MessageWarnng(string _monWarning)
        {
            MessageBox.Show(_monWarning, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
