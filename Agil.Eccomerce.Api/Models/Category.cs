using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Agil.Eccomerce.Api.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public IEnumerable<Product> Products { get; set; }
    }
}
