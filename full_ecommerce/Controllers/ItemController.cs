using full_ecommerce.Data.Models;
using full_ecommerce.DTO;
using full_ecommerce.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace full_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository blogPostRepository;
        

        public ItemController(IItemRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
            
        }


        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateItemDto request)
        {
            var blogPost = new Item
            {
                Title = request.Title,
               
                FeaturedImageUrl = request.FeaturedImageUrl,
               
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
                Price = request.Price,
               

            };

     

            blogPost = await blogPostRepository.CreateAsync(blogPost);

            var response = new ItemDto
            {
                Id = blogPost.Id,
                Title = request.Title,
              
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
              
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                UrlHandle = blogPost.UrlHandle,
                Price = blogPost.Price,


            };

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await blogPostRepository.GetAllAsync();

            var response = new List<ItemDto>();
            foreach (var blogPost in blogPosts)
            {
                response.Add(new ItemDto
                {
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                   
                    PublishedDate = blogPost.PublishedDate,
                    ShortDescription = blogPost.ShortDescription,
                    UrlHandle = blogPost.UrlHandle,
                    Price = blogPost.Price,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
               
                });
            }

            return Ok(response);

        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetBlogPostById([FromRoute] Guid id)
        {
            var blogPost = await blogPostRepository.GetByIdAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            //convert domain model to DTO
            var response = new ItemDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
            
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                UrlHandle = blogPost.UrlHandle,
                Price= blogPost.Price,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
              
            };
            return Ok(response);
        }

      


        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateBlogPostById([FromRoute] Guid id, UpdateItemDto request)
        {
            //Convert DTO to Domain Model

            var blogPost = new Item
            {
                Id = id,
                Title = request.Title,
            
                FeaturedImageUrl = request.FeaturedImageUrl,
                Price = request.Price,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
               
            };

     

            // call repository to update BlogPost domain model
            var updateBlogPost = await blogPostRepository.UpdateAsync(blogPost);

            if (updateBlogPost == null)
            {
                return NotFound();
            }

            //convert domain model back to DTO
            var response = new ItemDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
             
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                UrlHandle = blogPost.UrlHandle,
                Price = blogPost.Price,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
              
            };
            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] Guid id)
        {
            var deleteBlogPost = await blogPostRepository.DeleteAsync(id);

            if (deleteBlogPost == null) { return NotFound(); }

            //convert Domain model to DTO
            var response = new ItemDto
            {
                Id = deleteBlogPost.Id,
                Title = deleteBlogPost.Title,
             
                PublishedDate = deleteBlogPost.PublishedDate,
                ShortDescription = deleteBlogPost.ShortDescription,
                UrlHandle = deleteBlogPost.UrlHandle,
                Price = deleteBlogPost.Price,
                FeaturedImageUrl = deleteBlogPost.FeaturedImageUrl,
            };
            return Ok(response);

        }

    }
}
