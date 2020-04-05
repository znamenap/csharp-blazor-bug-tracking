using BugTrackerUI.Tests;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace B_BugTrackerUI.Tests.CreatingNewBugForm
{
    public class AddEditFormButtonTests
    {
        [Fact(DisplayName = "Add the Edit Form Input Components @add-editform-inputs")]
        public void AddEditFormButtonTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the `Pages` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var editForm = doc.DocumentNode.Descendants("EditForm")?.FirstOrDefault();

            var labels = new[] { "Title", "Description", "Priority" };

            foreach (var label in labels)
            {
                var parsedInput = editForm.Descendants("button")
                    .FirstOrDefault(x => x.Attributes["type"]?.Value == $"submit");

                Assert.True(parsedInput != null, 
                    $"NewBug.razor should contain a button with attributes `type=\"submit\"`.");
            }
        }
    }
}