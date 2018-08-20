﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQS
{
    public class Funcionalidades
    {
        //Buscar so urls de imagens
        public static List<string> BuscarUrls()
        {
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
                    return null;

                //Enviar urls de imagens
                List<string> _lista = new List<string>();

                foreach (string str3 in _urls)
                {
                    if(!String.IsNullOrWhiteSpace(str3) && IsImageUrl(str3))
                        _lista.Add(str3);
                }

                return _lista;

            }
            else
            {
                //Não existe nada no clipboard
                return null;
            }
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
    }
}
