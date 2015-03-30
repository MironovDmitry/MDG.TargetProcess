﻿using System;
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
        private ITPWebServiceClient _webClient;

        public TP()
        {            
        }

        public ITPWebServiceClient TPWebServiceClient
        {
            get { return _webClient;}
            set { _webClient = value; }
        }
        

        public Users GetUsers(URIOptions uriOptions)
        {
            Uri uri = uriOptions.BuildUri();
                        
            string response = _webClient.GetResponse(uri);

            //List<User> users = JsonConvert.DeserializeObject<List<User>>(response);
            Users users = ObjectsConverter.GetObjects<Users>(response);
            return users;
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

        public UserStories GetUserStories(URIOptions uriOptions)
        {
            uriOptions.EntityType = "userstories";
            Uri uri = uriOptions.BuildUri();

            string response = _webClient.GetResponse(uri);
            UserStories userStories = ObjectsConverter.GetObjects<UserStories>(response);
            return userStories;
        }

        public UserStories GetUserStoriesForUser(int userID)
        {
            URIOptions uriOptions = new URIOptions();            
            uriOptions.WhereStatement = "(Owner.Id eq " + userID.ToString() + ")";

            return GetUserStories(uriOptions);
        }

        public Bugs GetBugs()
        {
            return GetBugsByUriOptions(new URIOptions());
        }

        public Bugs GetBugsForUser(int userID)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.WhereStatement = "(Owner.Id eq " + userID.ToString() + ")";

            return GetBugsByUriOptions(uriOptions);
        }

        private Bugs GetBugsByUriOptions(URIOptions uriOptions)
        {
            uriOptions.EntityType = "bugs";
            Uri uri = uriOptions.BuildUri();

            return ObjectsConverter.GetObjects<Bugs>(_webClient.GetResponse(uri));
        }
        public void AssignDeveloper()
        {
            throw new NotImplementedException();
        }

        public void AssignRequester()
        {
            throw new NotImplementedException();
        }

        public void AssignTeam()
        {
            throw new NotImplementedException();
        }

        public void AddComment()
        {
            throw new NotImplementedException();
        }

        public void AddRequest()
        {
            throw new NotImplementedException();
        }

        public void AddUserStory()
        {
            throw new NotImplementedException();
        }

        public void AddBug()
        {
            throw new NotImplementedException();
        }

        public int GetDeveloperID(string developerName)
        {
            throw new NotImplementedException();
        }

        public int GetRequesterID(string requesterName)
        {
            throw new NotImplementedException();
        }

        public int getInitialEntityStateID(int projectID, string tpEntityType)
        {
            throw new NotImplementedException();
        }

        public void RemoveRequesters()
        {
            throw new NotImplementedException();
        }
    }


             
    
}
