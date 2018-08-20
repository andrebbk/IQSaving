using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IQS
{
    public class Funcionalidades
    {
        public void MoveToUrls(Form1 _formInicio)
        {

        }

        public static bool doesImageExistRemotely(string uriToImage)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriToImage);
            request.Method = "HEAD";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK && response.ContentType == "image/jpg")
                {
                    response.Close();
                    return true;
                }
                else
                {
                    response.Close();
                    return false;
                }                
            }
            catch
            {
                return false;                
            }
           
        }

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
