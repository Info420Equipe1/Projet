namespace Texcel.Interfaces.Personnel
{
    partial class frmCreerEquipe
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
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.cmbNom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCommentaire = new System.Windows.Forms.Label();
            this.rtbCommentaire = new System.Windows.Forms.RichTextBox();
            this.lstTesteurGlobal = new System.Windows.Forms.ListBox();
            this.lstTesteurEquipe = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbProjet = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(12, 30);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(49, 20);
            this.lblNom.TabIndex = 13;
            this.lblNom.Text = "Nom:";
            // 
            // txtNom
            // 
            this.txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(134, 27);
            this.txtNom.MaxLength = 20;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(185, 27);
            this.txtNom.TabIndex = 0;
            // 
            // cmbNom
            // 
            this.cmbNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNom.FormattingEnabled = true;
            this.cmbNom.Location = new System.Drawing.Point(134, 59);
            this.cmbNom.MaxLength = 42;
            this.cmbNom.Name = "cmbNom";
            this.cmbNom.Size = new System.Drawing.Size(395, 28);
            this.cmbNom.Sorted = true;
            this.cmbNom.TabIndex = 1;
            this.cmbNom.DropDown += new System.EventHandler(this.cmbNom_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "Chef d\'équipe:";
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.AutoSize = true;
            this.lblCommentaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentaire.Location = new System.Drawing.Point(12, 130);
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(100, 20);
            this.lblCommentaire.TabIndex = 40;
            this.lblCommentaire.Text = "Description:";
            // 
            // rtbCommentaire
            // 
            this.rtbCommentaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCommentaire.Location = new System.Drawing.Point(134, 127);
            this.rtbCommentaire.Name = "rtbCommentaire";
            this.rtbCommentaire.Size = new System.Drawing.Size(677, 96);
            this.rtbCommentaire.TabIndex = 3;
            this.rtbCommentaire.Text = "";
            // 
            // lstTesteurGlobal
            // 
            this.lstTesteurGlobal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTesteurGlobal.FormattingEnabled = true;
            this.lstTesteurGlobal.ItemHeight = 20;
            this.lstTesteurGlobal.Location = new System.Drawing.Point(134, 229);
            this.lstTesteurGlobal.Name = "lstTesteurGlobal";
            this.lstTesteurGlobal.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTesteurGlobal.Size = new System.Drawing.Size(314, 264);
            this.lstTesteurGlobal.Sorted = true;
            this.lstTesteurGlobal.TabIndex = 4;
            // 
            // lstTesteurEquipe
            // 
            this.lstTesteurEquipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTesteurEquipe.FormattingEnabled = true;
            this.lstTesteurEquipe.ItemHeight = 20;
            this.lstTesteurEquipe.Location = new System.Drawing.Point(497, 229);
            this.lstTesteurEquipe.Name = "lstTesteurEquipe";
            this.lstTesteurEquipe.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTesteurEquipe.Size = new System.Drawing.Size(314, 264);
            this.lstTesteurEquipe.Sorted = true;
            this.lstTesteurEquipe.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Testeurs:";
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSupprimer.FlatAppearance.BorderSize = 2;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btnSupprimer.Location = new System.Drawing.Point(423, 499);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(125, 50);
            this.btnSupprimer.TabIndex = 6;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(685, 499);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 50);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEnregistrer.FlatAppearance.BorderSize = 2;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.Color.Black;
            this.btnEnregistrer.Location = new System.Drawing.Point(554, 499);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(125, 50);
            this.btnEnregistrer.TabIndex = 7;
            this.btnEnregistrer.Text = "&Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 32);
            this.button1.TabIndex = 47;
            this.button1.TabStop = false;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(454, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 32);
            this.button2.TabIndex = 48;
            this.button2.TabStop = false;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(454, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 32);
            this.button3.TabIndex = 49;
            this.button3.TabStop = false;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(454, 388);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 32);
            this.button4.TabIndex = 50;
            this.button4.TabStop = false;
            this.button4.Text = "<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmbProjet
            // 
            this.cmbProjet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProjet.FormattingEnabled = true;
            this.cmbProjet.Location = new System.Drawing.Point(134, 93);
            this.cmbProjet.MaxLength = 42;
            this.cmbProjet.Name = "cmbProjet";
            this.cmbProjet.Size = new System.Drawing.Size(677, 28);
            this.cmbProjet.Sorted = true;
            this.cmbProjet.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 52;
            this.label3.Text = "Projet:";
            // 
            // frmCreerEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 560);
            this.Controls.Add(this.cmbProjet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstTesteurEquipe);
            this.Controls.Add(this.lstTesteurGlobal);
            this.Controls.Add(this.lblCommentaire);
            this.Controls.Add(this.rtbCommentaire);
            this.Controls.Add(this.cmbNom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNom);
            this.Name = "frmCreerEquipe";
            this.Text = "Créer une équipe";
            this.Load += new System.EventHandler(this.frmCreerEquipe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.ComboBox cmbNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCommentaire;
        private System.Windows.Forms.RichTextBox rtbCommentaire;
        private System.Windows.Forms.ListBox lstTesteurGlobal;
        private System.Windows.Forms.ListBox lstTesteurEquipe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cmbProjet;
        private System.Windows.Forms.Label label3;
    }
}