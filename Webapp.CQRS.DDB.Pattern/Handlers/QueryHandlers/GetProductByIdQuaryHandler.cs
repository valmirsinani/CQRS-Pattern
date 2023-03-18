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
    public class GetProductByIdQuaryHandler : IRequestHandler<SingleProductRequestModel, SingleProductResponseModel>
    {
        private readonly MyAppDb_RDBContext _myWorldDbContext;

        public GetProductByIdQuaryHandler(MyAppDb_RDBContext myWorldDbContext)
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
