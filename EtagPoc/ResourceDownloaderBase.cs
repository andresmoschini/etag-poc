using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EtagPoc
{
    public abstract class ResourceDownloaderBase
    {
        public string LastEtag { get; private set; }
        public string LastContent { get; private set; }

        public readonly string Uri;
        
        protected abstract void PrepareRequest(HttpWebRequest request);

        public ResourceDownloaderBase(string uri)
        {
            Uri = uri;
        }

        public string GetContent()
        {
            RevalidateLastContent();
            return LastContent;
        }

        private void RevalidateLastContent()
        {
            var request = (HttpWebRequest)WebRequest.Create(Uri);

            PrepareRequest(request);
            
            if (LastEtag != null && LastContent != null)
            {
                request.Headers.Add(HttpRequestHeader.IfNoneMatch, LastEtag);
            }
            
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                LastEtag = response.Headers[HttpResponseHeader.ETag];
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    LastContent = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                if (response == null || response.StatusCode != HttpStatusCode.NotModified)
                {
                    throw;
                }
            }
        }

    }
}
