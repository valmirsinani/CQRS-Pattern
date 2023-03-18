using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CQRS.Patter.Contracts.CommandHandlers;
using WebApp.CQRS.Patter.DTOModels.RequestModels.CommandRequestModels;
using WebApp.CQRS.Patter.DTOModels.RequestModels.QueryRequestModels;

namespace WebApp.CQRS.Patter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //  private readonly ISaveProductCommandHandler _saveProductCommandHandler;
        //private readonly IAllProductsQueryHandler _allProductsQueryHandler;
        //private readonly IPriceRangeProductsQueryHandler _priceRangeProductsQueryHandler;

        private readonly IMediator _mediator;
        public ProductController(
           // ISaveProductCommandHandler saveProductCommandHandler,
           //IAllProductsQueryHandler allProductsQueryHandler,
           //IPriceRangeProductsQueryHandler priceRangeProductsQueryHandler,
           IMediator mediator)
        {
            //   _saveProductCommandHandler = saveProductCommandHandler;
            // _allProductsQueryHandler = allProductsQueryHandler;
            //_priceRangeProductsQueryHandler = priceRangeProductsQueryHandler;
            _mediator = mediator;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> SaveProductAsync(SaveProductRequestModel requestModel)
        {
            // var result = await _saveProductCommandHandler.SaveAsync(requestModel);
            /*   
             */

            byte[] randomBytes = new byte[4];
            string initManu = requestModel.Manufacturer;
            string initDesc = requestModel.Description;
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                rnd.NextBytes(randomBytes); 
                //requestModel.Name = requestModel.Name + randomBytes[0].ToString();
                //requestModel.Manufacturer = initManu + randomBytes[1].ToString();
                //requestModel.Description = initDesc + randomBytes[2].ToString();
                //requestModel.Price = requestModel.Price + randomBytes[3];

                var newProducts = new SaveProductRequestModel
                {
                    Description = requestModel.Description + randomBytes[0].ToString() ,
                    Manufacturer = requestModel.Manufacturer + randomBytes[1].ToString() ,
                    Name = requestModel.Name + randomBytes[2].ToString(),
                    Price = requestModel.Price + randomBytes[3]
                };
                  System.Threading.Thread.Sleep(15);

                var result = await _mediator.Send(newProducts);
                //return Ok(result);
            }
            return Ok("OK = (1)");
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> AllProducts()
        {
            //var result = await _allProductsQueryHandler.GetListAsync();
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
            //var result = await _priceRangeProductsQueryHandler.PriceRangeProductsAsync(minPrice, maxPrice);
            var result = await _mediator.Send(requestModel);
            return Ok(result);
        }

    }
}
