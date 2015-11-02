namespace Texcel.Interfaces.Personnel
{
    partial class frmUtilisateur
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
            this.lblMotPasse = new System.Windows.Forms.Label();
            this.lblNomUtil = new System.Windows.Forms.Label();
            this.txtMotPasse = new System.Windows.Forms.TextBox();
            this.txtNomUtil = new System.Windows.Forms.TextBox();
            this.btnPtiteFlecheGauche = new System.Windows.Forms.Button();
            this.btnPtiteFlecheDroite = new System.Windows.Forms.Button();
            this.lblGroupes = new System.Windows.Forms.Label();
            this.lsbGroupes2 = new System.Windows.Forms.ListBox();
            this.lsbGroupes = new System.Windows.Forms.ListBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btn2FlecheDroite = new System.Windows.Forms.Button();
            this.btn2FlecheGauche = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMotPasse
            // 
            this.lblMotPasse.AutoSize = true;
            this.lblMotPasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotPasse.Location = new System.Drawing.Point(12, 80);
            this.lblMotPasse.Name = "lblMotPasse";
            this.lblMotPasse.Size = new System.Drawing.Size(120, 20);
            this.lblMotPasse.TabIndex = 15;
            this.lblMotPasse.Text = "Mot de passe :";
            // 
            // lblNomUtil
            // 
            this.lblNomUtil.AutoSize = true;
            this.lblNomUtil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUtil.Location = new System.Drawing.Point(12, 44);
            this.lblNomUtil.Name = "lblNomUtil";
            this.lblNomUtil.Size = new System.Drawing.Size(145, 20);
            this.lblNomUtil.TabIndex = 14;
            this.lblNomUtil.Text = "Nom d\'utilisateur :";
            // 
            // txtMotPasse
            // 
            this.txtMotPasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotPasse.Location = new System.Drawing.Point(163, 77);
            this.txtMotPasse.MaxLength = 20;
            this.txtMotPasse.Name = "txtMotPasse";
            this.txtMotPasse.Size = new System.Drawing.Size(185, 27);
            this.txtMotPasse.TabIndex = 1;
            // 
            // txtNomUtil
            // 
            this.txtNomUtil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomUtil.Location = new System.Drawing.Point(163, 41);
            this.txtNomUtil.MaxLength = 20;
            this.txtNomUtil.Name = "txtNomUtil";
            this.txtNomUtil.Size = new System.Drawing.Size(185, 27);
            this.txtNomUtil.TabIndex = 0;
            // 
            // btnPtiteFlecheGauche
            // 
            this.btnPtiteFlecheGauche.Location = new System.Drawing.Point(278, 226);
            this.btnPtiteFlecheGauche.Name = "btnPtiteFlecheGauche";
            this.btnPtiteFlecheGauche.Size = new System.Drawing.Size(37, 23);
            this.btnPtiteFlecheGauche.TabIndex = 29;
            this.btnPtiteFlecheGauche.TabStop = false;
            this.btnPtiteFlecheGauche.Text = "<";
            this.btnPtiteFlecheGauche.UseVisualStyleBackColor = true;
            this.btnPtiteFlecheGauche.Click += new System.EventHandler(this.btnPtiteFlecheGauche_Click);
            // 
            // btnPtiteFlecheDroite
            // 
            this.btnPtiteFlecheDroite.Location = new System.Drawing.Point(278, 187);
            this.btnPtiteFlecheDroite.Name = "btnPtiteFlecheDroite";
            this.btnPtiteFlecheDroite.Size = new System.Drawing.Size(37, 25);
            this.btnPtiteFlecheDroite.TabIndex = 28;
            this.btnPtiteFlecheDroite.TabStop = false;
            this.btnPtiteFlecheDroite.Text = ">";
            this.btnPtiteFlecheDroite.UseVisualStyleBackColor = true;
            this.btnPtiteFlecheDroite.Click += new System.EventHandler(this.btnPtiteFlecheDroite_Click);
            // 
            // lblGroupes
            // 
            this.lblGroupes.AutoSize = true;
            this.lblGroupes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupes.Location = new System.Drawing.Point(12, 133);
            this.lblGroupes.Name = "lblGroupes";
            this.lblGroupes.Size = new System.Drawing.Size(73, 20);
            this.lblGroupes.TabIndex = 26;
            this.lblGroupes.Text = "Groupes";
            // 
            // lsbGroupes2
            // 
            this.lsbGroupes2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbGroupes2.FormattingEnabled = true;
            this.lsbGroupes2.ItemHeight = 20;
            this.lsbGroupes2.Location = new System.Drawing.Point(321, 156);
            this.lsbGroupes2.Name = "lsbGroupes2";
            this.lsbGroupes2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbGroupes2.Size = new System.Drawing.Size(249, 124);
            this.lsbGroupes2.Sorted = true;
            this.lsbGroupes2.TabIndex = 3;
            // 
            // lsbGroupes
            // 
            this.lsbGroupes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbGroupes.FormattingEnabled = true;
            this.lsbGroupes.ItemHeight = 20;
            this.lsbGroupes.Location = new System.Drawing.Point(16, 156);
            this.lsbGroupes.Name = "lsbGroupes";
            this.lsbGroupes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbGroupes.Size = new System.Drawing.Size(256, 124);
            this.lsbGroupes.Sorted = true;
            this.lsbGroupes.TabIndex = 2;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSupprimer.FlatAppearance.BorderSize = 2;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btnSupprimer.Location = new System.Drawing.Point(183, 286);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(125, 50);
            this.btnSupprimer.TabIndex = 4;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Visible = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(445, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 50);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAjouter.FlatAppearance.BorderSize = 2;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.Black;
            this.btnAjouter.Location = new System.Drawing.Point(314, 286);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(125, 50);
            this.btnAjouter.TabIndex = 5;
            this.btnAjouter.Text = "&Enregistrer";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btn2FlecheDroite
            // 
            this.btn2FlecheDroite.Location = new System.Drawing.Point(278, 156);
            this.btn2FlecheDroite.Name = "btn2FlecheDroite";
            this.btn2FlecheDroite.Size = new System.Drawing.Size(37, 25);
            this.btn2FlecheDroite.TabIndex = 30;
            this.btn2FlecheDroite.TabStop = false;
            this.btn2FlecheDroite.Text = ">>";
            this.btn2FlecheDroite.UseVisualStyleBackColor = true;
            this.btn2FlecheDroite.Click += new System.EventHandler(this.btn2FlecheDroite_Click);
            // 
            // btn2FlecheGauche
            // 
            this.btn2FlecheGauche.Location = new System.Drawing.Point(278, 255);
            this.btn2FlecheGauche.Name = "btn2FlecheGauche";
            this.btn2FlecheGauche.Size = new System.Drawing.Size(37, 25);
            this.btn2FlecheGauche.TabIndex = 31;
            this.btn2FlecheGauche.TabStop = false;
            this.btn2FlecheGauche.Text = "<<";
            this.btn2FlecheGauche.UseVisualStyleBackColor = true;
            this.btn2FlecheGauche.Click += new System.EventHandler(this.btn2FlecheGauche_Click);
            // 
            // frmUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 345);
            this.Controls.Add(this.btn2FlecheGauche);
            this.Controls.Add(this.btn2FlecheDroite);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnPtiteFlecheGauche);
            this.Controls.Add(this.btnPtiteFlecheDroite);
            this.Controls.Add(this.lblGroupes);
            this.Controls.Add(this.lsbGroupes2);
            this.Controls.Add(this.lsbGroupes);
            this.Controls.Add(this.lblMotPasse);
            this.Controls.Add(this.lblNomUtil);
            this.Controls.Add(this.txtMotPasse);
            this.Controls.Add(this.txtNomUtil);
            this.Name = "frmUtilisateur";
            this.Text = "frmUtilisateur";
            this.Load += new System.EventHandler(this.frmUtilisateur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMotPasse;
        private System.Windows.Forms.Label lblNomUtil;
        private System.Windows.Forms.TextBox txtMotPasse;
        private System.Windows.Forms.TextBox txtNomUtil;
        private System.Windows.Forms.Button btnPtiteFlecheGauche;
        private System.Windows.Forms.Button btnPtiteFlecheDroite;
        private System.Windows.Forms.Label lblGroupes;
        private System.Windows.Forms.ListBox lsbGroupes2;
        private System.Windows.Forms.ListBox lsbGroupes;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btn2FlecheDroite;
        private System.Windows.Forms.Button btn2FlecheGauche;
    }
}