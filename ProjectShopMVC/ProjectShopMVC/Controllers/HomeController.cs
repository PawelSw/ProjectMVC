using Microsoft.AspNetCore.Mvc;
using ProjectShopMVC.Models;
using ProjectShopMVC.ViewModels;

namespace ProjectShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public HomeController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            var projectsOfTheWeek = _projectRepository.ProjectsOfTheWeek;
            var homeViewModel = new HomeViewModel(projectsOfTheWeek);
            return View(homeViewModel);
        }
    }
}
