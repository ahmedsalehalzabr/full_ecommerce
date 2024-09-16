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
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }


        [HttpPost]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRating([FromBody] CreateRatingDto request)
        {
            var rating = new Rating
            {
                Ratings = request.Ratings,
                CommuntRating = request.CommuntRating,

            };

            rating = await ratingRepository.CreateAsync(rating);

            var response = new RatingDto
            {
                Id = rating.Id,
                Ratings = rating.Ratings,
                CommuntRating = rating.CommuntRating,

            };

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllRating()
        {
            var ratings = await ratingRepository.GetAllAsync();

            var response = new List<RatingDto>();
            foreach (var rating in ratings)
            {
                response.Add(new RatingDto
                {
                    Id = rating.Id,
                    Ratings = rating.Ratings,
                    CommuntRating = rating.CommuntRating,

                });
            }

            return Ok(response);

        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetBlogPostById([FromRoute] Guid id)
        {
            var ratings = await ratingRepository.GetByIdAsync(id);

            if (ratings == null)
            {
                return NotFound();
            }

            //convert domain model to DTO
            var response = new RatingDto
            {
                Id = ratings.Id,
                Ratings = ratings.Ratings,
                CommuntRating = ratings.CommuntRating,

            };
            return Ok(response);
        }




        [HttpPut]
        [Route("{id:Guid}")]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateBlogPostById([FromRoute] Guid id, CreateRatingDto request)
        {
            //Convert DTO to Domain Model

            var rating = new Rating
            {

                Ratings = request.Ratings,
                CommuntRating = request.CommuntRating,


            };



            // call repository to update BlogPost domain model
            var updateRating = await ratingRepository.UpdateAsync(rating);

            if (updateRating == null)
            {
                return NotFound();
            }

            //convert domain model back to DTO
            var response = new RatingDto
            {
                Id = rating.Id,
                Ratings = rating.Ratings,
                CommuntRating = rating.CommuntRating,


            };
            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
     //   [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] Guid id)
        {
            var deleteRating = await ratingRepository.DeleteAsync(id);

            if (deleteRating == null) { return NotFound(); }

            //convert Domain model to DTO
            var response = new RatingDto
            {
                Id = deleteRating.Id,
                Ratings = deleteRating.Ratings,
                CommuntRating = deleteRating.CommuntRating,
            };
            return Ok(response);

        }
    }
}
