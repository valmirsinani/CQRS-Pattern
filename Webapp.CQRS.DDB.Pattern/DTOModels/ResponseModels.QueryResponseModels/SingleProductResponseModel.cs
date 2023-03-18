using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.CQRS.DDB.Patter.DTOModels.ResponseModels.QueryResponseModels
{
    public class SingleProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
