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
    public partial class PopupLists : Form
    {
        Form1 formInit;

        //Lista de fotos
        List<string> _Urls;
        List<string> _Urls2;

        public PopupLists(List<string> _dados, Form1 _formInicio, List<string> _dados2)
        {
            InitializeComponent();

            _Urls = new List<string>();
            _Urls = _dados;
            _Urls2 = new List<string>();
            _Urls2 = _dados2;

            formInit = _formInicio;

            LoadLists();
        }

        private void pictureBoxMini_Click(object sender, EventArgs e)
        {
            //Minimizar
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoadLists()
        {
            if( _Urls == null || _Urls2 == null)
                return;

            //LISTA 1
            foreach (string str in _Urls)
            {
                if(!String.IsNullOrEmpty(str) && str != " ")
                {
                    listBox1.Items.Add(str.Replace("https://", "").Replace("http://", ""));
                }
            }

            //LISTA 2
            foreach (string str2 in _Urls2)
            {
                if (!String.IsNullOrEmpty(str2) && str2 != " ")
                {
                    listBox2.Items.Add(str2.Replace("https://", "").Replace("http://", ""));
                }
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
