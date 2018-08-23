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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQS
{
    public partial class Form1 : Form
    {
        private String Caminho = null;
        List<string> Urls_;

        public Form1()
        {
            InitializeComponent();
        }

        //Form drag
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        //Form drag
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void pictureBoxMini_Click(object sender, EventArgs e)
        {
            //Minimizar
            this.WindowState = FormWindowState.Minimized;
        }

        private void SendUrlsToPicsForm()
        {

            IDataObject idat = null;
            Exception threadEx = null;
            String text = "";
            Thread staThread = new Thread(
                delegate ()
                {
                    try
                    {
                        idat = Clipboard.GetDataObject();
                        text = idat.GetData(DataFormats.Text).ToString();            
                    }

                    catch (Exception ex)
                    {
                        threadEx = ex;
                    }
                });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();

            //Organizar Urls
            List<string> _Urls = new List<string>();

            if (!String.IsNullOrEmpty(text))
            {
                string Dados = Clipboard.GetText(TextDataFormat.Text).ToString();
                _Urls = Funcionalidades.BuscarUrls(text);
            }
            else
            {
                //Não existe nada no clipboard
                _Urls = null;
            }

            //Fechar este 
            System.Threading.Thread.Sleep(1000);

            this.Invoke((MethodInvoker)delegate
            {
                if (_Urls == null)
                {
                    return;
                }

                //Envia-las para o novo Pics Form
                Urls_ = _Urls;
            });
        }

        private void buttonChecking_Click(object sender, EventArgs e)
        {
            DataObject retrievedData = (DataObject)Clipboard.GetDataObject();

            if (retrievedData == null)
            {
                label4.Text = "Data missing...";
                return;
            }

            if (String.IsNullOrEmpty(textBoxName.Text) || textBoxName.Text == " ")
            {
                label4.Text = "Name missing...";
                return;
            }

            if (String.IsNullOrEmpty(textBoxPath.Text) || textBoxPath.Text == " ")
            {
                label4.Text = "Path missing...";
                return;
            }

            try
            {
                //Organizar e carregar urls
                SendUrlsToPicsForm();
            }
            catch
            {
                label4.Text = "Error organizing photos...";
                return;
            }

            try
            {
                //Guardar todas as fotos na pasta X com o nome Y
                SaveAllPhotos(textBoxName.Text);
            }
            catch
            {
                label4.Text = "Error saving photos...";
                return;
            }

            //FIM
            label4.Text = "Photos saved successfully!";
            textBoxName.Clear();

            Thread _Thread = new Thread(new ThreadStart(ResetLAbel4));
            _Thread.Start();
        }

        private void SaveAllPhotos(string nome)
        {
            if(Urls_ == null)
            {
                label4.Text = " Invalid URLs...";
                return;
            }

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

        private void button1_Click(object sender, EventArgs e)
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

        void ResetLAbel4()
        {
            System.Threading.Thread.Sleep(2000);

            label4.Invoke((MethodInvoker)delegate {

                label4.Text = "";
            });
        }
    }
}
