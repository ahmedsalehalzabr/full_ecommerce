using AutoMapper;
using full_ecommerce.Data.Models;
using full_ecommerce.DTO;
using full_ecommerce.Repositories.Implementation;
using full_ecommerce.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace full_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;
        private readonly IItemRepository itemRepository;
        private readonly IMapper mapper;

        public BasketController(IBasketRepository basketRepository, IItemRepository itemRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("add-item-to-cart")]
        public async Task<IActionResult> AddItemToCart([FromBody] AddBasketDto request)
        {
            var cart = await basketRepository.GetByUserIdAsync(request.UserId);

            if (cart == null)
            {
                // إذا لم تكن هناك سلة، يتم إنشاء سلة جديدة
                cart = new Basket
                {
                    UserId = request.UserId,
                    Items = new List<BasketItem>()
                };
            }

            // فحص إذا كان العنصر موجود بالفعل في السلة
            var existingItem = cart.Items.FirstOrDefault(item => item.Id == request.ItemId);

            if (existingItem != null)
            {
                // إذا كان العنصر موجودًا بالفعل، يتم زيادة الكمية
                existingItem.Quantity += request.Quantity;
            }
            else
            {
                // إذا لم يكن موجودًا، يتم إضافة العنصر إلى السلة
                cart.Items.Add(new BasketItem
                {
                    Id = request.ItemId,
                 
                    Quantity = request.Quantity
                });
            }

            // حفظ التغييرات في قاعدة البيانات
            await basketRepository.UpdateAsync(cart);

            return Ok(new
            {
                Success = true,
                Basket = cart
            });
        }

  

    }
}
