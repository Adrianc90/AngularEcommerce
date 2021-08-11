using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketByID(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = new CustomerBasket
            {
                Id = basket.Id,
                Items = new List<BasketItem>()
            };
            basket.Items.ForEach(x =>
            {
                customerBasket.Items.Add(new BasketItem
                {
                    Id=x.Id,
                    ProductName=x.ProductName,
                    Price=x.Price,
                    Quantity=x.Quantity,
                    PictureUrl=x.PictureUrl,
                    Brand=x.Brand,
                    Type=x.Type
                });
            });
            var updatedBasket = await _basketRepository.UpdateBasketAsync(customerBasket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}