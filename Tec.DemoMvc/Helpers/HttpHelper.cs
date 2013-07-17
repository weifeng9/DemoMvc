using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Tec.DemoMvc.Helpers
{
    public class HttpHelper
    {
        public static string HttpPost(string uri, string parameters)
        {
            var req = System.Net.WebRequest.Create(uri);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            // Add parameters to post
            var data = Encoding.ASCII.GetBytes(parameters);
            req.ContentLength = data.Length;
            var os = req.GetRequestStream();
            os.Write(data, 0, data.Length);
            os.Close();

            // Do the post and get the response.
            System.Net.WebResponse resp = null;
            resp = req.GetResponse();

            return GetResponseData(resp);
        }

        public static string GetResponseData(System.Net.WebResponse resp)
        {
            if (resp == null) return "";
            var sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}