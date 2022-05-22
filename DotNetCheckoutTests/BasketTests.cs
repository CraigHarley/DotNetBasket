using System.Collections.Generic;
using DotnetCheckout.Controllers;
using DotnetCheckout.Records;
using DotnetCheckout.Services;
using Xunit;

namespace DotNetCheckoutTests;

public class BasketTests
{
    private static void AddToBasket(CheckoutController controller, string basketId, IEnumerable<string> skus)
    {
        foreach (var sku in skus)
        {
            controller.Put(basketId, sku);
        }
    }
    
    [Fact]
    public void CreatingANewBasket()
    {
        const string basketId = "FEE12BDE-29EB-4D3E-B78B-EE0134C77409";
        var mockController = new CheckoutController(new BasketManager());
        
        var result = mockController.Get(basketId);
        
        Assert.IsType<Basket>(result);
        Assert.Empty(result.Items);
    }

    [Fact]
    public void AddingItemsToABasket()
    {
        const string basketId = "FEE12BDE-29EB-4D3E-B78B-EE0134C77409";
        var mockController = new CheckoutController(new BasketManager());
        
        var result = mockController.Put(basketId, "A99");
        
        Assert.IsType<Basket>(result);
        Assert.NotEmpty(result.Items);
    }

    [Theory]
    [InlineData(130, "A99", "A99", "A99")]
    [InlineData(180, "A99", "A99", "A99", "A99")]
    [InlineData(45, "B15", "B15")]
    [InlineData(60 * 4, "C40", "C40", "C40", "C40")]
    [InlineData(45 + 50, "B15", "A99", "B15")]
    public void GettingTheTotalValueOfABasket(int total, params string[] skus)
    {
        const string basketId = "FEE12BDE-29EB-4D3E-B78B-EE0134C77409";
        var mockController = new CheckoutController(new BasketManager());
        
        AddToBasket(
            mockController,
            basketId,
            skus
        );
        
        var result = mockController.Get(basketId);

        Assert.IsType<Basket>(result);
        Assert.NotEmpty(result.Items);
        Assert.Equal(total, result.Total());
    }
}