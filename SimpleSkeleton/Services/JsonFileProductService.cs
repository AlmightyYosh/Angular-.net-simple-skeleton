using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using SimpleSkeleton.Models;

namespace SimpleSkeleton.WebSite.Services
{
    public class JsonFileProductService
    {
        //this is a contructor that starts the web host service being used in this service.
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        //then calls it onto the object
        public IWebHostEnvironment WebHostEnvironment { get; }

        //this method gets the json file.
        private string JsonFileName
        {
            //Routes the json file without hard coding the file url
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        //this method returns a IEnumerable that can be used to quary
        //this method searches through the json file and adds the data to the product as a list.
        //IEnumerables can be thought as things that can be foreached over.
        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    //Optional this will say that you dont care about the case sense.
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        //Controls the rating 
        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            if (products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = products.First(x => x.Id == productId).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.Id == productId).Ratings = ratings.ToArray();
            }

            //writes back into the jsonfile ratings
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }
    }

}