using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CQRS.DDB.Patter.Contracts.CommandHandlers;
using WebApp.CQRS.DDB.Patter.Contracts.QueryHandlers;
using WebApp.CQRS.DDB.Patter.DTOModels.RequestModels.CommandRequestModels;
using WebApp.CQRS.DDB.Patter.DTOModels.RequestModels.QueryRequestModels;

namespace Webapp.CQRS.DDB.Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISaveProductCommandHandler _saveProductCommandHandler;
        private readonly IAllProductsQueryHandler _allProductsQueryHandler;
        private readonly IPriceRangeProductsQueryHandler _priceRangeProductsQueryHandler;

        private readonly IMediator _mediator;
        public ProductController( 
           IMediator mediator)
        { 
            _mediator = mediator;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> SaveProductAsync(SaveProductRequestModel requestModel)
        {
       

            byte[] randomBytes = new byte[4];
            string initManu = requestModel.Manufacturer;
            string initDesc = requestModel.Description;
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                rnd.NextBytes(randomBytes); 

                var newProducts = new SaveProductRequestModel
                {
                    Description = requestModel.Description + randomBytes[0].ToString(),
                    Manufacturer = requestModel.Manufacturer + randomBytes[1].ToString(),
                    Name = requestModel.Name + randomBytes[2].ToString(),
                    Price = requestModel.Price + randomBytes[3]
                };
                System.Threading.Thread.Sleep(15);

                var result = await _mediator.Send(newProducts); 
            }
            return Ok("OK = (1)");
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> AllProducts()
        { 
            var result = await _mediator.Send(new AllProductsRequestModel());
            return Ok(result);
        }
        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetByIdProducts([FromQuery] SingleProductRequestModel requestModel)
        {
            var result = await _mediator.Send(requestModel);
            return Ok(result);
        }
        [HttpGet]
        [Route("price-range")]
        public async Task<IActionResult> PriceRangeProducts([FromQuery] PriceRangeProductsRequestModel requestModel)
        { 
            var result = await _mediator.Send(requestModel);
            return Ok(result);
        }

    }
}
