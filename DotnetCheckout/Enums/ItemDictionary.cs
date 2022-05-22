using DotnetCheckout.Records;

namespace DotnetCheckout.Enums;

public static class ItemDictionary
{
    public static readonly Dictionary<string, int> BasketItemsDictionary = new()
    {
        { "A99", 50 },
        { "B15", 30 },
        { "C40", 60 }
    };
    
    public static readonly List<SpecialOffer> SpecialOffers = new()
    {
        new SpecialOffer("A99", 3, 130),
        new SpecialOffer("B15", 2, 45)
    };
}