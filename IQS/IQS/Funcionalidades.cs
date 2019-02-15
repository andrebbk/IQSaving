using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQS
{
    public class Funcionalidades
    {
        //Buscar so urls de imagens
        public static List<string> BuscarUrls(string Dados)
        {
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
            if (_urls.Count() < 1)
                return null;

            //Enviar urls de imagens
            List<string> _lista = new List<string>();

            foreach (string str3 in _urls)
            {
                if (!String.IsNullOrWhiteSpace(str3) && IsImageUrl(str3))
                    _lista.Add(str3);
            }

            return _lista;           
        }

        //Buscar so urls
        public static List<string> BuscarUrls2(string Dados)
        {
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
            if (_urls.Count() < 1)
                return null;

            return _urls;
        }

        //Verificar urls
        public static bool IsImageUrl(string URL)
        {
            //separar string pelos pontos finais
            string[] parts = URL.Split('.');

            //última parte sempre o formato da imagem de for uma url de image
            switch(parts[parts.Count() - 1].ToLower())
            {
                case "jpg":
                    return true;

                case "jpeg":
                    return true;

                case "png":
                    return true;

                default:
                    return false;
            }
        }

        //Buscar Url do gram
        public static List<string> BuscarUrlsGram(List<string> urls)
        {
            List<string> listaAUX = new List<string>();

            try
            {
                foreach (string strurl in urls)
                {
                    using (var webClient = new System.Net.WebClient())
                    {
                        //Parse with JSON.Net
                        var jsonTexto = webClient.DownloadString(strurl);

                        string[] partes = jsonTexto.Split('<');
                        string linha = " ";

                        for (int i = 0; i < partes.Length; i++)
                        {
                            //Estudo do json
                            if (partes[i].Contains("meta property=\"og:image\" content=\""))
                            {
                                linha = partes[i];
                                break;
                            }
                        }

                        if (linha != " ")
                        {
                            string[] partes2 = linha.Split('\"');

                            //Adicionar à lista
                            listaAUX.Add(partes2[3]);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            if (listaAUX.Count > 0)
                return listaAUX;
            else
                return null;
        }

        public static byte[] GetImageAsByteArray(string urlImage)
        {
            var webClient = new WebClient();
            return webClient.DownloadData(urlImage);
        }
    }
}
