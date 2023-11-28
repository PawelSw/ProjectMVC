using ProjectShopMVC.Models;
using System.IO.Pipelines;

namespace ProjectShopMVC.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Project> Projects { get; }

        public ProjectListViewModel(IEnumerable<Project> projects)
        {
            Projects = projects;
           
        }
    }
}
