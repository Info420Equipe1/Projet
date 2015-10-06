using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Jeu;

namespace Texcel.Interfaces.Jeu
{
    public partial class frmListeSysExp : frmForm
    {
        public frmListeSysExp()
        {
            InitializeComponent();
        }

        private void frmListeSysExp_Load(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = CtrlListeSysExp.GetSysExp();
            dgvSysExp.DataSource = bindingSource;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            //lstBoxSysExp.SelectedItem
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //lstBoxSysExp.SelectedItem
        }





    }
}
