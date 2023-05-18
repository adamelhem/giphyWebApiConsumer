using Newtonsoft.Json;
using System.Net;

namespace DataAccessLayer
{
    public class WebAPIhandler
    {
        public  T GetAPIdataResponse<T>(string url)
        {
            var jsonResponse = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonResponse = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}