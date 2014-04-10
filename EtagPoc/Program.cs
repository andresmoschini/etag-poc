using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EtagPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            var response = GetResponse(Properties.Settings.Default.Url);
            var lenght = GetLenght(response);
            var content = GetContent(response);
            Console.WriteLine("lenght: {0}", lenght);
            Console.WriteLine("content: {0}", content);
            Console.ReadLine();
        }

        static WebResponse GetResponse(string url)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return request.GetResponse();
        }

        static long GetLenght(WebResponse response)
        {
            return long.Parse(response.Headers["Content-Length"]);
        }

        static string GetContent(WebResponse response)
        {
            var stream = response.GetResponseStream();
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
