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
        public void GetUserStoryHistories_CalledForStatusInProgress_ReturnsUserStoryHistoriesOnlyForStatusInProgress()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();

            UserStoryHistiories histories = tp.GetUserStoryHistories("In progress");

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.EntityState.Name == "In Progress"));
        }

        [Test]
        public void GetUserStoryHistories_CalledForStatusPlanned_ReturnsUserStoryHistoriesOnlyForStatusPlanned()
        {
            TP tp = new TP();
            tp.TPWebServiceClient = new TPWebServiceClient();

            UserStoryHistiories histories = tp.GetUserStoryHistories("Planned");

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.EntityState.Name == "Planned"));
        }
    }
}
