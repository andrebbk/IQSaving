using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            //Organizar Urls
            List<string> _Urls = new List<string>();
            _Urls = Funcionalidades.BuscarUrls();            

            //Fechar este 
            System.Threading.Thread.Sleep(2000);

            this.Invoke((MethodInvoker)delegate
            {
                //Envia-las para o novo Pics Form
                FormPics _novoPics = new FormPics(_Urls, _formInicio);
                _novoPics.Show();

                //Close form1
                _formInicio.Hide();
            });

        }
    }
}
