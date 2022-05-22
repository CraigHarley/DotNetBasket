using DotnetCheckout.Contracts;
using DotnetCheckout.Records;

namespace DotnetCheckout.Services;

public class BasketManager : IBasketManager
{
    private readonly Dictionary<string, Basket> _baskets;

    public BasketManager()
    {
        _baskets = new Dictionary<string, Basket>();
    }

    public Basket GetOrCreateBasketById(string id)
    {
        try
        {
            var existingBasket = _baskets[id];
            return existingBasket;
        } catch (KeyNotFoundException)
        {
            _baskets[id] =  new Basket(new List<string>());
            return _baskets[id];
        }
    }

    public Basket AddToBasket(string id, string sku)
    {
        var originalBasket = GetOrCreateBasketById(id);
        var newBasket = new Basket(originalBasket.Items.Append(sku).ToList());

        _baskets[id] = newBasket;
        return newBasket;
    }
}