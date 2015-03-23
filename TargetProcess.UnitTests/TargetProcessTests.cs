using System;

using NUnit.Framework;

using MDG.TargetProcess;

namespace MDG.TargetProcess.UnitTests
{
    [TestFixture]
    public class TargetProcessTests
    {
        [Test]
        public void BuildUri_WasPassedUriOptionWithEntityTypeOnly_ReturnStringWithEntityType()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";

            TP tp = new TP();
            Uri uri = tp.BuildUri(uriOptions);

            StringAssert.Contains("users?token=", uri.ToString().ToLower());

        }

        [Test]
        public void BuildUri_WasPassedUriOptionWithEntityTypeEmpty_ReturnStringWithEntityTypeSetToUserStory()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "";

            TP tp = new TP();
            Uri uri = tp.BuildUri(uriOptions);

            StringAssert.Contains("userstories?token=", uri.ToString().ToLower());
        }

        [Test]
        public void BuildUri_WasPassedUriOptionWithIncludeStatement_ReturnStringWithIncludeStatement()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            uriOptions.IncludeStatement = "[id,FirstName,LastName]";

            TP tp = new TP();
            Uri uri = tp.BuildUri(uriOptions);

            StringAssert.Contains("users?include=[", uri.ToString().ToLower());
        }

        [Test]
        public void BuildUri_WasPassedUriOptionWithWhereStatement_ReturnStringWithWhereStatement()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            uriOptions.WhereStatement = "(IsActive eq 'true')";

            TP tp = new TP();
            Uri uri = tp.BuildUri(uriOptions);

            StringAssert.Contains("users?where=(", uri.ToString().ToLower());
        }

        [Test]
        public void BuildUri_WasPassedUriOptionWithIncludeAndWhereStatements_ReturnStringWithIncludeAndWhereStatements()
        {
            URIOptions uriOptions = new URIOptions();
            uriOptions.EntityType = "users";
            uriOptions.IncludeStatement = "[id,FirstName,LastName]";
            uriOptions.WhereStatement = "(IsActive eq 'true')";

            TP tp = new TP();
            Uri uri = tp.BuildUri(uriOptions);

            StringAssert.Contains("users?include=[", uri.ToString().ToLower());
            StringAssert.Contains("where=(", uri.ToString().ToLower());
        }
    }
}
