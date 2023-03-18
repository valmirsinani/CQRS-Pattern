using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.CQRS.DDB.Patter.DTOModels.ResponseModels.QueryResponseModels
{
    public class PriceRangeProductsResponseModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
