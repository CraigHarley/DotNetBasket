using DotnetCheckout.Contracts;
using DotnetCheckout.Records;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCheckout.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly IBasketManager _basketManager;
    
    public CheckoutController(IBasketManager basketManager)
    {
        _basketManager = basketManager;
    }

    [HttpGet(Name = "GetBasket")]
    public Basket Get(string basketId)
    {
        return _basketManager.GetOrCreateBasketById(basketId);
    }

    [HttpPut(Name = "PutBasketItem")]
    public Basket Put(string basketId, string itemSku)
    {
        return _basketManager.AddToBasket(basketId, itemSku);
    }
}