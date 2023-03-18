using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CQRS.DDB.Patter.DTOModels.RequestModels.CommandRequestModels;

namespace WebApp.CQRS.DDB.Patter.Contracts.CommandHandlers
{
    public interface ISaveProductCommandHandler
    { 
        Task<int> SaveAsync(SaveProductRequestModel requestModel);
    }
}
