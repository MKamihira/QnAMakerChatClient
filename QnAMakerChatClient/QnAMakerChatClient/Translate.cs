using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace QnAMakerChatClient
{
    class Translate
    {
        public string Translator(string token, string question)
        {
            string translated = string.Empty;
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" +
        System.Web.HttpUtility.UrlEncode(question) + "&appid=Bearer " + token + "&to=ja";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            WebResponse response = null;

            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                    translated = (string)dcs.ReadObject(stream);
                }
            }
            catch(Exception ex)
            {

            }
            return translated;
        }
    }
}
