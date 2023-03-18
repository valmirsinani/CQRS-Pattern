using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.CQRS.Data;
using WebApp.CQRS.DDB.Patter.DTOModels.RequestModels.QueryRequestModels;
using WebApp.CQRS.DDB.Patter.DTOModels.ResponseModels.QueryResponseModels;

namespace WebApp.CQRS.DDB.Patter.Handlers.QueryHandlers
{
    public class PriceRangeProductsQueryHandler : IRequestHandler<PriceRangeProductsRequestModel, List<PriceRangeProductsResponseModel>>
    {
        private readonly MyAppDb_RDBContext _myWorldDbContext;
        public PriceRangeProductsQueryHandler(MyAppDb_RDBContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }
        public async Task<List<PriceRangeProductsResponseModel>> Handle(PriceRangeProductsRequestModel request, CancellationToken cancellationToken)
        {

            return await _myWorldDbContext.Products
            .Where(_ => _.Price >= request.MinPrice && _.Price <= request.MaxPrice)
            .Select(_ => new PriceRangeProductsResponseModel
            {
                Name = _.Name,
                ProductId = _.Id,
                Price = _.Price
            }).ToListAsync();
        }

        // public class PriceRangeProductsQueryHandler : IPriceRangeProductsQueryHandler
        // {
        //     private readonly MyAppDbContext _myWorldDbContext;
        //     public PriceRangeProductsQueryHandler(MyAppDbContext myWorldDbContext)
        //     {
        //         _myWorldDbContext = myWorldDbContext;
        //     }
        //     public async Task<List<PriceRangeProductsResponseModel>> PriceRangeProductsAsync(int minPrice, int maxPrice)
        //     {
        //         return await _myWorldDbContext.Products
        //         .Where(_ => _.Price >= minPrice && _.Price <= maxPrice)
        //         .Select(_ => new PriceRangeProductsResponseModel
        //         {
        //             Name = _.Name,
        //             ProductId = _.ProductId,
        //             Price = _.Price
        //         }).ToListAsync();
        //     }
        // }

    }
}
