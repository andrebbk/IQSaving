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
    public partial class UserControlButtons : UserControl
    {
        Form1 FormInicio;

        public UserControlButtons(Form1 _FormInicio)
        {
            InitializeComponent();
            FormInicio = _FormInicio;
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            FormInicio.Close();
        }
    }
}
