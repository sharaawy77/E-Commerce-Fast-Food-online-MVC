
using Fast_Food_online.Models;
using Fast_Food_online.Services;
using Fast_Food_online.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fast_Food_online.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart cart;
        private readonly IOrderService orderService;

        public OrderController(ShoppingCart cart, IOrderService orderService)
        {
            this.cart = cart;
            this.orderService = orderService;
        }


        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> CheckOut(Order order)
        {
            var items = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = items;

            if (cart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some Products first");
            }

            if (ModelState.IsValid)
            {
                await orderService.StoreOrderAsync(order);
                await cart.ClearShoppingCartAsync();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our Order!";
            return View();
        }
    }
}
