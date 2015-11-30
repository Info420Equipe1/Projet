namespace Texcel
{
    partial class frmPassRenew
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
            this.btn = new System.Windows.Forms.Button();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.txtBoxPass2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btn.Location = new System.Drawing.Point(243, 110);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(134, 42);
            this.btn.TabIndex = 0;
            this.btn.Text = "&Enregistrer";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // txtPass1
            // 
            this.txtPass1.Location = new System.Drawing.Point(216, 35);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(161, 22);
            this.txtPass1.TabIndex = 1;
            // 
            // txtBoxPass2
            // 
            this.txtBoxPass2.Location = new System.Drawing.Point(216, 75);
            this.txtBoxPass2.Name = "txtBoxPass2";
            this.txtBoxPass2.PasswordChar = '*';
            this.txtBoxPass2.Size = new System.Drawing.Size(161, 22);
            this.txtBoxPass2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label1.Location = new System.Drawing.Point(100, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mot de passe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label2.Location = new System.Drawing.Point(24, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ressaisir mot de passe";
            // 
            // frmPassRenew
            // 
            this.AcceptButton = this.btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(408, 164);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxPass2);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.btn);
            this.Name = "frmPassRenew";
            this.Text = "Changement de mot de passe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.TextBox txtPass1;
        private System.Windows.Forms.TextBox txtBoxPass2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}