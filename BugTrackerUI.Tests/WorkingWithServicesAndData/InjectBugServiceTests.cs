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
    public class InjectBugServiceTests
    {
        [Fact(DisplayName = "Create the NewBug Component @create-newbug-component")]
        public void InjectBugServiceTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the Pages folder.");

            var newBug = TestHelpers.GetClassType("BugTrackerUI.Pages.NewBug");

            var props = newBug.GetProperties();

            Assert.True(newBug.GetProperty("BugService").PropertyType.Name.Contains("IBugService")
                && newBug.IsPublic
                && newBug.GetProperty("BugService").Name.Contains("BugService"),
                "`NewBug.razor` should contain a public property `BugService` of type `IBugService`.");
        }
    }
}
