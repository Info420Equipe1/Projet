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
        Utilisateur utilisateur;

        // Constructeur de la form avec l'utilisateur en paramètre
        public frmPassRenew(Utilisateur _utilisateur)
        {
            InitializeComponent();
            utilisateur = _utilisateur;  
        }

        // S'execute lorsque l'utilisateur appuit sur le bouton enregistrer
        private void btn_Click(object sender, EventArgs e)
        {
            if (txtPass1.Text == txtBoxPass2.Text)
            {
                try
                {
                    CtrlUtilisateur.ModifMotDePasse(utilisateur, txtPass1.Text);
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
