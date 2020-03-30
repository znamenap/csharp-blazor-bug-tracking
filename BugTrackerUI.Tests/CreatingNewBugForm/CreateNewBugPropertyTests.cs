using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace BugTrackerUI.Tests.CreatingNavigationAndComponents
{
    public class CreateNewBugPropertyTests
    {
        [Fact(DisplayName = "Create the NewBug Component @create-newbug-component")]
        public void CreateNewBugPropertyTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the Pages folder.");

            var newBug = TestHelpers.GetClassType("BugTrackerUI.Pages.NewBug");

            var props = newBug.GetProperties();

            Assert.True(newBug.GetProperty("AddBug").PropertyType.Name.Contains("Bug")
                && newBug.IsPublic
                && newBug.GetProperty("AddBug").Name.Contains("AddBug"),
                "`NewBug.razor` should contain a public property `Bug` of type `Bug`.");
        }
    }
}
