namespace Texcel.Interfaces.Personnel
{
    partial class frmEmployeRecu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvNouveauxEmployes = new System.Windows.Forms.DataGridView();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telPri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telSec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEmbauche = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNouveauxEmployes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNouveauxEmployes
            // 
            this.dgvNouveauxEmployes.AllowUserToAddRows = false;
            this.dgvNouveauxEmployes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNouveauxEmployes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNouveauxEmployes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.nom,
            this.prenom,
            this.adresse,
            this.telPri,
            this.telSec,
            this.dateEmbauche});
            this.dgvNouveauxEmployes.Location = new System.Drawing.Point(12, 23);
            this.dgvNouveauxEmployes.MultiSelect = false;
            this.dgvNouveauxEmployes.Name = "dgvNouveauxEmployes";
            this.dgvNouveauxEmployes.RowTemplate.Height = 24;
            this.dgvNouveauxEmployes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNouveauxEmployes.Size = new System.Drawing.Size(1026, 558);
            this.dgvNouveauxEmployes.TabIndex = 4;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSupprimer.FlatAppearance.BorderSize = 2;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btnSupprimer.Location = new System.Drawing.Point(651, 598);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(125, 50);
            this.btnSupprimer.TabIndex = 1;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAnnuler.FlatAppearance.BorderSize = 2;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.Black;
            this.btnAnnuler.Location = new System.Drawing.Point(913, 598);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(125, 50);
            this.btnAnnuler.TabIndex = 3;
            this.btnAnnuler.Text = "A&nnuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAjouter.FlatAppearance.BorderSize = 2;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.Black;
            this.btnAjouter.Location = new System.Drawing.Point(782, 598);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(125, 50);
            this.btnAjouter.TabIndex = 2;
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // numero
            // 
            this.numero.HeaderText = "Num.Employe";
            this.numero.Name = "numero";
            // 
            // nom
            // 
            this.nom.HeaderText = "Nom";
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // prenom
            // 
            this.prenom.HeaderText = "Prenom";
            this.prenom.Name = "prenom";
            this.prenom.ReadOnly = true;
            // 
            // adresse
            // 
            this.adresse.HeaderText = "Adresse";
            this.adresse.Name = "adresse";
            this.adresse.ReadOnly = true;
            // 
            // telPri
            // 
            this.telPri.HeaderText = "Tel. Primaire";
            this.telPri.Name = "telPri";
            this.telPri.ReadOnly = true;
            // 
            // telSec
            // 
            this.telSec.HeaderText = "Tel.Secondaire";
            this.telSec.Name = "telSec";
            this.telSec.ReadOnly = true;
            // 
            // dateEmbauche
            // 
            this.dateEmbauche.HeaderText = "Date Embauche";
            this.dateEmbauche.Name = "dateEmbauche";
            this.dateEmbauche.ReadOnly = true;
            // 
            // frmEmployeRecu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 662);
            this.Controls.Add(this.dgvNouveauxEmployes);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAjouter);
            this.Name = "frmEmployeRecu";
            this.Text = "Employés à ajouter";
            this.Load += new System.EventHandler(this.frmEmployeRecu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNouveauxEmployes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.DataGridView dgvNouveauxEmployes;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn telPri;
        private System.Windows.Forms.DataGridViewTextBoxColumn telSec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEmbauche;
    }
}