namespace IQS
{
    partial class UserControlButtons
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonChecking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonQuit
            // 
            this.buttonQuit.BackColor = System.Drawing.Color.Transparent;
            this.buttonQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit.ForeColor = System.Drawing.Color.NavajoWhite;
            this.buttonQuit.Location = new System.Drawing.Point(54, 143);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(343, 98);
            this.buttonQuit.TabIndex = 5;
            this.buttonQuit.Text = "Leave";
            this.buttonQuit.UseVisualStyleBackColor = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonChecking
            // 
            this.buttonChecking.BackColor = System.Drawing.Color.Transparent;
            this.buttonChecking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonChecking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChecking.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChecking.ForeColor = System.Drawing.Color.NavajoWhite;
            this.buttonChecking.Location = new System.Drawing.Point(54, 28);
            this.buttonChecking.Name = "buttonChecking";
            this.buttonChecking.Size = new System.Drawing.Size(343, 98);
            this.buttonChecking.TabIndex = 4;
            this.buttonChecking.Text = "Check URLs";
            this.buttonChecking.UseVisualStyleBackColor = false;
            // 
            // UserControlButtons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonChecking);
            this.Name = "UserControlButtons";
            this.Size = new System.Drawing.Size(618, 367);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonChecking;
    }
}
