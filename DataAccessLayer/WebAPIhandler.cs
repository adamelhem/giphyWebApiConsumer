using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace DataAccessLayer
{
    public class WebAPIhandler
    {
        public  Task<T> GetAPIdataResponse<T>(string url)
        {
            var jsonResponse = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            //request.ContentType = contentType;
            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = 20000;
            request.Proxy = null;

            var task = Task.Factory.FromAsync(request.BeginGetResponse, 
                       asyncResult => request.EndGetResponse(asyncResult),null);

            return task.ContinueWith(t =>
            {
                var jsonData = ReadStreamFromResponse(t.Result);
                return JsonConvert.DeserializeObject<T>(jsonData);
            });
        }
         
           string ReadStreamFromResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(responseStream))
            {
                //Need to return this response 
                string strContent = sr.ReadToEnd();
                return strContent;
            }
        }

    }
}