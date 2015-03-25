using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class TPWebServiceClient : ITPWebServiceClient
    {
        public string GetResponse(Uri uri)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers["Content-Type"] = "application/json; charset=UTF-8";

            return webClient.DownloadString(uri);
        }
    }    
}
