using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApplicationCore.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
