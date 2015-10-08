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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblGroupes = new System.Windows.Forms.Label();
            this.lsbGroupes2 = new System.Windows.Forms.ListBox();
            this.lsbGroupes = new System.Windows.Forms.ListBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMotPasse
            // 
            this.lblMotPasse.AutoSize = true;
            this.lblMotPasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotPasse.Location = new System.Drawing.Point(80, 112);
            this.lblMotPasse.Name = "lblMotPasse";
            this.lblMotPasse.Size = new System.Drawing.Size(120, 20);
            this.lblMotPasse.TabIndex = 15;
            this.lblMotPasse.Text = "Mot de passe :";
            // 
            // lblNomUtil
            // 
            this.lblNomUtil.AutoSize = true;
            this.lblNomUtil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUtil.Location = new System.Drawing.Point(55, 76);
            this.lblNomUtil.Name = "lblNomUtil";
            this.lblNomUtil.Size = new System.Drawing.Size(145, 20);
            this.lblNomUtil.TabIndex = 14;
            this.lblNomUtil.Text = "Nom d\'utilisateur :";
            // 
            // txtMotPasse
            // 
            this.txtMotPasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotPasse.Location = new System.Drawing.Point(206, 105);
            this.txtMotPasse.MaxLength = 20;
            this.txtMotPasse.Name = "txtMotPasse";
            this.txtMotPasse.Size = new System.Drawing.Size(286, 30);
            this.txtMotPasse.TabIndex = 1;
            // 
            // txtNomUtil
            // 
            this.txtNomUtil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomUtil.Location = new System.Drawing.Point(206, 69);
            this.txtNomUtil.MaxLength = 20;
            this.txtNomUtil.Name = "txtNomUtil";
            this.txtNomUtil.Size = new System.Drawing.Size(286, 30);
            this.txtNomUtil.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(336, 306);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 23);
            this.button2.TabIndex = 29;
            this.button2.TabStop = false;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 25);
            this.button1.TabIndex = 28;
            this.button1.TabStop = false;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblGroupes
            // 
            this.lblGroupes.AutoSize = true;
            this.lblGroupes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupes.Location = new System.Drawing.Point(70, 182);
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
            this.lsbGroupes2.Location = new System.Drawing.Point(379, 205);
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
            this.lsbGroupes.Location = new System.Drawing.Point(74, 205);
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
            this.btnSupprimer.Location = new System.Drawing.Point(241, 347);
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
            this.btnCancel.Location = new System.Drawing.Point(503, 347);
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
            this.btnAjouter.Location = new System.Drawing.Point(372, 347);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(125, 50);
            this.btnAjouter.TabIndex = 5;
            this.btnAjouter.Text = "&Enregistrer";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(336, 236);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 25);
            this.button3.TabIndex = 30;
            this.button3.TabStop = false;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(336, 275);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 25);
            this.button4.TabIndex = 31;
            this.button4.TabStop = false;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 409);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblGroupes;
        private System.Windows.Forms.ListBox lsbGroupes2;
        private System.Windows.Forms.ListBox lsbGroupes;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}