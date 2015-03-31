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
    class GetUserStoryHistory_IT
    {
        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUserStoryHistories_CalledForStatusInProgress_ReturnsUserStoryHistoriesOnlyForStatusInProgress()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();

            UserStoryHistiories histories = tp.GetUserStoryHistories("In progress");

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.EntityState.Name == "In Progress"));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUserStoryHistories_CalledForStatusPlanned_ReturnsUserStoryHistoriesOnlyForStatusPlanned()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();

            UserStoryHistiories histories = tp.GetUserStoryHistories("Planned");

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.EntityState.Name == "Planned"));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUserStoryHistories_CalledForUserStoryId15_ReturnsUserStoryHistoriesOnlyForUserStoryID15()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();

            UserStoryHistiories histories = tp.GetUserStoryHistories(15);

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.UserStory.Id == 15));
        }
    }
}
