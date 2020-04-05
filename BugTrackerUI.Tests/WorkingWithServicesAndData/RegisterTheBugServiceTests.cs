using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace BugTrackerUI.Tests.CreatingNavigationAndComponents
{
    public class RegisterTheBugServiceTests
    {
        [Fact(DisplayName = "Add the Edit Form Input Components @add-editform-inputs")]
        public void RegisterTheBugServiceTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                    + Path.DirectorySeparatorChar + "startup.cs";

            Assert.True(File.Exists(filePath), "`startup.cs` was not found.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("services.AddSingleton<IBugService, BugService>()"),
                "`Startup.cs`'s `Configure` did not contain a call to `services.AddSingleton` with the type parametrs `<IBugService, BugService>`.");
        }
    }
}