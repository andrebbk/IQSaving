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

        private void LoadLists()
        {
            if( _Urls == null || _Urls2 == null)
                return;

            //limpar
            listBox1.Items.Clear();
            listBox2.Items.Clear();

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

            formInit.Show();

            this.Close();
        }

        private void UParrow_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if ((listBox1.SelectedIndex - 1) >= 0)
                {
                    string texto1 = _Urls.ElementAt(listBox1.SelectedIndex);
                    _Urls.RemoveAt(listBox1.SelectedIndex);
                    string texto2 = _Urls.ElementAt(listBox1.SelectedIndex - 1);
                    _Urls.RemoveAt(listBox1.SelectedIndex - 1);

                    _Urls.Insert(listBox1.SelectedIndex - 1, texto1);
                    _Urls.Insert(listBox1.SelectedIndex, texto2);

                    //Refresh
                    LoadLists();
                }              

            }

        }

        private void DOWNarrow_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if ((listBox1.SelectedIndex + 1) <= (listBox1.Items.Count - 1))
                {                    
                    string texto2 = _Urls.ElementAt(listBox1.SelectedIndex + 1);
                    _Urls.RemoveAt(listBox1.SelectedIndex + 1);
                    string texto1 = _Urls.ElementAt(listBox1.SelectedIndex );
                    _Urls.RemoveAt(listBox1.SelectedIndex);

                    _Urls.Insert(listBox1.SelectedIndex, texto2);
                    _Urls.Insert(listBox1.SelectedIndex + 1, texto1);                    

                    //Refresh
                    LoadLists();
                }

            }
        }

        private void RightRedArrow_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                _Urls.RemoveAt(listBox1.SelectedIndex);

                //Refresh
                LoadLists();
            }
        }

        private void LeftGreenArrow_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                _Urls.Add(_Urls2.ElementAt(listBox2.SelectedIndex));

                //Refresh
                LoadLists();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Enviar lista ordenada para display
            FormPics _guardalas = new FormPics(_Urls, formInit);
            _guardalas.Show();

            this.Close();
        }

        private void PopupLists_Load(object sender, EventArgs e)
        {

        }
    }
}
