using System;
using TechTalk.SpecFlow;

using NUnit.Framework;

namespace MDG.TargetProcess.Specs
{
    [Binding]
    public class GetDevelopersSteps
    {
        private readonly SharedContext sharedContext;
        private Users developers;

        public GetDevelopersSteps(SharedContext sharedContext)
        {
            this.sharedContext = sharedContext;
        }

        [When(@"Я не указываю параметров при вызове метода GetDevelopers")]
        public void ЕслиЯНеУказываюПараметровПриВызовеМетодаGetDevelopers()
        {
            developers = sharedContext.tp.GetDevelopers();
        }

        [When(@"Я указываю параметр ""(.*)"" как True метода GetDevelopers")]
        public void ЕслиЯУказываюПараметрКакTrueМетодаGetDevelopers(string p0)
        {
            developers = sharedContext.tp.GetDevelopers(true);
        }

        [Then(@"Метод возвращает только разработчиков")]
        public void ТоМетодВозвращаетТолькоРазработчиков()
        {
            Assert.That(developers.Items, Has.All.Matches<User>(u => u.Role.Name == "Developer"));
        }
                
        [Then(@"Метод возвращает только активных разработчиков")]
        public void ТоМетодВозвращаетТолькоАктивныхРазработчиков()
        {
            Assert.That(developers.Items, Has.All.Matches<User>(u => u.IsActive == true));
        }

        [Then(@"Количество разработчиков больше одного")]
        public void ТоКоличествоРазработчиковБольшеОдного()
        {
            Assert.Greater(developers.Items.Count, 1);
        }

        [Then(@"Метод возвращает и активных и неактивных разработчиков")]
        public void ТоМетодВозвращаетИАктивныхИНеактивныхРазработчиков()
        {
            Assert.That(developers.Items, Has.Some.Matches<User>(u => u.IsActive == false));
            Assert.That(developers.Items, Has.Some.Matches<User>(u => u.IsActive == true));
        }
    }
}
