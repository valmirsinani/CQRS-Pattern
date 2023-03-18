using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Sipmple.Pattern.Models
{
    public class ProductViewModel
    {
    }
    public class GetProductsResponseModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    public class SaveProductRequestModel  
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
