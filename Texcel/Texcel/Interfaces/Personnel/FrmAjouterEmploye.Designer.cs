namespace Texcel.Interfaces.Personnel
{
    partial class frmAjouterEmploye
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
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.bntFlecheRetirer = new System.Windows.Forms.Button();
            this.btnFlecheAjouter = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblCompetences = new System.Windows.Forms.Label();
            this.lblTypeTest = new System.Windows.Forms.Label();
            this.lstBoxTypeTestEmp = new System.Windows.Forms.ListBox();
            this.lstBoxTypeTest = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTelPrimaire = new System.Windows.Forms.Label();
            this.lblTelSec = new System.Windows.Forms.Label();
            this.lblAdresse = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblNumeroEmp = new System.Windows.Forms.Label();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.txtTelSec = new System.Windows.Forms.TextBox();
            this.txtTelPrim = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtNumeroEmp = new System.Windows.Forms.TextBox();
            this.dateTPEmp = new System.Windows.Forms.DateTimePicker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreerUti = new System.Windows.Forms.Button();
            this.btnModifUti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenom.Location = new System.Drawing.Point(23, 129);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(77, 20);
            this.lblPrenom.TabIndex = 29;
            this.lblPrenom.Text = "Prenom :";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrenom.Location = new System.Drawing.Point(107, 126);
            this.txtPrenom.MaxLength = 20;
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(365, 27);
            this.txtPrenom.TabIndex = 3;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSupprimer.FlatAppearance.BorderSize = 2;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btnSupprimer.Location = new System.Drawing.Point(541, 603);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(125, 50);
            this.btnSupprimer.TabIndex = 11;
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
            this.btnCancel.Location = new System.Drawing.Point(803, 603);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 50);
            this.btnCancel.TabIndex = 13;
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
            this.btnEnregistrer.Location = new System.Drawing.Point(672, 603);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(125, 50);
            this.btnEnregistrer.TabIndex = 12;
            this.btnEnregistrer.Text = "&Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // bntFlecheRetirer
            // 
            this.bntFlecheRetirer.Location = new System.Drawing.Point(459, 398);
            this.bntFlecheRetirer.Name = "bntFlecheRetirer";
            this.bntFlecheRetirer.Size = new System.Drawing.Size(37, 32);
            this.bntFlecheRetirer.TabIndex = 23;
            this.bntFlecheRetirer.TabStop = false;
            this.bntFlecheRetirer.Text = "<<";
            this.bntFlecheRetirer.UseVisualStyleBackColor = true;
            this.bntFlecheRetirer.Click += new System.EventHandler(this.bntFlecheRetirer_Click);
            // 
            // btnFlecheAjouter
            // 
            this.btnFlecheAjouter.Location = new System.Drawing.Point(459, 360);
            this.btnFlecheAjouter.Name = "btnFlecheAjouter";
            this.btnFlecheAjouter.Size = new System.Drawing.Size(37, 32);
            this.btnFlecheAjouter.TabIndex = 22;
            this.btnFlecheAjouter.TabStop = false;
            this.btnFlecheAjouter.Text = ">>";
            this.btnFlecheAjouter.UseVisualStyleBackColor = true;
            this.btnFlecheAjouter.Click += new System.EventHandler(this.btnFlecheAjouter_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(27, 476);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(902, 121);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // lblCompetences
            // 
            this.lblCompetences.AutoSize = true;
            this.lblCompetences.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompetences.Location = new System.Drawing.Point(23, 453);
            this.lblCompetences.Name = "lblCompetences";
            this.lblCompetences.Size = new System.Drawing.Size(209, 20);
            this.lblCompetences.TabIndex = 20;
            this.lblCompetences.Text = "Compétences particulières";
            // 
            // lblTypeTest
            // 
            this.lblTypeTest.AutoSize = true;
            this.lblTypeTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeTest.Location = new System.Drawing.Point(23, 323);
            this.lblTypeTest.Name = "lblTypeTest";
            this.lblTypeTest.Size = new System.Drawing.Size(101, 20);
            this.lblTypeTest.TabIndex = 19;
            this.lblTypeTest.Text = "Type de test";
            // 
            // lstBoxTypeTestEmp
            // 
            this.lstBoxTypeTestEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxTypeTestEmp.FormattingEnabled = true;
            this.lstBoxTypeTestEmp.ItemHeight = 20;
            this.lstBoxTypeTestEmp.Location = new System.Drawing.Point(502, 346);
            this.lstBoxTypeTestEmp.Name = "lstBoxTypeTestEmp";
            this.lstBoxTypeTestEmp.Size = new System.Drawing.Size(427, 104);
            this.lstBoxTypeTestEmp.TabIndex = 9;
            // 
            // lstBoxTypeTest
            // 
            this.lstBoxTypeTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxTypeTest.FormattingEnabled = true;
            this.lstBoxTypeTest.ItemHeight = 20;
            this.lstBoxTypeTest.Location = new System.Drawing.Point(27, 346);
            this.lstBoxTypeTest.Name = "lstBoxTypeTest";
            this.lstBoxTypeTest.Size = new System.Drawing.Size(426, 104);
            this.lstBoxTypeTest.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(478, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Date d\'embauche :";
            // 
            // lblTelPrimaire
            // 
            this.lblTelPrimaire.AutoSize = true;
            this.lblTelPrimaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelPrimaire.Location = new System.Drawing.Point(478, 91);
            this.lblTelPrimaire.Name = "lblTelPrimaire";
            this.lblTelPrimaire.Size = new System.Drawing.Size(114, 20);
            this.lblTelPrimaire.TabIndex = 14;
            this.lblTelPrimaire.Text = "Tel. Primaire :";
            // 
            // lblTelSec
            // 
            this.lblTelSec.AutoSize = true;
            this.lblTelSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelSec.Location = new System.Drawing.Point(478, 129);
            this.lblTelSec.Name = "lblTelSec";
            this.lblTelSec.Size = new System.Drawing.Size(135, 20);
            this.lblTelSec.TabIndex = 13;
            this.lblTelSec.Text = "Tel. Secondaire :";
            // 
            // lblAdresse
            // 
            this.lblAdresse.AutoSize = true;
            this.lblAdresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdresse.Location = new System.Drawing.Point(23, 165);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(81, 20);
            this.lblAdresse.TabIndex = 12;
            this.lblAdresse.Text = "Adresse :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(23, 91);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(54, 20);
            this.lblNom.TabIndex = 11;
            this.lblNom.Text = "Nom :";
            // 
            // lblNumeroEmp
            // 
            this.lblNumeroEmp.AutoSize = true;
            this.lblNumeroEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroEmp.Location = new System.Drawing.Point(23, 57);
            this.lblNumeroEmp.Name = "lblNumeroEmp";
            this.lblNumeroEmp.Size = new System.Drawing.Size(78, 20);
            this.lblNumeroEmp.TabIndex = 10;
            this.lblNumeroEmp.Text = "Numéro :";
            // 
            // txtAdresse
            // 
            this.txtAdresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdresse.Location = new System.Drawing.Point(107, 162);
            this.txtAdresse.MaxLength = 50;
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(365, 27);
            this.txtAdresse.TabIndex = 4;
            // 
            // txtTelSec
            // 
            this.txtTelSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelSec.Location = new System.Drawing.Point(623, 126);
            this.txtTelSec.MaxLength = 12;
            this.txtTelSec.Name = "txtTelSec";
            this.txtTelSec.Size = new System.Drawing.Size(269, 27);
            this.txtTelSec.TabIndex = 6;
            // 
            // txtTelPrim
            // 
            this.txtTelPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelPrim.Location = new System.Drawing.Point(623, 88);
            this.txtTelPrim.MaxLength = 12;
            this.txtTelPrim.Name = "txtTelPrim";
            this.txtTelPrim.Size = new System.Drawing.Size(269, 27);
            this.txtTelPrim.TabIndex = 5;
            // 
            // txtNom
            // 
            this.txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(107, 88);
            this.txtNom.MaxLength = 20;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(365, 27);
            this.txtNom.TabIndex = 2;
            // 
            // txtNumeroEmp
            // 
            this.txtNumeroEmp.Enabled = false;
            this.txtNumeroEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroEmp.Location = new System.Drawing.Point(107, 54);
            this.txtNumeroEmp.Name = "txtNumeroEmp";
            this.txtNumeroEmp.Size = new System.Drawing.Size(178, 27);
            this.txtNumeroEmp.TabIndex = 1;
            // 
            // dateTPEmp
            // 
            this.dateTPEmp.Location = new System.Drawing.Point(623, 165);
            this.dateTPEmp.Name = "dateTPEmp";
            this.dateTPEmp.Size = new System.Drawing.Size(269, 22);
            this.dateTPEmp.TabIndex = 30;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(27, 225);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(332, 84);
            this.listBox1.TabIndex = 31;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Comptes utilisateurs";
            // 
            // btnCreerUti
            // 
            this.btnCreerUti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnCreerUti.Location = new System.Drawing.Point(365, 225);
            this.btnCreerUti.Name = "btnCreerUti";
            this.btnCreerUti.Size = new System.Drawing.Size(88, 31);
            this.btnCreerUti.TabIndex = 33;
            this.btnCreerUti.Text = "Créer";
            this.btnCreerUti.UseVisualStyleBackColor = true;
            this.btnCreerUti.Click += new System.EventHandler(this.btnCreerUti_Click);
            // 
            // btnModifUti
            // 
            this.btnModifUti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnModifUti.Location = new System.Drawing.Point(365, 276);
            this.btnModifUti.Name = "btnModifUti";
            this.btnModifUti.Size = new System.Drawing.Size(88, 33);
            this.btnModifUti.TabIndex = 34;
            this.btnModifUti.Text = "Modifier";
            this.btnModifUti.UseVisualStyleBackColor = true;
            this.btnModifUti.Visible = false;
            this.btnModifUti.Click += new System.EventHandler(this.btnModifUti_Click);
            // 
            // frmAjouterEmploye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 661);
            this.Controls.Add(this.btnModifUti);
            this.Controls.Add(this.btnCreerUti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dateTPEmp);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.bntFlecheRetirer);
            this.Controls.Add(this.btnFlecheAjouter);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblCompetences);
            this.Controls.Add(this.lblTypeTest);
            this.Controls.Add(this.lstBoxTypeTestEmp);
            this.Controls.Add(this.lstBoxTypeTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTelPrimaire);
            this.Controls.Add(this.lblTelSec);
            this.Controls.Add(this.lblAdresse);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblNumeroEmp);
            this.Controls.Add(this.txtAdresse);
            this.Controls.Add(this.txtTelSec);
            this.Controls.Add(this.txtTelPrim);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtNumeroEmp);
            this.Name = "frmAjouterEmploye";
            this.Text = "Ajouter un employé";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumeroEmp;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtTelPrim;
        private System.Windows.Forms.TextBox txtTelSec;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Label lblNumeroEmp;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblAdresse;
        private System.Windows.Forms.Label lblTelSec;
        private System.Windows.Forms.Label lblTelPrimaire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoxTypeTest;
        private System.Windows.Forms.ListBox lstBoxTypeTestEmp;
        private System.Windows.Forms.Label lblTypeTest;
        private System.Windows.Forms.Label lblCompetences;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnFlecheAjouter;
        private System.Windows.Forms.Button bntFlecheRetirer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.DateTimePicker dateTPEmp;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreerUti;
        private System.Windows.Forms.Button btnModifUti;
    }
}