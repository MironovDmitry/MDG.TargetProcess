using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NSubstitute;

using MDG.TargetProcess;

namespace TargetProcess.UnitTests
{
    [TestFixture]
    class TPWebServiceClientTests
    {
        [Test]
        [Category("WebClient Get Reponse tests")]
        public void GetResponse_WhenRequestedUsers_UriContainsString_users()
        {
            var fakeTPWebServiceClient = Substitute.For<ITPWebServiceClient>();                                                
            TP tp = new TP();
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            Uri uri = uriOptions.BuildUri();
            tp.TPWebServiceClient = fakeTPWebServiceClient;

            tp.TPWebServiceClient.GetResponse(uri);
            
            fakeTPWebServiceClient.Received().GetResponse(Arg.Is<Uri>(u => u.OriginalString.Contains("users?")));
        }

        [Test]
        [Category("WebClient Get Reponse tests")]
        public void GetResponse_WhenRequestedDevelopers_UriContainsStrings_usersAndRoleIDEqualsOneAndActiveIsTrue()
        {
            var fakeTPWebServiceClient = Substitute.For<ITPWebServiceClient>();
            TP tp = new TP();
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            uriOptions.IncludeStatement = "[id,FirstName,LastName]";
            uriOptions.WhereStatement = "(IsActive eq 'true') and (role.id eq 1)";
            Uri uri = uriOptions.BuildUri();
            tp.TPWebServiceClient = fakeTPWebServiceClient;

            tp.TPWebServiceClient.GetResponse(uri);
            
            fakeTPWebServiceClient.Received().GetResponse(Arg.Is<Uri>(u => u.OriginalString.Contains("users?") && u.OriginalString.Contains("(IsActive eq 'true') and (role.id eq 1)")));
        }

    }
}
