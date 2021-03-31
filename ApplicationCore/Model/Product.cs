using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Model
{
    public class Product
    {
       
        public int SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //Relation
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
