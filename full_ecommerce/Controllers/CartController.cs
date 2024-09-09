using AutoMapper;
using AutoMapper.Internal.Mappers;
using full_ecommerce.Data.Models;
using full_ecommerce.DTO;
using full_ecommerce.Migrations;
using full_ecommerce.Repositories.Implementation;
using full_ecommerce.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Cart = full_ecommerce.Data.Models.Cart;

namespace full_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository cartRepository;
        private readonly IItemRepository itemRepository;
        private readonly IMapper mapper;

        public CartController(ICartRepository cartRepository, IItemRepository itemRepository, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }

     

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await cartRepository.GetAllAsync();
            var response = new List<CartDto>();

            foreach (var blogPost in blogPosts)
            {
                var cartDto = new CartDto
                {
                    Id = blogPost.Id,
                    Quantity = blogPost.Items.Count,
                    TotalPrice = (decimal)blogPost.Items.Sum(x => x.Price * x.Quantity),
                    UserId = blogPost.UserId,
                    Items = blogPost.Items.Select(x => new ItemDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        PublishedDate = x.PublishedDate,
                        UrlHandle = x.UrlHandle,
                        ShortDescription = x.ShortDescription,
                        FeaturedImageUrl = x.FeaturedImageUrl,
                        Price = x.Price * x.Quantity,
                        Quantity = x.Quantity ,
                        Discount = x.Discount,
                        PriceDiscount = x.PriceDiscount * x.Price / 100,

                    }).ToList()
                };

              
                cartDto.Quantity = cartDto.Items.Count;

                response.Add(cartDto);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{userId:Guid}")]
        public async Task<IActionResult> GetCartByUserId([FromRoute] Guid userId)
        {
            var existingCarts = await cartRepository.GetCartsByUserId(userId);

            if (!existingCarts.Any())
            {
                return NotFound();
            }

            var response = existingCarts.Select(cart => new CartDto
            {
                Id = cart.Id,
                Quantity = cart.Items.Count,
                TotalPrice = (decimal)cart.Items.Sum(x => x.Price * x.Quantity),
                UserId = cart.UserId,
                Items = cart.Items.Select(x => new ItemDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    UrlHandle = x.UrlHandle,
                    ShortDescription = x.ShortDescription,
                    FeaturedImageUrl = x.FeaturedImageUrl,
                    Price = x.Price * x.Quantity,
                    Quantity = x.Quantity,
                    Discount = x.Discount,
                    PriceDiscount = x.PriceDiscount * x.Price / 100,
                }).ToList()
            }).ToList();

            return Ok(response);
        }

     


        //[HttpGet]
        //[Route("aaa")]
        //public async Task<IActionResult> GetAllCart2() 
        //{
        //    var blogPosts = await cartRepository.GetAllAsync();
        //    var response = blogPosts.Select(blogPost => new CartDto
        //    {
        //        Id = blogPost.Id,
        //        UserId = blogPost.UserId,
        //        Quantity = blogPost.Items.Count,
        //        Items = blogPost.Items.Select(x => new ItemDto
        //        {
        //            Id = x.Id,
        //            Title = x.Title,
        //            PublishedDate = x.PublishedDate,
        //            UrlHandle = x.UrlHandle,
        //            ShortDescription = x.ShortDescription,
        //            FeaturedImageUrl = x.FeaturedImageUrl,
        //            Price = x.Price,
        //            Quantity = x.Quantity
        //        }).ToList()
        //    }).ToList();

        //    var totalPrice = blogPosts.Sum(bp => bp.Items.Sum(i => i.Price));

        //    return Ok(new
        //    {
        //        TotalPrice = totalPrice,
        //        Cart = response
        //    });
        //}
     




        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] AddCartDto request) 
        {
            var cart = new Cart
            {
              
                UserId = request.UserId,
              
                Items = new List<Item>()
            };
            foreach (var categoryGuid in request.Items)
            {
                var existingCategory = await itemRepository.GetByIdAsync(categoryGuid);

                if (existingCategory is not null)
                {
                    existingCategory.Quantity = 1;
                    cart.Items.Add(existingCategory);
                }
            }

            cart = await cartRepository.CreateAsync(cart);

            var response = new CartDto
            {
                Id = cart.Id,
                Quantity = cart.Items.Count,
                TotalPrice = (decimal)cart.Items.Sum(x => x.Price * x.Quantity),
                UserId = cart.UserId,
                Items = cart.Items.Select(x => new ItemDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    UrlHandle = x.UrlHandle,
                    ShortDescription = x.ShortDescription,
                    FeaturedImageUrl = x.FeaturedImageUrl,
                    Price = x.Price,
                    Quantity = x.Quantity,
                }).ToList()


            };
            return Ok(response);
        }

        [HttpPost]
        [Route("Quantity2")]
        public async Task<IActionResult> AddCart3([FromBody] AddCartDto request)
        {
            // Fetch the existing cart for the user or create a new one
            var cart = await cartRepository.GetByUserIdAsync(request.UserId) ?? new Cart
            {
                UserId = request.UserId,
                Items = new List<Item>()
            };

            foreach (var itemGuid in request.Items)
            {
                var existingItem = await itemRepository.GetByIdAsync(itemGuid);

                if (existingItem is not null)
                {
                    var cartItem = cart.Items.FirstOrDefault(x => x.Id == existingItem.Id);

                    if (cartItem != null)
                    {
                        cartItem.Quantity++;
                    }
                    else
                    {
                        // Create a new cart item with necessary properties
                        var newCartItem = new Item
                        {
                            Id = existingItem.Id,
                            Title = existingItem.Title,
                            Price = existingItem.Price,
                            PublishedDate = existingItem.PublishedDate,
                            UrlHandle = existingItem.UrlHandle,
                            ShortDescription = existingItem.ShortDescription,
                            FeaturedImageUrl = existingItem.FeaturedImageUrl,
                            Quantity = 1 // Initialize quantity
                        };
                        cart.Items.Add(newCartItem);
                    }
                }
            }

            // Save the updated cart
            await cartRepository.UpdateAsync(cart);

            decimal totalPrice = (decimal)cart.Items.Sum(x => x.Price * x.Quantity);

            var response = new CartDto
            {
                Id = cart.Id,
                Quantity = cart.Items.Count,
                TotalPrice = totalPrice,
                UserId = cart.UserId,
                Items = cart.Items.Select(x => new ItemDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    UrlHandle = x.UrlHandle,
                    ShortDescription = x.ShortDescription,
                    FeaturedImageUrl = x.FeaturedImageUrl,
                    Price = x.Price,
                    Quantity = x.Quantity // Include quantity
                }).ToList()
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("Quantity")]
        public async Task<IActionResult> AddCart2([FromBody] AddCartDto request)
        {
            // Fetch the existing cart for the user or create a new one
            var cart = await cartRepository.GetByUserIdAsync(request.UserId) ?? new Cart
            {
                UserId = request.UserId,
                Items = new List<Item>()
            };

            foreach (var itemGuid in request.Items)
            {
                var existingItem = await itemRepository.GetByIdAsync(itemGuid);

                if (existingItem is not null)
                {
                    var cartItem = cart.Items.FirstOrDefault(x => x.Id == existingItem.Id);

                    if (cartItem != null)
                    {
                        cartItem.Quantity++;

                    }
                    else
                    {
                        existingItem.Quantity = 1; // Initialize quantity
                        cart.Items.Add(existingItem);
                    }

                }
            }

            // Save the updated cart
            await cartRepository.UpdateAsync(cart);

            decimal totalPrice = (decimal)cart.Items.Sum(x => x.Price * x.Quantity);

            var response = new CartDto
            {
                Id = cart.Id,
                Quantity = cart.Items.Count,
                TotalPrice = (decimal)cart.Items.Sum(x => x.Price * x.Quantity),
                UserId = cart.UserId,
                Items = cart.Items.Select(x => new ItemDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    UrlHandle = x.UrlHandle,
                    ShortDescription = x.ShortDescription,
                    FeaturedImageUrl = x.FeaturedImageUrl,
                    Price = x.Price,
                    Quantity = x.Quantity // Include quantity
                }).ToList()
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCart([FromRoute] Guid id)
        {
            var deleteCart = await cartRepository.DeleteAsync(id);

            if (deleteCart == null) { return NotFound(); }

            //convert Domain model to DTO
            var response = new CartDto
            {
               Id = deleteCart.Id,
               UserId= deleteCart.UserId,
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("Quantity/{itemId:Guid}")]
        public async Task<IActionResult> DeleteCartItem([FromRoute] Guid itemId, [FromBody] Guid userId)
        {
            // جلب السلة الخاصة بالمستخدم
            var cart = await cartRepository.GetByUserIdAsync(userId);

            if (cart == null)
            {
                return NotFound("Cart not found");
            }

            // العثور على العنصر في السلة
            var cartItem = cart.Items.FirstOrDefault(x => x.Id == itemId);

            if (cartItem == null)
            {
                return NotFound("Item not found in cart");
            }

            // تقليل الكمية أو إزالة العنصر
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            else
            {
                cart.Items.Remove(cartItem);
            }

            // حفظ التغييرات
            await cartRepository.UpdateAsync(cart);

            var response = new CartDto
            {
                Id = cart.Id,
                Quantity = cart.Items.Count,
                TotalPrice = (decimal)cart.Items.Sum(x => x.Price * x.Quantity),
                UserId = cart.UserId,
                Items = cart.Items.Select(x => new ItemDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    UrlHandle = x.UrlHandle,
                    ShortDescription = x.ShortDescription,
                    FeaturedImageUrl = x.FeaturedImageUrl,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList()
            };

            return Ok(response);
        }


    }
}

