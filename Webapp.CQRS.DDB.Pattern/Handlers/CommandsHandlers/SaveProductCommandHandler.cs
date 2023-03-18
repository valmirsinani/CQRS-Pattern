using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.CQRS.Data;
using WebApp.CQRS.DDB.Patter.DTOModels.RequestModels.CommandRequestModels;

namespace WebApp.CQRS.DDB.Patter.Handlers.CommandsHandlers
{
    public class SaveProductCommandHandler : IRequestHandler<SaveProductRequestModel, int>
    {
        public readonly MyAppDbContext _myWorldDbContext; 
        public SaveProductCommandHandler(MyAppDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext; 
        }
        //public SaveProductCommandHandler(MyAppDbContext myWorldDbContext)
        //{
        //    _myWorldDbContext = myWorldDbContext; 
        //}
        public async Task<int> Handle(SaveProductRequestModel request, CancellationToken cancellationToken)
        {
            var newProducts = new Product
            {
                Description = request.Description,
                Manufacture = request.Manufacturer,
                Name = request.Name,
                Price = request.Price
            };

            _myWorldDbContext.Products.Add(newProducts);
            await _myWorldDbContext.SaveChangesAsync();

              newProducts = new Product
            {
                Description = request.Description,
                Manufacture = request.Manufacturer,
                Name = request.Name,
                Price = request.Price
            };

             

            return newProducts.Id;
        }

        // public class SaveProductCommandHandler: ISaveProductCommandHandler
        // {
        //     public readonly MyWorldDbContext _myWorldDbContext;
        //     public SaveProductCommandHandler(MyWorldDbContext myWorldDbContext)
        //     {
        //         _myWorldDbContext = myWorldDbContext;
        //     }

        //     public async Task<int> SaveAsync(SaveProductRequestModel requestModel)
        //     {
        //         var newProducts = new Products
        //         {
        //             Description = requestModel.Description,
        //             Manufacturer = requestModel.Manufacturer,
        //             Name = requestModel.Name,
        //             Price = requestModel.Price
        //         };

        //         _myWorldDbContext.Products.Add(newProducts);
        //         await _myWorldDbContext.SaveChangesAsync();
        //         return newProducts.ProductId;
        //     }
        // }
    }
}
