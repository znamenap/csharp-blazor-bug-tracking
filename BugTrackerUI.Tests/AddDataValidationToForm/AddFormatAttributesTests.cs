using BugTrackerUI.Tests;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace D_BugTrackerUI.Tests.AddDataValidationToForm
{
    public class AddFormatAttributesTests
    {
        [Fact(DisplayName = "Inject the Navigation Service into the NewBug Component @inject-navigation-service")]
        public void AddFormatAttributesTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                    + Path.DirectorySeparatorChar + "Bug.cs";

            Assert.True(File.Exists(filePath), "`Bug.razor` should exist in the project root.");

            var bug = TestHelpers.GetClassType("BugTrackerUI.Bug");

            var descriptionAttributes = bug.GetProperty("Description").GetCustomAttributesData();
            var descriptionRequired = descriptionAttributes.FirstOrDefault(x => x.AttributeType == typeof(MinLengthAttribute));
            Assert.True(descriptionRequired != null, "The `Description` property of the `Bug` class should be marked with the `[MinLength]` attribute.");

            var priorityAttributes = bug.GetProperty("Priority").GetCustomAttributesData();
            var priorityRequired = priorityAttributes.FirstOrDefault(x => x.AttributeType == typeof(RangeAttribute));
            Assert.True(priorityRequired != null, "The `Priority` property of the `Bug` class should be marked with the `[Range]` attribute.");
        }
    }
}
