using Microsoft.AspNetCore.Mvc;
using ProjectShopMVC.Models;
using ProjectShopMVC.ViewModels;

namespace ProjectShopMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IProjectRepository projectRepository, IShoppingCart shoppingCart)
        {
            _projectRepository = projectRepository;
            _shoppingCart = shoppingCart;

        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int projectId)
        {
            var selectedProject = _projectRepository.AllProjects.FirstOrDefault(p => p.ProjectId == projectId);

            if (selectedProject != null)
            {
                _shoppingCart.AddToCart(selectedProject);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int projectId)
        {
            var selectedProject = _projectRepository.AllProjects.FirstOrDefault(p => p.ProjectId == projectId);

            if (selectedProject != null)
            {
                _shoppingCart.RemoveFromCart(selectedProject);
            }
            return RedirectToAction("Index");
        }
    }
}
