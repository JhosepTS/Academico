using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Academico.Negocio
{
    public class FuenteExterna
    {
        public dynamic Get(string url)
        {
            // Crear la solicitud HTTP
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;

            // Manejar la respuesta HTTP en un bloque using para asegurar que los recursos se liberen adecuadamente
            using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse())
            {
                using (Stream myStream = myHttpWebResponse.GetResponseStream())
                {
                    if (myStream == null)
                        throw new ApplicationException("No se pudo obtener el flujo de respuesta del servidor.");

                    using (StreamReader myStreamReader = new StreamReader(myStream))
                    {
                        // Leer los datos
                        string datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

                        // Deserializar los datos y devolverlos
                        dynamic data = JsonConvert.DeserializeObject(datos);
                        return data;
                    }
                }
            }
        }
    }
}
