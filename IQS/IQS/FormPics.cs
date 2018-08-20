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
    public partial class FormPics : Form
    {
        Form1 formInit;

        //Lista de fotos
        List<string> _Urls;

        public FormPics(List<string> _dados, Form1 _formInicio)
        {
            InitializeComponent();
            _Urls = new List<string>();
            _Urls = _dados;


            formInit = _formInicio;
        }

        private void pictureBoxMini_Click(object sender, EventArgs e)
        {
            //Minimizar
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonLeave_Click(object sender, EventArgs e)
        {
            //Sair para o inicio
            formInit.ReturnBegun();
            formInit.Show();

            //Fechar este form
            this.Close();
        }

        private void FormPics_Load(object sender, EventArgs e)
        {

        }
    }
}
