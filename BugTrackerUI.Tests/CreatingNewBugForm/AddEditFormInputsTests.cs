using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using BugTrackerUI.Tests;

namespace B_BugTrackerUI.Tests.CreatingNewBugForm
{
    public class AddEditFormInputsTests
    {
        [Fact(DisplayName = "Add the Edit Form Input Components @add-editform-inputs")]
        public void AddEditFormInputsTest()
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
                var parsedInput = editForm.Descendants("InputText")
                    .FirstOrDefault(x => x.Attributes["placeholder"]?.Value == $"Enter {label}" && x.Attributes["@bind-Value"]?.Value == $"@AddBug.{label}");

                if(parsedInput == null)
                {
                    parsedInput = editForm.Descendants("InputNumber")
                        .FirstOrDefault(x => x.Attributes["placeholder"]?.Value == $"Enter {label}" && x.Attributes["@bind-Value"]?.Value == $"@AddBug.{label}");

                }
                Assert.True(parsedInput != null, 
                    $"NewBug.razor should contain an input with attributes `placeholder=\"NewTask.{label}\"` and `@bind-balue=\"@AddBug.{label}\"`");
            }
        }
    }
}