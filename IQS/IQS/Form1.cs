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

        private void Form1_Load(object sender, EventArgs e)
        {
            //Botoes no inicio
            PanelContainer.Controls.Clear();
            UserControlButtons _Botoes = new UserControlButtons(this);
            PanelContainer.Controls.Add(_Botoes);
        }
    }
}
