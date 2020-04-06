using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleSkeleton.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Maker { get; set; }


        //Mapping to the img database name
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int[] Ratings { get; set; }

        //This method is overrinding the tostring prebuilt method that returns these properties as a json string. 
        //This is optional.
        public override string ToString() => JsonSerializer.Serialize<Product>(this);


    }
}
