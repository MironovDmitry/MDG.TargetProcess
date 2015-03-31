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
        private ITPWebServiceClient _webClient;

        public TP()
        {            
        }

        public ITPWebServiceClient TPWebServiceClient
        {
            get { return _webClient;}
            set { _webClient = value; }
        }
        

        public Users GetUsers(bool includeInActive = false)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            if (!includeInActive)
            {
                uriOptions.WhereStatement = "(IsActive eq 'true')";
            }
            return getUsersByUriOption(uriOptions.BuildUri());
        }

        private Users getUsersByUriOption(Uri uri)
        {   
            return ObjectsConverter.GetObjects<Users>(_webClient.GetResponse(uri));
        }

        public Users GetDevelopers(bool includeInActive = false)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            if (!includeInActive)
            {
                uriOptions.WhereStatement = "(role.id eq 1) and (IsActive eq 'true')";
            }
            else
            { 
                uriOptions.WhereStatement = "(role.id eq 1)";
            }
            
            return getUsersByUriOption(uriOptions.BuildUri());
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

        public UserStoryHistiories GetUserStoryHistories(int userStoryID)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "UserStoryHistories";
            uriOptions.WhereStatement = "(UserStory.Id eq " + userStoryID.ToString() + ")";

            return getUserStoryHistoriesByUriOptions(uriOptions);
        }

        public UserStoryHistiories GetUserStoryHistories(string statusName)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "UserStoryHistories";
            uriOptions.WhereStatement = "(EntityState.Name eq '" + statusName + "')";

            return getUserStoryHistoriesByUriOptions(uriOptions);
        }

        public UserStoryHistiories GetUserStoryHistories(int userStoryID, string statusName)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "UserStoryHistories";
            uriOptions.WhereStatement = "(UserStory.Id eq " + userStoryID.ToString() + ") and (EntityState.Name eq '" + statusName + "')";

            return getUserStoryHistoriesByUriOptions(uriOptions);
        }

        private UserStoryHistiories getUserStoryHistoriesByUriOptions(URIOptions uriOptions)
        {
            Uri uri = uriOptions.BuildUri();

            return ObjectsConverter.GetObjects<UserStoryHistiories>(_webClient.GetResponse(uri));
        }

        public UserStoryHistiories GetUserStoryHistories(DateTime startDate, DateTime endDate)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "UserStoryHistories";
            uriOptions.WhereStatement = "(Date gte '" + startDate.ToString("yyyy-MM-dd") + "') and (Date lte '" + endDate.ToString("yyyy-MM-dd") + "')";

            return getUserStoryHistoriesByUriOptions(uriOptions);
        }

        public UserStoryHistiories GetUserStoryHistories(int userStoryID, DateTime startDate, DateTime endDate)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "UserStoryHistories";
            uriOptions.WhereStatement = "(UserStory.Id eq " + userStoryID.ToString() + ") and (Date gte '" + startDate.ToString("yyyy-MM-dd") + "') and (Date lte '" + endDate.ToString("yyyy-MM-dd") + "')";

            return getUserStoryHistoriesByUriOptions(uriOptions);
        }

        public UserStoryHistiories GetUserStoryHistories(int userStoryID, string statusName, DateTime startDate, DateTime endDate)
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "UserStoryHistories";
            uriOptions.WhereStatement = "(UserStory.Id eq " + userStoryID.ToString() + ") and (Date gte '" + startDate.ToString("yyyy-MM-dd") + "') and (Date lte '" + endDate.ToString("yyyy-MM-dd") + "') and (EntityState.Name eq '" + statusName + "')";

            return getUserStoryHistoriesByUriOptions(uriOptions);
        }

        #region Not implemented
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
        #endregion
    }


             
    
}
