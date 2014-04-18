using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EtagPoc
{
    public class SimpleResourceDownloader : ResourceDownloaderBase
    {
        public TimeSpan? TimeOut { get; set; }
        public SimpleResourceDownloader(string uri)
            : base(uri)
        {
        }
        protected override void PrepareRequest(HttpWebRequest request)
        {
            if (TimeOut.HasValue)
            {
                request.Timeout = (int)TimeOut.Value.TotalMilliseconds;
            }
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        }
    }
}
