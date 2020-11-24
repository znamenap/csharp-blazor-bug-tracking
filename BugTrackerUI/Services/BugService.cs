using BugTrackerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerUI.Services
{
    public class BugService : IBugService
    {
        private List<Bug> Bugs = Enumerable.Range(0, 9)
            .Select(i => new Bug {
                Title = $"Title {i}",
                Description = $"Description of Title {i}",
                Priority = 3,
                Id = i
            }).ToList();

        public void AddBug(Bug newBug)
        {
            newBug.Id = Bugs.Count + 1;
            Bugs.Add(newBug);
        }

        public List<Bug> GetBugs()
        {
            return Bugs;
        }
    }
}
