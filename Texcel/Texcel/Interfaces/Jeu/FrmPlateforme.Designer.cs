namespace Texcel.Interfaces.Jeu
{
    partial class frmPlateforme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlateforme));
            this.btnAjouter = new System.Windows.Forms.Button();
            this.grbSE = new System.Windows.Forms.GroupBox();
            this.pcbAjouterSE = new System.Windows.Forms.PictureBox();
            this.lblVersionSE = new System.Windows.Forms.Label();
            this.lblEditionSE = new System.Windows.Forms.Label();
            this.cmbVersionSE = new System.Windows.Forms.ComboBox();
            this.cmbEditionSE = new System.Windows.Forms.ComboBox();
            this.lblNomSE = new System.Windows.Forms.Label();
            this.cmbNomSE = new System.Windows.Forms.ComboBox();
            this.cmbNom = new System.Windows.Forms.ComboBox();
            this.cmbTypePlateforme = new System.Windows.Forms.ComboBox();
            this.lblTypePlateforme = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.rtbConfiguration = new System.Windows.Forms.RichTextBox();
            this.rtbCommentaire = new System.Windows.Forms.RichTextBox();
            this.lblConfiguration = new System.Windows.Forms.Label();
            this.lblCommentaire = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.grbSE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAjouterSE)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAjouter
            // 
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAjouter.FlatAppearance.BorderSize = 2;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.Black;
            this.btnAjouter.Location = new System.Drawing.Point(430, 542);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(125, 50);
            this.btnAjouter.TabIndex = 9;
            this.btnAjouter.Text = "&Enregistrer";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // grbSE
            // 
            this.grbSE.Controls.Add(this.pcbAjouterSE);
            this.grbSE.Controls.Add(this.lblVersionSE);
            this.grbSE.Controls.Add(this.lblEditionSE);
            this.grbSE.Controls.Add(this.cmbVersionSE);
            this.grbSE.Controls.Add(this.lblNomSE);
            this.grbSE.Controls.Add(this.cmbNomSE);
            this.grbSE.Controls.Add(this.cmbEditionSE);
            this.grbSE.Enabled = false;
            this.grbSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grbSE.Location = new System.Drawing.Point(16, 414);
            this.grbSE.Name = "grbSE";
            this.grbSE.Size = new System.Drawing.Size(670, 122);
            this.grbSE.TabIndex = 3;
            this.grbSE.TabStop = false;
            this.grbSE.Text = "Système d\'exploitation";
            // 
            // pcbAjouterSE
            // 
            this.pcbAjouterSE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbAjouterSE.Image = ((System.Drawing.Image)(resources.GetObject("pcbAjouterSE.Image")));
            this.pcbAjouterSE.Location = new System.Drawing.Point(614, 69);
            this.pcbAjouterSE.Name = "pcbAjouterSE";
            this.pcbAjouterSE.Size = new System.Drawing.Size(25, 25);
            this.pcbAjouterSE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbAjouterSE.TabIndex = 14;
            this.pcbAjouterSE.TabStop = false;
            this.pcbAjouterSE.Click += new System.EventHandler(this.pcbAjouterSE_Click);
            // 
            // lblVersionSE
            // 
            this.lblVersionSE.AutoSize = true;
            this.lblVersionSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionSE.Location = new System.Drawing.Point(414, 40);
            this.lblVersionSE.Name = "lblVersionSE";
            this.lblVersionSE.Size = new System.Drawing.Size(71, 20);
            this.lblVersionSE.TabIndex = 13;
            this.lblVersionSE.Text = "Version:";
            // 
            // lblEditionSE
            // 
            this.lblEditionSE.AutoSize = true;
            this.lblEditionSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditionSE.Location = new System.Drawing.Point(218, 40);
            this.lblEditionSE.Name = "lblEditionSE";
            this.lblEditionSE.Size = new System.Drawing.Size(65, 20);
            this.lblEditionSE.TabIndex = 12;
            this.lblEditionSE.Text = "Edition:";
            // 
            // cmbVersionSE
            // 
            this.cmbVersionSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVersionSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVersionSE.FormattingEnabled = true;
            this.cmbVersionSE.Location = new System.Drawing.Point(418, 69);
            this.cmbVersionSE.MaxLength = 30;
            this.cmbVersionSE.Name = "cmbVersionSE";
            this.cmbVersionSE.Size = new System.Drawing.Size(302, 28);
            this.cmbVersionSE.Sorted = true;
            this.cmbVersionSE.TabIndex = 7;
            this.cmbVersionSE.DropDown += new System.EventHandler(this.cmbVersionSE_DropDown);
            // 
            // cmbEditionSE
            // 
            this.cmbEditionSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEditionSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEditionSE.FormattingEnabled = true;
            this.cmbEditionSE.Location = new System.Drawing.Point(222, 69);
            this.cmbEditionSE.MaxLength = 50;
            this.cmbEditionSE.Name = "cmbEditionSE";
            this.cmbEditionSE.Size = new System.Drawing.Size(302, 28);
            this.cmbEditionSE.Sorted = true;
            this.cmbEditionSE.TabIndex = 6;
            this.cmbEditionSE.DropDown += new System.EventHandler(this.cmbEditionSE_DropDown);
            // 
            // lblNomSE
            // 
            this.lblNomSE.AutoSize = true;
            this.lblNomSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomSE.Location = new System.Drawing.Point(23, 40);
            this.lblNomSE.Name = "lblNomSE";
            this.lblNomSE.Size = new System.Drawing.Size(49, 20);
            this.lblNomSE.TabIndex = 9;
            this.lblNomSE.Text = "Nom:";
            // 
            // cmbNomSE
            // 
            this.cmbNomSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNomSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNomSE.FormattingEnabled = true;
            this.cmbNomSE.Location = new System.Drawing.Point(27, 69);
            this.cmbNomSE.MaxLength = 30;
            this.cmbNomSE.Name = "cmbNomSE";
            this.cmbNomSE.Size = new System.Drawing.Size(302, 28);
            this.cmbNomSE.Sorted = true;
            this.cmbNomSE.TabIndex = 5;
            this.cmbNomSE.DropDown += new System.EventHandler(this.cmbNomSE_DropDown);
            // 
            // cmbNom
            // 
            this.cmbNom.Enabled = false;
            this.cmbNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNom.FormattingEnabled = true;
            this.cmbNom.Location = new System.Drawing.Point(163, 116);
            this.cmbNom.MaxLength = 50;
            this.cmbNom.Name = "cmbNom";
            this.cmbNom.Size = new System.Drawing.Size(478, 28);
            this.cmbNom.Sorted = true;
            this.cmbNom.TabIndex = 2;
            this.cmbNom.DropDown += new System.EventHandler(this.cmbNom_DropDown);
            this.cmbNom.SelectedIndexChanged += new System.EventHandler(this.cmbNom_SelectedIndexChanged);
            this.cmbNom.TextUpdate += new System.EventHandler(this.cmbNom_TextUpdate);
            // 
            // cmbTypePlateforme
            // 
            this.cmbTypePlateforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypePlateforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypePlateforme.FormattingEnabled = true;
            this.cmbTypePlateforme.Location = new System.Drawing.Point(163, 82);
            this.cmbTypePlateforme.MaxLength = 30;
            this.cmbTypePlateforme.Name = "cmbTypePlateforme";
            this.cmbTypePlateforme.Size = new System.Drawing.Size(302, 28);
            this.cmbTypePlateforme.Sorted = true;
            this.cmbTypePlateforme.TabIndex = 1;
            this.cmbTypePlateforme.DropDown += new System.EventHandler(this.cmbTypePlateforme_DropDown);
            this.cmbTypePlateforme.SelectedIndexChanged += new System.EventHandler(this.cmbTypePlateforme_SelectedIndexChanged);
            // 
            // lblTypePlateforme
            // 
            this.lblTypePlateforme.AutoSize = true;
            this.lblTypePlateforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypePlateforme.Location = new System.Drawing.Point(25, 85);
            this.lblTypePlateforme.Name = "lblTypePlateforme";
            this.lblTypePlateforme.Size = new System.Drawing.Size(134, 20);
            this.lblTypePlateforme.TabIndex = 6;
            this.lblTypePlateforme.Text = "Type plateforme:";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(25, 119);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(49, 20);
            this.lblNom.TabIndex = 7;
            this.lblNom.Text = "Nom:";
            // 
            // rtbConfiguration
            // 
            this.rtbConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbConfiguration.Location = new System.Drawing.Point(163, 150);
            this.rtbConfiguration.Name = "rtbConfiguration";
            this.rtbConfiguration.Size = new System.Drawing.Size(522, 126);
            this.rtbConfiguration.TabIndex = 3;
            this.rtbConfiguration.Text = "";
            // 
            // rtbCommentaire
            // 
            this.rtbCommentaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCommentaire.Location = new System.Drawing.Point(163, 282);
            this.rtbCommentaire.Name = "rtbCommentaire";
            this.rtbCommentaire.Size = new System.Drawing.Size(522, 126);
            this.rtbCommentaire.TabIndex = 4;
            this.rtbCommentaire.Text = "";
            // 
            // lblConfiguration
            // 
            this.lblConfiguration.AutoSize = true;
            this.lblConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfiguration.Location = new System.Drawing.Point(25, 153);
            this.lblConfiguration.Name = "lblConfiguration";
            this.lblConfiguration.Size = new System.Drawing.Size(113, 20);
            this.lblConfiguration.TabIndex = 10;
            this.lblConfiguration.Text = "Configuration:";
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.AutoSize = true;
            this.lblCommentaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentaire.Location = new System.Drawing.Point(25, 285);
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(114, 20);
            this.lblCommentaire.TabIndex = 11;
            this.lblCommentaire.Text = "Commentaire:";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(561, 542);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 50);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSupprimer.FlatAppearance.BorderSize = 2;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btnSupprimer.Location = new System.Drawing.Point(299, 542);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(125, 50);
            this.btnSupprimer.TabIndex = 8;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Visible = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(25, 52);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(73, 20);
            this.lblNumero.TabIndex = 14;
            this.lblNumero.Text = "Numéro:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(163, 49);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 27);
            this.txtID.TabIndex = 0;
            // 
            // frmPlateforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(718, 611);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCommentaire);
            this.Controls.Add(this.cmbTypePlateforme);
            this.Controls.Add(this.lblConfiguration);
            this.Controls.Add(this.rtbCommentaire);
            this.Controls.Add(this.rtbConfiguration);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblTypePlateforme);
            this.Controls.Add(this.cmbNom);
            this.Controls.Add(this.grbSE);
            this.Controls.Add(this.btnAjouter);
            this.Name = "frmPlateforme";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Gestion des plateformes";
            this.Load += new System.EventHandler(this.frmPlateforme_Load);
            this.grbSE.ResumeLayout(false);
            this.grbSE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAjouterSE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.GroupBox grbSE;
        private System.Windows.Forms.ComboBox cmbNom;
        private System.Windows.Forms.ComboBox cmbTypePlateforme;
        private System.Windows.Forms.Label lblTypePlateforme;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.RichTextBox rtbConfiguration;
        private System.Windows.Forms.RichTextBox rtbCommentaire;
        private System.Windows.Forms.Label lblConfiguration;
        private System.Windows.Forms.Label lblCommentaire;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Label lblVersionSE;
        private System.Windows.Forms.Label lblEditionSE;
        private System.Windows.Forms.ComboBox cmbVersionSE;
        private System.Windows.Forms.ComboBox cmbEditionSE;
        private System.Windows.Forms.Label lblNomSE;
        private System.Windows.Forms.ComboBox cmbNomSE;
        private System.Windows.Forms.PictureBox pcbAjouterSE;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtID;
    }
}