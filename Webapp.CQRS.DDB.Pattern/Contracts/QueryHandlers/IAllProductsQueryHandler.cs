using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CQRS.DDB.Patter.DTOModels.ResponseModels.QueryResponseModels;

namespace WebApp.CQRS.DDB.Patter.Contracts.QueryHandlers
{
    public interface IAllProductsQueryHandler
    {
        Task<List<AllProductsResponseModel>> GetListAsync();
    }
}
