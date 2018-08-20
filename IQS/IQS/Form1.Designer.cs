namespace IQS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.pictureBoxMini = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMini)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IQS.Properties.Resources.save;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(476, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 136);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.NavajoWhite;
            this.label1.Location = new System.Drawing.Point(44, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = "IQSaving";
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.Color.Transparent;
            this.PanelContainer.Location = new System.Drawing.Point(26, 185);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(651, 267);
            this.PanelContainer.TabIndex = 2;
            // 
            // pictureBoxMini
            // 
            this.pictureBoxMini.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMini.BackgroundImage = global::IQS.Properties.Resources.arrow_minimize;
            this.pictureBoxMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxMini.Location = new System.Drawing.Point(669, 1);
            this.pictureBoxMini.Name = "pictureBoxMini";
            this.pictureBoxMini.Size = new System.Drawing.Size(51, 52);
            this.pictureBoxMini.TabIndex = 3;
            this.pictureBoxMini.TabStop = false;
            this.pictureBoxMini.Click += new System.EventHandler(this.pictureBoxMini_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.BackgroundImage = global::IQS.Properties.Resources.tree_361647_640;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(721, 480);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxMini);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMini)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.PictureBox pictureBoxMini;
    }
}

