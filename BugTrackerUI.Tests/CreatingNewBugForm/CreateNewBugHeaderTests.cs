using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace BugTrackerUI.Tests.CreatingNavigationAndComponents
{
    public class CreateNewBugHeaderTests
    {
        [Fact(DisplayName = "Create the NewBug Component @create-newbug-component")]
        public void CreateNewBugHeaderTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var leftNav = doc.DocumentNode.Descendants("h2")?.FirstOrDefault();

            Assert.True(leftNav != null && leftNav.InnerText.Contains("Add New Bug", StringComparison.OrdinalIgnoreCase), 
                "`LeftNav.razor` should contain navigation `ul` element with two child `li` elements.");
        }
    }
}
