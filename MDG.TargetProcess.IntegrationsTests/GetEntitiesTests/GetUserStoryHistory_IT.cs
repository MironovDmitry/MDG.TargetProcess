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
            TP tp = new TP(new TPWebServiceClient());
            tp.TPWebServiceClient = new TPWebServiceClient();

            UserStoryHistiories histories = tp.GetUserStoryHistories("In progress");

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.EntityState.Name.ToLower() == "in progress"));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUserStoryHistories_CalledForStatusPlanned_ReturnsUserStoryHistoriesOnlyForStatusPlanned()
        {
            TP tp = new TP(new TPWebServiceClient());
            tp.TPWebServiceClient = new TPWebServiceClient();

            UserStoryHistiories histories = tp.GetUserStoryHistories("Planned");

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.EntityState.Name.ToLower() == "planned"));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUserStoryHistories_CalledForUserStoryId15_ReturnsUserStoryHistoriesOnlyForUserStoryID15()
        {
            TP tp = new TP(new TPWebServiceClient());
            tp.TPWebServiceClient = new TPWebServiceClient();

            UserStoryHistiories histories = tp.GetUserStoryHistories(15);

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.UserStory.Id == 15));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUserStoryHistories_CalledForUserStoryId31390AndStatusInProgress_ReturnsUserStoryHistoriesOnlyForUserStoryID15AndStatusInProgress()
        {
            TP tp = new TP(new TPWebServiceClient());
            tp.TPWebServiceClient = new TPWebServiceClient();

            UserStoryHistiories histories = tp.GetUserStoryHistories(31390,"In Progress");

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.UserStory.Id == 31390));
            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.EntityState.Name.ToLower() == "in progress"));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUserStoryHistories_CalledForPeriod20150326To20150327_ReturnsUserStoryHistoriesOnlyForPeriod20150326To20150327()
        {
            TP tp = new TP(new TPWebServiceClient());
            tp.TPWebServiceClient = new TPWebServiceClient();
            DateTime startDate = new DateTime(2015, 3, 26);
            DateTime endDate = new DateTime(2015, 3, 27);
            DateTime testDate1 = new DateTime(2015, 3, 25);

            UserStoryHistiories histories = tp.GetUserStoryHistories(startDate,endDate);

            Assert.That(histories.Items, Has.All.Not.Matches<UserStoryHistiory>(h => h.Date.Date == testDate1.Date));
            Assert.That(histories.Items, Has.Some.Matches<UserStoryHistiory>(h => h.Date.Date == startDate.Date));
            Assert.That(histories.Items, Has.Some.Matches<UserStoryHistiory>(h => h.Date.Date == endDate.Date));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUserStoryHistories_CalledForUserStoryID31390AndPeriod20150326To20150327_ReturnsUserStoryHistoriesOnlyForUserStoryID31390And20150327()
        {
            TP tp = new TP(new TPWebServiceClient());
            tp.TPWebServiceClient = new TPWebServiceClient();
            DateTime startDate = new DateTime(2015, 3, 26);
            DateTime endDate = new DateTime(2015, 3, 27);
            DateTime testDate1 = new DateTime(2015, 3, 25);

            UserStoryHistiories histories = tp.GetUserStoryHistories(31390, startDate, endDate);

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.UserStory.Id == 31390));
            Assert.That(histories.Items, Has.All.Not.Matches<UserStoryHistiory>(h => h.Date.Date == testDate1.Date));            
            Assert.That(histories.Items, Has.Some.Matches<UserStoryHistiory>(h => h.Date.Date == endDate.Date));
        }

        [Test]
        [Category("Integration tests")]
        [Category("Read data")]
        public void GetUserStoryHistories_CalledForUserStoryID31390AndPeriod20150326To20150327AndStatusUAT_ReturnsUserStoryHistoriesOnlyForUserStoryID31390And20150327AndStatusUAT()
        {
            TP tp = new TP(new TPWebServiceClient());
            tp.TPWebServiceClient = new TPWebServiceClient();
            DateTime startDate = new DateTime(2015, 3, 26);
            DateTime endDate = new DateTime(2015, 3, 27);
            DateTime testDate1 = new DateTime(2015, 3, 25);            

            UserStoryHistiories histories = tp.GetUserStoryHistories(31390, "User Acceptance testing", startDate, endDate);

            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.UserStory.Id == 31390));
            Assert.That(histories.Items, Has.All.Not.Matches<UserStoryHistiory>(h => h.Date.Date == testDate1.Date));            
            Assert.That(histories.Items, Has.Some.Matches<UserStoryHistiory>(h => h.Date.Date == endDate.Date));
            Assert.That(histories.Items, Has.All.Matches<UserStoryHistiory>(h => h.EntityState.Name.ToLower() == "user acceptance testing"));
        }
    }
}
