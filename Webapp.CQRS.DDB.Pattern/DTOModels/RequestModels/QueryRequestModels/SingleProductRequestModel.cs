using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CQRS.DDB.Patter.DTOModels.ResponseModels.QueryResponseModels;

namespace WebApp.CQRS.DDB.Patter.DTOModels.RequestModels.QueryRequestModels
{
    public class SingleProductRequestModel : IRequest<SingleProductResponseModel>
    {
        public int Id { get; set; }
    }
}
