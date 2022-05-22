using DotnetCheckout.Enums;

namespace DotnetCheckout.Records;

public record Basket(List<string> Items)
{
    public decimal Total()
    {
        return Items
            .OrderBy(i => i)
            .GroupBy(i => i)
            .Select(group =>
            {
                var offer = ItemDictionary.SpecialOffers.Find(specialOffer => specialOffer.Sku == group.Key);
                if (offer == null)
                {
                    return group.Count() * ItemDictionary.BasketItemsDictionary[group.Key];
                }
                
                var multiples =  group.Count() / offer.Count;
                var leftover =   group.Count() % offer.Count;
                    
                return multiples * offer.OfferPrice + 
                       leftover * ItemDictionary.BasketItemsDictionary[group.Key];

            })
            .Aggregate(0, (acc, x) => acc + x);
    }
}