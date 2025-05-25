using BuyEasy.Services;
using Microsoft.AspNetCore.Mvc;

public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    public IActionResult Index()
    {
        var items = _cartService.GetCartItems();
        return View(items);
    }

    [HttpPost]
    public IActionResult AddToCart(int productId)
    {
        _cartService.AddToCart(productId, 1);
        return RedirectToAction("Index");
    }

    public IActionResult Checkout()
    {
        var cart = _cartService.GetCartItems();
        return View("Billing", cart);
    }
}
