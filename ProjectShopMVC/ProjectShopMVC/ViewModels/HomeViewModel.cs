using ProjectShopMVC.Models;
using System.IO.Pipelines;

namespace ProjectShopMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Project> ProjectsOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Project> projectsOfTheWeek)
        {
            ProjectsOfTheWeek = projectsOfTheWeek;
        }
    }
}
