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
            UserControlLoading _loads = new UserControlLoading(this);
            PanelContainer.Controls.Add(_loads);
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
    }
}
