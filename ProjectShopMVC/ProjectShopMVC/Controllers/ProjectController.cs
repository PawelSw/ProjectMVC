using Microsoft.AspNetCore.Mvc;
using ProjectShopMVC.Models;
using ProjectShopMVC.ViewModels;

namespace ProjectShopMVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            
        }
        public IActionResult List()
        {
            var projectViewModel = new ProjectListViewModel(_projectRepository.AllProjects);
            return View(projectViewModel);
        }
        public IActionResult Details(int id)
        {
            var project = _projectRepository.GetProjectById(id);
            if (project == null)
                return NotFound();

            return View(project);
        }
    }
}
