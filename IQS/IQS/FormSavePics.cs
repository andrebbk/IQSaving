using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQS
{
    public partial class FormSavePics : Form
    {
        FormPics formPics;
        Form1 formInit;
        private String Caminho = null;

        List<string> Urls_;

        public FormSavePics(List<string> _urls, FormPics _form, Form1 _form2)
        {
            InitializeComponent();
            formPics = _form;
            formInit = _form2;

            Urls_ = _urls;

            CLeanForm();
        }

        private void buttonLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBoxName.Text) || textBoxName.Text == " ")
            {
                label4.Text = "Name missing...";
                return;
            }

            if (String.IsNullOrEmpty(textBoxPath.Text) || textBoxPath.Text == " ")
            {
                label4.Text = "Path missing...";
                return;
            }

            //Guardar todas as fotos na pasta X com o nome Y
            SaveAllPhotos(textBoxName.Text);

            formPics.Close();

            //open inicio
            formInit.Show();

            CLeanForm();
            this.Close();
        }

        private void SaveAllPhotos(string nome)
        {
            int contador = 0;

            foreach (string Uri_ in Urls_)
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(Uri_);

                    using (MemoryStream mem = new MemoryStream(data))
                    {
                        using (var yourImage = Image.FromStream(mem))
                        {
                            string[] partes = Uri_.Split('.');
                            if (partes[partes.Count() - 1].Equals("png"))
                            {
                                yourImage.Save(Caminho + nome + contador.ToString() + ".png", ImageFormat.Png);
                            }
                            else
                            {
                                // If you want it as Jpeg
                                yourImage.Save(Caminho + nome + contador.ToString() + ".jpg", ImageFormat.Jpeg);
                            }                          
                            
                        }
                    }

                }

                contador++;
            }
        }

        private void CLeanForm()
        {
            textBoxName.Clear();
            //textBoxPath.Clear();
        }

        private void buttonChecking_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();

            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;

            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                Caminho = folderBrowser.FileName.Replace("Folder Selection", "");
                textBoxPath.Text = folderBrowser.FileName.Replace("Folder Selection", "");
            }
        }

        private void textBoxPath_Click(object sender, EventArgs e)
        {
            textBoxPath.Clear();
        }
    }
}
