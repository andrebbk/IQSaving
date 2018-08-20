using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQS
{
    public partial class UserControlLoading : UserControl
    {
        Form1 FormInicio;

        public UserControlLoading(Form1 _FormInicio)
        {
            InitializeComponent();
            FormInicio = _FormInicio;
        }

        private void UserControlLoading_Load(object sender, EventArgs e)
        {


            if (Clipboard.GetText().ToString() != "")
            {
                string Dados = Clipboard.GetText().ToString();

                string[] data_ = Dados.Split('\n');

                List<string> _urls = data_.OfType<string>().ToList();

                foreach (string str in _urls)
                {
                    str.Replace(" ", string.Empty);
                    str.Replace("\r", string.Empty);
                }

                foreach (string str in _urls)
                {
                    listBox1.Items.Add(str);
                }

            }
            else
            {
                listBox1.Items.Add("Empty clipboard!");
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            FormInicio.ReturnBegun();
        }
    }
}
