
using Fast_Food_online.Models;
using Fast_Food_online.Services;
using Fast_Food_online.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Movie.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart cart;
        private readonly IProductService<Product> productService;

        public ShoppingCartController(ShoppingCart cart,IProductService<Product> productService)
        {
            this.cart = cart;
            this.productService = productService;
        }
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            var items = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartVM
            {
                ShoppingCart = cart,
                ShoppingCartTotal = cart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);

        }
        public async Task<RedirectToActionResult> AddToShoppingCart(int id)
        {
            var selectedItem = await productService.GetValueAsync(id);

            if (selectedItem != null)
            {
                cart.AddItemToCart(selectedItem);
            }
            return RedirectToAction("Index");
        }
        public async Task< RedirectToActionResult> RemoveFromShoppingCart(int id)
        {
            var selectedItem = await productService.GetValueAsync(id);

            if (selectedItem != null)
            {
                cart.RemoveItemFromCart(selectedItem);
            }
            return RedirectToAction("Index");
        }

    }
}
