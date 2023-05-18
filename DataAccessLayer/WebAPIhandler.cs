using DO.Request;
using Newtonsoft.Json;
using System.Net;

namespace DataAccessLayer
{
    public class WebAPIhandler : IWebAPIhandler
    {
        public async Task<T> GetAPIdataResponse<T>(IGiphyRequest urlRequest)
        {
            var jsonResponse = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(urlRequest.url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            //request.ContentType = contentType;
            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = 20000;
            request.Proxy = null;

            var task = Task.Factory.FromAsync(request.BeginGetResponse,
                       asyncResult => request.EndGetResponse(asyncResult), null);

            return await task.ContinueWith(t =>
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