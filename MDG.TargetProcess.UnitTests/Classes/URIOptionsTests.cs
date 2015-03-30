using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using MDG.TargetProcess;

namespace TargetProcess.UnitTests
{
    [TestFixture]
    class URIOptionsTests
    {
        #region BuildUri tests
        [Test]
        [Category("BuildUri tests")]
        public void BuildUri_WasPassedUriOptionWithEntityTypeOnly_ReturnStringWithEntityType()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";

            Uri uri = uriOptions.BuildUri();

            StringAssert.Contains("users?token=", uri.ToString().ToLower());

        }

        [Test]
        [Category("BuildUri tests")]
        public void BuildUri_WasPassedUriOptionWithEntityTypeEmpty_ReturnStringWithEntityTypeSetToUserStory()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "";

            Uri uri = uriOptions.BuildUri();

            StringAssert.Contains("userstories?token=", uri.ToString().ToLower());
        }

        [Test]
        [Category("BuildUri tests")]
        public void BuildUri_WasPassedUriOptionWithIncludeStatement_ReturnStringWithIncludeStatement()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            uriOptions.IncludeStatement = "[id,FirstName,LastName]";

            Uri uri = uriOptions.BuildUri();

            StringAssert.Contains("users?include=[", uri.ToString().ToLower());
        }

        [Test]
        [Category("BuildUri tests")]
        public void BuildUri_WasPassedUriOptionWithWhereStatement_ReturnStringWithWhereStatement()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            uriOptions.WhereStatement = "(IsActive eq 'true')";

            Uri uri = uriOptions.BuildUri();

            StringAssert.Contains("users?where=(", uri.ToString().ToLower());
        }

        [Test]
        [Category("BuildUri tests")]
        public void BuildUri_WasPassedUriOptionWithIncludeAndWhereStatements_ReturnStringWithIncludeAndWhereStatements()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            uriOptions.IncludeStatement = "[id,FirstName,LastName]";
            uriOptions.WhereStatement = "(IsActive eq 'true')";

            Uri uri = uriOptions.BuildUri();

            StringAssert.Contains("users?include=[", uri.ToString().ToLower());
            StringAssert.Contains("where=(", uri.ToString().ToLower());
        }
        #endregion
    }
}
