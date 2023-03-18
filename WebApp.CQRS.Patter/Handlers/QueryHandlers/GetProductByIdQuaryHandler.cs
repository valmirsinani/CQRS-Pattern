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
    public class GetProductByIdQuaryHandler : IRequestHandler<SingleProductRequestModel, SingleProductResponseModel>
    {
        private readonly MyAppDbContext _myWorldDbContext;

        public GetProductByIdQuaryHandler(MyAppDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        public async Task<SingleProductResponseModel> Handle(SingleProductRequestModel request, CancellationToken cancellationToken)
        {
            return await _myWorldDbContext.Products
            .Where(_=>_.Id==request.Id)
            .Select(_ => new SingleProductResponseModel
            {
                Name = _.Name,
                Id = _.Id,
                Price = _.Price
            }).SingleOrDefaultAsync();
        }
    }
}
