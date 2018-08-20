using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQS
{
    public partial class Form1 : Form
    {
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //Botoes no inicio
            PanelContainer.Controls.Clear();
            UserControlButtons _Botoes = new UserControlButtons(this);
            PanelContainer.Controls.Add(_Botoes);
        }

        public void StartCheckingProcess()
        {
            PanelContainer.Controls.Clear();
            UserControlLoading _loads = new UserControlLoading();
            PanelContainer.Controls.Add(_loads);

            //Usar outra thread
            Task task = Task.Run(() => SendUrlsToPicsForm(this));
        }

        public void ReturnBegun()
        {
            PanelContainer.Controls.Clear();
            UserControlButtons _Botoes = new UserControlButtons(this);
            PanelContainer.Controls.Add(_Botoes);
        }

        private void pictureBoxMini_Click(object sender, EventArgs e)
        {
            //Minimizar
            this.WindowState = FormWindowState.Minimized;
        }

        private void SendUrlsToPicsForm(Form1 _formInicio)
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
            List<string> _PicsUrls = new List<string>();
            List<string> _Urls = new List<string>();

            if (!String.IsNullOrEmpty(text))
            {
                string Dados = Clipboard.GetText(TextDataFormat.Text).ToString();
                _PicsUrls = Funcionalidades.BuscarUrls(text);
            }
            else
            {
                //Não existe nada no clipboard
                _PicsUrls = null;
            }

            _Urls = Funcionalidades.BuscarUrls2(text);

            //Fechar este 
            System.Threading.Thread.Sleep(1000);

            this.Invoke((MethodInvoker)delegate
            {
                //Envia-las para o novo Pics Form
                PopupLists _novoPics = new PopupLists(_PicsUrls, _formInicio, _Urls);
                _novoPics.Show();

                //Close form1
                _formInicio.Hide();
            });

        }
    }
}
