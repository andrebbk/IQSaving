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
    public partial class FormSavePics : Form
    {
        FormPics formPics;
        Form1 formInit;

        public FormSavePics(List<string> _urls, FormPics _form, Form1 _form2)
        {
            InitializeComponent();
            formPics = _form;
            formInit = _form2;
        }

        private void buttonLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            formPics.Close();

            //open inicio
            formInit.ReturnBegun();
            formInit.Show();
            
            this.Close();
        }
    }
}
