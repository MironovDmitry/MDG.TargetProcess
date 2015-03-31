using System;
using System.Net;

using NUnit.Framework;

using MDG.TargetProcess;

namespace MDG.TargetProcess.IntegrationsTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUsers_CalledWithoutParameters_ReturnsMoreThanOneUser()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();
            Users users = tp.GetUsers();

            Assert.Greater(users.Items.Count, 0);           
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUsers_CalledWithoutParameters_ReturnsActiveUsersOnly()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();
            Users users = tp.GetUsers();
                        
            Assert.That(users.Items, Has.All.Matches<User>(u => u.IsActive == true));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUsers_CalledWithParameterIncludeInActiveSetToTrue_ReturnsActiveAndInactiveUsers()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();
            Users users = tp.GetUsers(true);

            Assert.That(users.Items, Has.Some.Matches<User>(u => u.IsActive == false));
        }
    }
}
