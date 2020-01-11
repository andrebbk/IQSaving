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

        //Flags
        private bool flagCheckG = false;
        private bool flagAllurls = false;

        //Inicializar
        public Form1()
        {
            InitializeComponent();

            flagCheckG = false;
            pictureBoxloadgif.Visible = false;
        }

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

                if (flagAllurls)
                    _Urls = Funcionalidades.BuscarTodas(text);
                else if(flagCheckG)
                    _Urls = Funcionalidades.BuscarUrls(text, flagCheckG);
                else
                    _Urls = Funcionalidades.BuscarUrls(text, false);
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
            pictureBoxloadgif.Invoke((MethodInvoker)delegate { pictureBoxloadgif.Visible = true; });

            DataObject retrievedData = (DataObject)Clipboard.GetDataObject();

            if (retrievedData == null)
            {
                label4.Text = "Data missing...";

                Thread _Thread2 = new Thread(new ThreadStart(ResetLAbel4));
                _Thread2.Start();
                return;
            }

            if (String.IsNullOrEmpty(textBoxName.Text) || textBoxName.Text == " ")
            {
                label4.Text = "Name missing...";

                Thread _Thread2 = new Thread(new ThreadStart(ResetLAbel4));
                _Thread2.Start();
                return;
            }

            if (String.IsNullOrEmpty(textBoxPath.Text) || textBoxPath.Text == " ")
            {
                label4.Text = "Path missing...";

                Thread _Thread2 = new Thread(new ThreadStart(ResetLAbel4));
                _Thread2.Start();
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

                Thread _Thread2 = new Thread(new ThreadStart(ResetLAbel4));
                _Thread2.Start();
                return;
            }

            if(Urls_ == null)
            {
                label4.Text = "Invalid URLs...";

                Thread _Thread2 = new Thread(new ThreadStart(ResetLAbel4));
                _Thread2.Start();
                return;
            }

            if (Urls_.Count() < 1)
            {
                label4.Text = "Invalid URLs...";

                Thread _Thread2 = new Thread(new ThreadStart(ResetLAbel4));
                _Thread2.Start();
                return;
            }

            //Guardar todas as fotos na pasta X com o nome Y
           // SaveAllPhotos(textBoxName.Text);

            try
            {
                if(flagAllurls)
                {
                    //Save all urls
                    if(!SaveAllUrls(textBoxName.Text))
                    {
                        Thread _Thread2 = new Thread(new ThreadStart(ResetLAbel4));
                        _Thread2.Start();
                        return;
                    }
                }
                else
                {
                    //Guardar todas as fotos na pasta X com o nome Y
                    if (!SaveAllPhotos(textBoxName.Text))
                    {
                        Thread _Thread2 = new Thread(new ThreadStart(ResetLAbel4));
                        _Thread2.Start();
                        return;
                    }
                }
                
            }
            catch
            {
                label4.Text = "Error saving photos...";

                Thread _Thread6 = new Thread(new ThreadStart(ResetLAbel4));
                _Thread6.Start();
                return;
            }

            //FIM
            label4.Text = "Photos saved successfully!";
            textBoxName.Clear();

            Thread _Thread = new Thread(new ThreadStart(ResetLAbel4));
            _Thread.Start();
        }

        private bool SaveAllPhotos(string nome)
        {         
            int contador = 0;

            if (Urls_ == null)
            {
                label4.Text = " Invalid URLs...";
                return false;
            }

            try
            {
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

                return true;
            }
            catch
            {
                label4.Text = " Invalid URLs...";
                return false;
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
            System.Threading.Thread.Sleep(3000);

            label4.Invoke((MethodInvoker)delegate {

                label4.Text = "";                
            });

            pictureBoxloadgif.Invoke((MethodInvoker)delegate { pictureBoxloadgif.Visible = false; });
        }

        void CorrerGIF()
        {
            pictureBoxloadgif.Invoke((MethodInvoker)delegate { pictureBoxloadgif.Visible = true; });
            Application.DoEvents();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            //Sair
            Application.Exit();
        }

        private void pictureBoxGram_Click(object sender, EventArgs e)
        {
            if(flagCheckG)
            {
                //Remover escolha
                flagCheckG = false;
                pictureBoxChecked.BackgroundImage = Properties.Resources.icon_notdone;
            }
            else
            {
                //Escolher gram
                flagCheckG = true;
                pictureBoxChecked.BackgroundImage = Properties.Resources.icon_done;
            }
        }

        private void pictureBoxAllUrls_Click(object sender, EventArgs e)
        {
            if (flagAllurls)
            {
                //Remover escolha
                flagAllurls = false;
                pictureBoxAllUrlsCheck.BackgroundImage = Properties.Resources.icon_notdone;
            }
            else
            {
                //Escolher gram
                flagAllurls = true;
                pictureBoxAllUrlsCheck.BackgroundImage = Properties.Resources.icon_done;
            }
        }

        private bool SaveAllUrls(string nome)
        {
            int contador = 0;

            if (Urls_ == null)
            {
                label4.Text = " Invalid URLs...";
                return false;
            }            

            foreach (string Uri_ in Urls_)
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] data = webClient.DownloadData(Uri_);

                        using (MemoryStream mem = new MemoryStream(data))
                        {
                            using (var yourImage = Image.FromStream(mem))
                            {
                                // If you want it as Png
                                yourImage.Save(Caminho + nome + contador.ToString() + ".png", ImageFormat.Png);
                            }
                        }

                    }
                }
                catch
                {                   
                }

                contador++;
            }

            return true;

        }
    }
}
