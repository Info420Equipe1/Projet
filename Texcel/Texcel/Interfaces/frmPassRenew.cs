using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Personnel;
using Texcel.Interfaces;

namespace Texcel
{
    public partial class frmPassRenew : Form
    {
        Utilisateur uti;
        
        public frmPassRenew(Utilisateur _uti)
        {
            InitializeComponent();
            uti = _uti;
           
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (txtPass1.Text == txtBoxPass2.Text)
            {
                try
                {
                    CtrlUtilisateur.ModifMotDePasse(uti, txtPass1.Text);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Une erreur est survenue lors de l'enregistrement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Le mot de passe ressaisi n'est pas indentique", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
