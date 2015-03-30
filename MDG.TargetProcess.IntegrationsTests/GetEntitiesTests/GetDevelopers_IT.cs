using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using MDG.TargetProcess;

namespace MDG.TargetProcess.IntegrationsTests.GetEntitiesTests
{
    [TestFixture]
    class GetDevelopers_IT
    {
        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetDevelopers_CalledWithoutParameters_ReturnsMoreThanOneDeveloper()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();

            Users developers = tp.GetDevelopers();

            Assert.Greater(developers.Items.Count, 0);
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetDevelopers_CalledWithoutParameters_ReturnsDevelopersOnly()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();

            Users developers = tp.GetDevelopers();

            Assert.That(developers.Items, Has.All.Matches<User>(u => u.Role.Name == "Developer"));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetDevelopers_CalledWithoutParameters_ReturnsActiveAndInactiveDevelopers()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();

            Users developers = tp.GetDevelopers();

            Assert.That(developers.Items, Has.Some.Matches<User>(u => u.IsActive == false));
        }
    }
}
