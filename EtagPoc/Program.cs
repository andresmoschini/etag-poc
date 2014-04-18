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
            var downloader = new SimpleResourceDownloader(Properties.Settings.Default.Url);
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
