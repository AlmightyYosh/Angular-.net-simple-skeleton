#pragma checksum "C:\Users\yjwar\source\repos\SimpleSkeleton\SimpleSkeleton\Components\ProductList.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2c48e2a86c1c5bc41b25e9b484891fa332cc41f"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SimpleSkeleton.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\yjwar\source\repos\SimpleSkeleton\SimpleSkeleton\Components\ProductList.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\yjwar\source\repos\SimpleSkeleton\SimpleSkeleton\Components\ProductList.razor"
using SimpleSkeleton.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\yjwar\source\repos\SimpleSkeleton\SimpleSkeleton\Components\ProductList.razor"
using SimpleSkeleton.WebSite.Services;

#line default
#line hidden
#nullable disable
    public partial class ProductList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 83 "C:\Users\yjwar\source\repos\SimpleSkeleton\SimpleSkeleton\Components\ProductList.razor"
       
    Product selectProduct;
    string selectPoductId;

    //selecting the products on click
    void SelectProduct(string productId)
    {
        selectPoductId = productId;
        selectProduct = ProductService.GetProducts().First(x => x.Id == productId);

    }

    int currentRating = 0;
    int voteCount = 0;
    string voteLabel;

    //gets the current rating 
    void GetCurrentRating()
    {
        if(selectProduct.Ratings == null)
        {
            currentRating = 0;
            voteCount = 0;
        }
        else
        {
            voteCount = selectProduct.Ratings.Count();
            voteLabel = voteCount > 1 ? "Votes" : "Vote";
            currentRating = selectProduct.Ratings.Sum() / voteCount;
        }

        System.Console.WriteLine($"Current rating for {selectProduct.Id}: {currentRating}");
    }

    //submits a rating
    void SubmitRating(int rating)
    {
        System.Console.WriteLine($"Rating received for {selectProduct.Id}: {rating}");
        ProductService.AddRating(selectPoductId, rating);
        SelectProduct(selectPoductId);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private JsonFileProductService ProductService { get; set; }
    }
}
#pragma warning restore 1591
