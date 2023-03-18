using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.CQRS.Data;
using WebApp.CQRS.Patter.DTOModels.RequestModels.QueryRequestModels;
using WebApp.CQRS.Patter.DTOModels.ResponseModels.QueryResponseModels;

namespace WebApp.CQRS.Patter.Handlers.QueryHandlers
{
    public class AllProductsQueryHandler : IRequestHandler<AllProductsRequestModel, List<AllProductsResponseModel>>
    {
        private readonly MyAppDbContext _myWorldDbContext;
        public AllProductsQueryHandler(MyAppDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }
        public async Task<List<AllProductsResponseModel>> Handle(AllProductsRequestModel request, CancellationToken cancellationToken)
        {
            return await _myWorldDbContext.Products
            .Select(_ => new AllProductsResponseModel
            {
                Description = _.Description,
                ProductId = _.Id,
                Manufacturer = _.Manufacture,
                Name = _.Name,
                Price = _.Price
            }).ToListAsync();
        }
    }

    // public class AllProductsQueryHandler:IAllProductsQueryHandler
    // {
    //     private readonly MyWorldDbContext _myWorldDbContext;
    //     public AllProductsQueryHandler(MyWorldDbContext myWorldDbContext)
    //     {
    //         _myWorldDbContext = myWorldDbContext;
    //     }

    //     public async Task<List<AllProductsResponseModel>> GetListAsync()
    //     {
    //         return await _myWorldDbContext.Products
    //         .Select(_ => new AllProductsResponseModel{
    //             Description = _.Description,
    //             ProductId = _.Id,
    //             Manufacturer = _.Manufacturer,
    //             Name = _.Name,
    //             Price = _.Price
    //         }).ToListAsync();
    //     }
    // }
}
