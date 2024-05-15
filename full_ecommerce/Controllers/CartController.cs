﻿using full_ecommerce.Data.Models;
using full_ecommerce.DTO;
using full_ecommerce.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace full_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository cartRepository;
        private readonly IItemRepository itemRepository;

        public CartController(ICartRepository cartRepository, IItemRepository itemRepository)
        {
            this.cartRepository = cartRepository;
            this.itemRepository = itemRepository;
        }

        // عرض صفحة السلة التسوق

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await cartRepository.GetAllAsync();

            var response = new List<CartDto>();
            foreach (var blogPost in blogPosts)
            {
                response.Add(new CartDto
                {
                    Id = blogPost.Id,
                 // Qty = blogPost.Qty,
                    UserId = blogPost.UserId,
                   // ItemId = blogPost.ItemId,
                    Items = blogPost.Items.Select(x => new ItemDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        PublishedDate = x.PublishedDate,
                        UrlHandle = x.UrlHandle,
                        ShortDescription = x.ShortDescription,
                        FeaturedImageUrl = x.FeaturedImageUrl,
                        Price = x.Price,
                    }).ToList()

                });
            } 
            return Ok(response); 
        }

        // إضافة عنصر إلى السلة

        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] AddCartDto request) 
        {
            var cart = new Cart
            {
              //Qty = request.Qty,
                UserId = request.UserId,
               // ItemId = request.ItemId,
                Items = new List<Item>()
            };
            foreach (var categoryGuid in request.Items)
            {
                var existingCategory = await itemRepository.GetByIdAsync(categoryGuid);

                if (existingCategory is not null)
                {
                    cart.Items.Add(existingCategory);
                }
            }

            cart = await cartRepository.CreateAsync(cart);

            var response = new CartDto
            {
                Id = cart.Id,
              //Qty = cart.Qty,
                UserId = cart.UserId,
                //  ItemId = cart.ItemId,
                Items = cart.Items.Select(x => new ItemDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    UrlHandle = x.UrlHandle,
                    ShortDescription = x.ShortDescription,
                    FeaturedImageUrl = x.FeaturedImageUrl,
                    Price = x.Price,
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
              // ItemId= deleteCart.ItemId,
               UserId= deleteCart.UserId,
             //Qty= deleteCart.Qty,
            };
            return Ok(response);
        }

        //public async Task<IActionResult> AddToCart(Guid itemId, int quantity)
        //{
        //    var cartItem = _context.Carts.FirstOrDefault(c => c.ItemId == itemId);
        //    if (cartItem != null)
        //    {
        //        cartItem.Qty += quantity;
        //    }
        //    else
        //    {
        //        var newItem = new Cart
        //        {
        //            Id = Guid.NewGuid(),
        //            ItemId = itemId,
        //            Qty = quantity
        //        };
        //        _context.Carts.Add(newItem);
        //    }
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        // حذف عنصر من السلة
        //public IActionResult RemoveFromCart(Guid cartId)
        //{
        //    var cartItem = _context.Carts.FirstOrDefault(c => c.Id == cartId);
        //    if (cartItem != null)
        //    {
        //        _context.Carts.Remove(cartItem);
        //        _context.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}     
    }
}

