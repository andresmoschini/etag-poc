using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace EtagPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = Properties.Settings.Default.Url;
            TimeSpan? _checkTimeOut = null;
            var downloader = new GenericResourceDownloader(uri, (request) =>
            {
                if (_checkTimeOut.HasValue)
                    request.Timeout = (int)_checkTimeOut.Value.TotalMilliseconds;
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            });
            Console.WriteLine("ENTER to request");
            Console.ReadLine();
            Console.WriteLine(downloader.GetContent());
            Console.WriteLine("ENTER to request");
            Console.ReadLine();
            Console.WriteLine(downloader.GetContent());
            Console.WriteLine("ENTER to request");
            Console.ReadLine();
            Console.WriteLine(downloader.GetContent());
            Console.WriteLine("ENTER to finish");
            Console.ReadLine();
        }
    }
}
