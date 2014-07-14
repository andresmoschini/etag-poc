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
    public abstract class ResourceDownloaderBase
    {
        public readonly string Uri;
        
        protected abstract void PrepareRequest(HttpWebRequest request);

        public ResourceDownloaderBase(string uri)
        {
            Uri = uri;
        }

        public string GetContent()
        {
            var client = new System.Net.WebClient();
            client.CachePolicy = new RequestCachePolicy(RequestCacheLevel.Revalidate);
            var file = client.DownloadString(Uri);
            return file;
        }

    }
}
