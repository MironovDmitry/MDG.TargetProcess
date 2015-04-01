using System;
using TechTalk.SpecFlow;

using NUnit.Framework;

using MDG.TargetProcess;

namespace MDG.TargetProcess.Specs
{
    [Binding]
    public class GetUsersSteps
    {
        private readonly SharedContext sharedContext;

        private Users _users;

        public GetUsersSteps(SharedContext sharedContext)
        {
            this.sharedContext = sharedContext;
        }
        [Given(@"Класс TP инициализирован")]
        public void ДопустимКлассTPИнициализирован()
        {
            sharedContext.tp = new TP(new TPWebServiceClient() { });
        }

        [When(@"Я не указываю параметров при вызове метода GetUsers")]
        public void ЕслиЯНеУказываюПараметровПриВызовеМетодаGetUsers()
        {
            _users = sharedContext.tp.GetUsers();
        }

        [When(@"Я указываю параметр (.*) как True метода GetUsers")]
        public void ЕслиЯУказываюПараметрКакTrueМетодаGetUsers(string p0)
        {
            _users = sharedContext.tp.GetUsers(true);
        }

        [Then(@"Метод возвращает только активных пользователей")]
        public void ТоМетодВозвращаетТолькоАктивныхПользователей()
        {
            Assert.That(_users.Items, Has.All.Matches<User>(u => u.IsActive == true));
        }

        [Then(@"Метод возвращает и активных и неактивных пользователей")]
        public void ТоМетодВозвращаетИАктивныхИНеактивныхПользователей()
        {
            Assert.That(_users.Items, Has.Some.Matches<User>(u => u.IsActive == false));
            Assert.That(_users.Items, Has.Some.Matches<User>(u => u.IsActive == true));
        }

        [Then(@"Количество пользователей больше одного")]
        public void ТоКоличествоПользователейБольшеОдного()
        {
            Assert.Greater(_users.Items.Count, 1);
        }

    }
}
