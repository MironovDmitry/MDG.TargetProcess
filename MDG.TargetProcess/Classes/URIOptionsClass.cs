using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class URIOptions
    {
        readonly static string _apiURL = Properties.Settings.Default.tpAPIURL;
        readonly static string _token = Properties.Settings.Default.tpToken;

        public string EntityType { get; set; }
        public string IncludeStatement { get; set; }
        public string WhereStatement { get; set; }

        public Uri BuildUri()
        {
            StringBuilder uri = new StringBuilder(_apiURL);
            if (!String.IsNullOrEmpty(this.EntityType))
            {
                uri.Append(this.EntityType);
            }
            else
            {
                uri.Append("userstories");
            }
            uri.Append("?");
            if (!String.IsNullOrEmpty(this.IncludeStatement))
            {
                uri.Append("include=");
                uri.Append(this.IncludeStatement);
                uri.Append("&");
            }
            if (!String.IsNullOrEmpty(this.WhereStatement))
            {
                uri.Append("where=");
                uri.Append(this.WhereStatement);
                uri.Append("&");
            }
            uri.Append(_token);

            return new Uri(uri.ToString());
        }
    } 
}
