using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EtagPoc
{
    public class GenericResourceDownloader : ResourceDownloaderBase
    {
        private readonly Action<HttpWebRequest> prepareRequest;
        public GenericResourceDownloader(string uri, Action<HttpWebRequest> prepareRequest)
            : base(uri)
        {
            this.prepareRequest = prepareRequest;
        }
        protected override void PrepareRequest(HttpWebRequest request)
        {
            prepareRequest(request);
        }
    }
}
