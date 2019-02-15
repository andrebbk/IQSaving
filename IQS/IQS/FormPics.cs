using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            PopulateListView();
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

        private void buttonLeave_Click(object sender, EventArgs e)
        {
            //Sair para o inicio
            formInit.Show();

            //Fechar este form
            this.Close();
        }

        private void PopulateListView()
        {
            listViewFotos.View = View.LargeIcon;

            ImageList _images = new ImageList();
            _images.ImageSize = new Size(192, 192);
            _images.ColorDepth = ColorDepth.Depth32Bit;

            foreach (string str in _Urls)
            {
                using (MemoryStream ms = new MemoryStream(Funcionalidades.GetImageAsByteArray(str)))
                {
                    _images.Images.Add(Image.FromStream(ms));
                }
            }
            
            listViewFotos.LargeImageList = _images;
            

            for (int j = 0; j < _images.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listViewFotos.Items.Add(item);
            }

        }

        private Image LoadImage(string url)
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(url);

            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();

            Bitmap bmp = new Bitmap(responseStream);

            responseStream.Dispose();

            return bmp;
        }

        private void FormPics_Load(object sender, EventArgs e)
        {

        }

        private void buttonSavePhotos_Click(object sender, EventArgs e)
        {
            FormSavePics _SaveNow = new FormSavePics(_Urls, this, formInit);
            _SaveNow.Show();
        }
    }
}
