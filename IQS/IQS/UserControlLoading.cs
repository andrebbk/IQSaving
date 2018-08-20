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
            //Mostrar em vertical
            listView1.Alignment = ListViewAlignment.Left;

            if (Clipboard.GetText().ToString() != "")
            {
                string Dados = Clipboard.GetText().ToString();

                string[] data_ = Dados.Split('\n');

                //Lista com as strings copiadas
                List<string> _urls = data_.OfType<string>().ToList();

                //Remover /r/n
                foreach (string str in _urls.ToList())
                {
                    var itemIndex = _urls.FindIndex(x => x == str);
                    var item = _urls.ElementAt(itemIndex);
                    _urls.RemoveAt(itemIndex);
                    item = str.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                    _urls.Insert(itemIndex, item);
                }

                //Verificar se são urls
                foreach (string str2 in _urls.ToList())
                {
                    if (!String.IsNullOrWhiteSpace(str2))
                    {
                        if (!Uri.IsWellFormedUriString(str2, UriKind.Absolute))
                        {
                            //Remover o index item em causa
                            var itemIndex = _urls.FindIndex(x => x == str2);
                            var item = _urls.ElementAt(itemIndex);
                            _urls.RemoveAt(itemIndex);
                        }
                    }
                    else
                    {
                        //Remover o index item em causa
                        var itemIndex = _urls.FindIndex(x => x == str2);
                        var item = _urls.ElementAt(itemIndex);
                        _urls.RemoveAt(itemIndex);
                    }
                }                    

                //verificar se existe urls ou nao mostrar dados
                if(_urls.Count() < 1)
                {
                    listView1.Items.Add("Empty clipboard!");
                    return;
                }

                //Verificar se são urls de imagens
                foreach (string str3 in _urls)
                {
                    if(!String.IsNullOrWhiteSpace(str3))
                    {
                        listView1.Items.Add(str3);

                        for (int j = 0; j < listView1.Items.Count; j++)
                        {
                            if(listView1.Items[j].Text.Equals(str3))
                            {
                                if (Funcionalidades.IsImageUrl(str3))
                                {
                                    listView1.Items[j].BackColor = Color.Green;
                                }
                                else
                                {
                                    listView1.Items[j].BackColor = Color.Red;
                                }

                                break;
                            }
                            
                        }
                    }
                   
                }

            }
            else
            {
                listView1.Items.Add("Empty clipboard!");
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            FormInicio.ReturnBegun();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormInicio.ReturnBegun();
        }
    }
}
