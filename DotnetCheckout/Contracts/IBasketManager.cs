using DotnetCheckout.Records;

namespace DotnetCheckout.Contracts;

public interface IBasketManager
{
    public Basket GetOrCreateBasketById(string id);
    public Basket AddToBasket(string id, string sku);
}