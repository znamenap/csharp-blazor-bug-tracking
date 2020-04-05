using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;
using BugTrackerUI.Tests;

namespace C_BugTrackerUI.Tests.WorkingWithServicesAndData
{
    public class InjectNavigationServiceTests
    {
        [Fact(DisplayName = "Inject the Navigation Service into the NewBug Component @inject-navigation-service")]
        public void InjectNavigationServiceTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the Pages folder.");

            var newBug = TestHelpers.GetClassType("BugTrackerUI.Pages.NewBug");

            var props = newBug.GetProperties();

            Assert.True(newBug.GetProperty("NavService").PropertyType.Name.Contains("NavigationManager")
                && newBug.IsPublic
                && newBug.GetProperty("NavService").Name.Contains("NavService"),
                "`NewBug.razor` should contain a public property `NavService` of type `NavigationManager`.");
        }
    }
}
