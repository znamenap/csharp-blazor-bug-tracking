using BugTrackerUI.Pages;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BugTrackerUI.Tests;

namespace C_BugTrackerUI.Tests.WorkingWithServicesAndData
{
    public class CreateFormSubmissionHandlerTests
    {
        [Fact(DisplayName = "Create the NewBug Component @create-newbug-component")]
        public void CreateFormSubmissionHandlerTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the Pages folder.");

            var newBug = TestHelpers.GetClassType("BugTrackerUI.Pages.NewBug");
            
            var method = newBug.GetMethod(
                "HandleValidSubmit",
                BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.True( method != null && method.IsFamily && method.ReturnType == typeof(Task),
                "`NewBug.razor` should contain a `protected` method called `HandleValidSubmit` that returns a type of `Task`.");
        }
    }
}
