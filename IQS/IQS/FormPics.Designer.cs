namespace IQS
{
    partial class FormPics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPics));
            this.pictureBoxMini = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listViewFotos = new System.Windows.Forms.ListView();
            this.buttonSavePhotos = new System.Windows.Forms.Button();
            this.buttonLeave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMini
            // 
            this.pictureBoxMini.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMini.BackgroundImage = global::IQS.Properties.Resources.arrow_minimize;
            this.pictureBoxMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxMini.Location = new System.Drawing.Point(1035, 1);
            this.pictureBoxMini.Name = "pictureBoxMini";
            this.pictureBoxMini.Size = new System.Drawing.Size(51, 52);
            this.pictureBoxMini.TabIndex = 4;
            this.pictureBoxMini.TabStop = false;
            this.pictureBoxMini.Click += new System.EventHandler(this.pictureBoxMini_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.NavajoWhite;
            this.label1.Location = new System.Drawing.Point(68, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 47);
            this.label1.TabIndex = 5;
            this.label1.Text = "IQSaving";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IQS.Properties.Resources.save;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 49);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // listViewFotos
            // 
            this.listViewFotos.BackColor = System.Drawing.Color.Gray;
            this.listViewFotos.BackgroundImage = global::IQS.Properties.Resources.tree_361647_640;
            this.listViewFotos.BackgroundImageTiled = true;
            this.listViewFotos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFotos.Location = new System.Drawing.Point(33, 95);
            this.listViewFotos.Name = "listViewFotos";
            this.listViewFotos.Size = new System.Drawing.Size(1014, 525);
            this.listViewFotos.TabIndex = 7;
            this.listViewFotos.UseCompatibleStateImageBehavior = false;
            // 
            // buttonSavePhotos
            // 
            this.buttonSavePhotos.BackColor = System.Drawing.Color.Transparent;
            this.buttonSavePhotos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonSavePhotos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSavePhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSavePhotos.ForeColor = System.Drawing.Color.NavajoWhite;
            this.buttonSavePhotos.Location = new System.Drawing.Point(431, 629);
            this.buttonSavePhotos.Name = "buttonSavePhotos";
            this.buttonSavePhotos.Size = new System.Drawing.Size(305, 80);
            this.buttonSavePhotos.TabIndex = 8;
            this.buttonSavePhotos.Text = "Save Photos";
            this.buttonSavePhotos.UseVisualStyleBackColor = false;
            this.buttonSavePhotos.Click += new System.EventHandler(this.buttonSavePhotos_Click);
            // 
            // buttonLeave
            // 
            this.buttonLeave.BackColor = System.Drawing.Color.Transparent;
            this.buttonLeave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLeave.ForeColor = System.Drawing.Color.NavajoWhite;
            this.buttonLeave.Location = new System.Drawing.Point(742, 629);
            this.buttonLeave.Name = "buttonLeave";
            this.buttonLeave.Size = new System.Drawing.Size(305, 80);
            this.buttonLeave.TabIndex = 9;
            this.buttonLeave.Text = "Leave";
            this.buttonLeave.UseVisualStyleBackColor = false;
            this.buttonLeave.Click += new System.EventHandler(this.buttonLeave_Click);
            // 
            // FormPics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IQS.Properties.Resources.tree_361647_640;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 721);
            this.ControlBox = false;
            this.Controls.Add(this.buttonLeave);
            this.Controls.Add(this.buttonSavePhotos);
            this.Controls.Add(this.listViewFotos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxMini);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IQSaving";
            this.Load += new System.EventHandler(this.FormPics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMini;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listViewFotos;
        private System.Windows.Forms.Button buttonSavePhotos;
        private System.Windows.Forms.Button buttonLeave;
    }
}