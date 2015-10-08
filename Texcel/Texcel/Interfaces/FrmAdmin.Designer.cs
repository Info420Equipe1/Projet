namespace Texcel.Interfaces
{
    partial class frmAdmin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFiltre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRechercher = new System.Windows.Forms.TextBox();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.smiFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.smiQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.smiGestionJeu = new System.Windows.Forms.ToolStripMenuItem();
            this.smiSysExp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.smiTypePlateforme = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPlateforme = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.smiTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.smiGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.smiClassification = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.smiJeu = new System.Windows.Forms.ToolStripMenuItem();
            this.smiGestionPersonnel = new System.Windows.Forms.ToolStripMenuItem();
            this.smiEmploye = new System.Windows.Forms.ToolStripMenuItem();
            this.smiEquipe = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvResultats = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.mnsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultats)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(707, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 607);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRechercher
            // 
            this.btnRechercher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercher.Location = new System.Drawing.Point(1120, 47);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(121, 28);
            this.btnRechercher.TabIndex = 5;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(707, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filtre:";
            // 
            // cmbFiltre
            // 
            this.cmbFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltre.FormattingEnabled = true;
            this.cmbFiltre.Items.AddRange(new object[] {
            "Employé",
            "Équipe",
            "Jeu",
            "Plateforme",
            "Système d\'exploitation"});
            this.cmbFiltre.Location = new System.Drawing.Point(762, 47);
            this.cmbFiltre.Name = "cmbFiltre";
            this.cmbFiltre.Size = new System.Drawing.Size(352, 28);
            this.cmbFiltre.Sorted = true;
            this.cmbFiltre.TabIndex = 3;
            this.cmbFiltre.SelectedIndexChanged += new System.EventHandler(this.cmbFiltre_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rechercher:";
            // 
            // txtRechercher
            // 
            this.txtRechercher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRechercher.Location = new System.Drawing.Point(119, 48);
            this.txtRechercher.Name = "txtRechercher";
            this.txtRechercher.Size = new System.Drawing.Size(579, 27);
            this.txtRechercher.TabIndex = 1;
            // 
            // mnsMain
            // 
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiFichier,
            this.smiGestionJeu,
            this.smiGestionPersonnel});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(1253, 28);
            this.mnsMain.TabIndex = 8;
            this.mnsMain.Text = "menuStrip1";
            // 
            // smiFichier
            // 
            this.smiFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiQuitter});
            this.smiFichier.Name = "smiFichier";
            this.smiFichier.Size = new System.Drawing.Size(64, 24);
            this.smiFichier.Text = "&Fichier";
            // 
            // smiQuitter
            // 
            this.smiQuitter.Name = "smiQuitter";
            this.smiQuitter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.smiQuitter.Size = new System.Drawing.Size(173, 24);
            this.smiQuitter.Text = "&Quitter";
            this.smiQuitter.Click += new System.EventHandler(this.smiQuitter_Click);
            // 
            // smiGestionJeu
            // 
            this.smiGestionJeu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiSysExp,
            this.toolStripMenuItem1,
            this.smiTypePlateforme,
            this.smiPlateforme,
            this.toolStripMenuItem2,
            this.smiTheme,
            this.smiGenre,
            this.smiClassification,
            this.toolStripMenuItem3,
            this.smiJeu});
            this.smiGestionJeu.Name = "smiGestionJeu";
            this.smiGestionJeu.Size = new System.Drawing.Size(129, 24);
            this.smiGestionJeu.Text = "&Gestion des jeux";
            // 
            // smiSysExp
            // 
            this.smiSysExp.Name = "smiSysExp";
            this.smiSysExp.Size = new System.Drawing.Size(229, 24);
            this.smiSysExp.Text = "&Système d\'exploitation";
            this.smiSysExp.Click += new System.EventHandler(this.SmiSysExp_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(226, 6);
            // 
            // smiTypePlateforme
            // 
            this.smiTypePlateforme.Name = "smiTypePlateforme";
            this.smiTypePlateforme.Size = new System.Drawing.Size(229, 24);
            this.smiTypePlateforme.Text = "&Type de plateforme";
            this.smiTypePlateforme.Click += new System.EventHandler(this.SmiTypePlateforme_Click);
            // 
            // smiPlateforme
            // 
            this.smiPlateforme.Name = "smiPlateforme";
            this.smiPlateforme.Size = new System.Drawing.Size(229, 24);
            this.smiPlateforme.Text = "&Plateforme";
            this.smiPlateforme.Click += new System.EventHandler(this.SmiPlateforme_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(226, 6);
            // 
            // smiTheme
            // 
            this.smiTheme.Name = "smiTheme";
            this.smiTheme.Size = new System.Drawing.Size(229, 24);
            this.smiTheme.Text = "&Thème";
            this.smiTheme.Click += new System.EventHandler(this.SmiTheme_Click);
            // 
            // smiGenre
            // 
            this.smiGenre.Name = "smiGenre";
            this.smiGenre.Size = new System.Drawing.Size(229, 24);
            this.smiGenre.Text = "&Genre";
            this.smiGenre.Click += new System.EventHandler(this.SmiGenre_Click);
            // 
            // smiClassification
            // 
            this.smiClassification.Name = "smiClassification";
            this.smiClassification.Size = new System.Drawing.Size(229, 24);
            this.smiClassification.Text = "&Classification";
            this.smiClassification.Click += new System.EventHandler(this.SmiClassification_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(226, 6);
            // 
            // smiJeu
            // 
            this.smiJeu.Name = "smiJeu";
            this.smiJeu.Size = new System.Drawing.Size(229, 24);
            this.smiJeu.Text = "&Jeu";
            this.smiJeu.Click += new System.EventHandler(this.SmiJeu_Click);
            // 
            // smiGestionPersonnel
            // 
            this.smiGestionPersonnel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiEmploye,
            this.smiEquipe});
            this.smiGestionPersonnel.Name = "smiGestionPersonnel";
            this.smiGestionPersonnel.Size = new System.Drawing.Size(161, 24);
            this.smiGestionPersonnel.Text = "&Gestion du personnel";
            // 
            // smiEmploye
            // 
            this.smiEmploye.Name = "smiEmploye";
            this.smiEmploye.Size = new System.Drawing.Size(136, 24);
            this.smiEmploye.Text = "E&mployé";
            this.smiEmploye.Click += new System.EventHandler(this.smiEmploye_Click);
            // 
            // smiEquipe
            // 
            this.smiEquipe.Name = "smiEquipe";
            this.smiEquipe.Size = new System.Drawing.Size(136, 24);
            this.smiEquipe.Text = "&Équipe";
            this.smiEquipe.Click += new System.EventHandler(this.smiEquipe_Click);
            // 
            // dgvResultats
            // 
            this.dgvResultats.AllowUserToResizeRows = false;
            this.dgvResultats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultats.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultats.Location = new System.Drawing.Point(15, 107);
            this.dgvResultats.Name = "dgvResultats";
            this.dgvResultats.RowHeadersVisible = false;
            this.dgvResultats.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvResultats.RowTemplate.Height = 24;
            this.dgvResultats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultats.Size = new System.Drawing.Size(683, 576);
            this.dgvResultats.TabIndex = 9;
            this.dgvResultats.DoubleClick += new System.EventHandler(this.dgvResultats_DoubleClick);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(1253, 702);
            this.Controls.Add(this.dgvResultats);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFiltre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRechercher);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmAdmin";
            this.Text = "Console d\'administration";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRechercher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFiltre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem smiFichier;
        private System.Windows.Forms.ToolStripMenuItem smiQuitter;
        private System.Windows.Forms.ToolStripMenuItem smiGestionJeu;
        private System.Windows.Forms.ToolStripMenuItem smiSysExp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem smiTypePlateforme;
        private System.Windows.Forms.ToolStripMenuItem smiGestionPersonnel;
        private System.Windows.Forms.ToolStripMenuItem smiPlateforme;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem smiTheme;
        private System.Windows.Forms.ToolStripMenuItem smiGenre;
        private System.Windows.Forms.ToolStripMenuItem smiClassification;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem smiJeu;
        private System.Windows.Forms.ToolStripMenuItem smiEmploye;
        private System.Windows.Forms.ToolStripMenuItem smiEquipe;
        private System.Windows.Forms.DataGridView dgvResultats;

    }
}