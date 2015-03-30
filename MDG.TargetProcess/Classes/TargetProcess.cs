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
        

        public Users GetUsers()
        {
            return getUsersByUriOption(new URIOptions());
        }

        private Users getUsersByUriOption(URIOptions uriOptions)
        {
            uriOptions.EntityType = "users";
            Uri uri = uriOptions.BuildUri();

            return ObjectsConverter.GetObjects<Users>(_webClient.GetResponse(uri));
        }

        public Users GetDevelopers()
        {
            URIOptions uriOptions = new URIOptions();                        
            uriOptions.WhereStatement = "(IsActive eq 'true') and (role.id eq 1)";

            return getUsersByUriOption(uriOptions);
        }

        public UserStories GetUserStories()
        {
            return getUserStoriesByUriOptions(new URIOptions());
        }

        public UserStories GetUserStories(int userID)
        {
            URIOptions uriOptions = new URIOptions();            
            uriOptions.WhereStatement = "(Owner.Id eq " + userID.ToString() + ")";

            return getUserStoriesByUriOptions(uriOptions);
        }

        private UserStories getUserStoriesByUriOptions(URIOptions uriOptions)
        {
            uriOptions.EntityType = "userstories";
            Uri uri = uriOptions.BuildUri();

            return ObjectsConverter.GetObjects<UserStories>(_webClient.GetResponse(uri));
        }

        public Bugs GetBugs()
        {
            return getBugsByUriOptions(new URIOptions());
        }

        public Bugs GetBugs(int userID)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.WhereStatement = "(Owner.Id eq " + userID.ToString() + ")";

            return getBugsByUriOptions(uriOptions);
        }

        private Bugs getBugsByUriOptions(URIOptions uriOptions)
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
