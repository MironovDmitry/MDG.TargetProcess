using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MDG.TargetProcess
{
    public class TP
    {
        readonly static string _apiURL = Properties.Settings.Default.tpAPIURL;
        readonly static string _token = Properties.Settings.Default.tpToken;

        private ITPWebServiceClient _webClient;

        public TP()
        {            
        }

        public ITPWebServiceClient TPWebServiceClient
        {
            get { return _webClient;}
            set { _webClient = value; }
        }
                
        public Uri BuildUri(URIOptions uriOptions)
        {
            StringBuilder uri = new StringBuilder(_apiURL);
            if (!String.IsNullOrEmpty(uriOptions.EntityType))
            {
                uri.Append(uriOptions.EntityType);
            }
            else
            {
                uri.Append("userstories");
            }
            uri.Append("?");
            if (!String.IsNullOrEmpty(uriOptions.IncludeStatement))
            {
                uri.Append("include=");
                uri.Append(uriOptions.IncludeStatement);
                uri.Append("&");
            }
            if (!String.IsNullOrEmpty(uriOptions.WhereStatement))
            {
                uri.Append("where=");
                uri.Append(uriOptions.WhereStatement);
                uri.Append("&");
            }
            uri.Append(_token);

            return new Uri(uri.ToString());
        }

        public Users GetUsers(URIOptions uriOptions)
        {
            Uri uri = BuildUri(uriOptions);
                        
            string response = _webClient.GetResponse(uri);

            //List<User> users = JsonConvert.DeserializeObject<List<User>>(response);
            Users users = GetObjects<Users>(response);
            return users;
        }

        public T GetObjects<T>(string jsonString) where T : new()
        {
            T objects = new T();
            objects = JsonConvert.DeserializeObject<T>(jsonString);            
            return objects;
        }

        public Users GetDevelopers()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            uriOptions.IncludeStatement = "[id,FirstName,LastName]";
            uriOptions.WhereStatement = "(IsActive eq 'true') and (role.id eq 1)";

            return GetUsers(uriOptions);
            //Uri uri = BuildUri(uriOptions);

            //string jsonResult = GetResponseFromWebService(uri);
            //dynamic result = JsonConvert.DeserializeObject(jsonResult);

            //List<User> developers = new List<User>();
            //foreach (var item in result.Items)
            //{
            //    User developer = new User();
            //    developer.Id = item.Id;
            //    developer.LastName = item.LastName;
            //    developer.FirstName = item.FirstName;

            //    developers.Add(developer);
            //    developer = null;
            //}

            //this.Developers = developers;
        }

        public void GetUserStoriesForUser(int userID)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "userstories";
            uriOptions.WhereStatement = "(Owner.Id eq " + userID.ToString() + ")";
        }        
    }


    public class URIOptions
    {
        public string EntityType { get; set; }
        public string IncludeStatement { get; set; }
        public string WhereStatement { get; set; }
    }          
    
}
