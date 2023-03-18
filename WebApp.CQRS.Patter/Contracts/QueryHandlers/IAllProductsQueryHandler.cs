using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CQRS.Patter.DTOModels.ResponseModels.QueryResponseModels;

namespace WebApp.CQRS.Patter.Contracts.QueryHandlers
{
    public interface IAllProductsQueryHandler
    {
        Task<List<AllProductsResponseModel>> GetListAsync();
    }
}
