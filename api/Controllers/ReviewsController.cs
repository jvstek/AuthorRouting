using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using Business.Services.Reviews;
using Business.Models.Reviews;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/Books/{bookid:guid}/reviews")]
    public class ReviewsController : Controller
    {
        public readonly IReviewService ReviewService;
        public ReviewsController(IReviewService reviewService)
        {
            this.ReviewService = reviewService;
        }

        [HttpGet("")]
        public IActionResult GetAll(Guid bookId)
        {
            var author = ReviewService.GetAllReviews(bookId);
            return Ok(author);
        }

        [HttpPost("")]
        public IActionResult Create(Guid bookId,[FromBody]CreateReviewModel model)
        { 
            var newlyCreated = ReviewService.CreateReview(bookId,model);
            return CreatedAtRoute("GetReview", new { bookid = bookId ,reviewid = newlyCreated }, newlyCreated);
        }


        [HttpGet("{reviewid:guid}", Name = "GetReview")]
        public IActionResult Get(Guid bookId,Guid reviewId)
        {
            var reviews = ReviewService.GetReview(bookId,reviewId);
            if (reviews == null)
            {
                return NotFound();
            }

            return Ok(reviews);
        }
        [HttpPost("{reviewid:guid}", Name = "DeleteReview")]
        public IActionResult Delete(Guid bookId, Guid reviewId)
        {
            ReviewService.RemoveReview(bookId, reviewId);
            return NoContent();
        }
        [HttpPut("{reviewid:guid}", Name = "UpdateReview")]
        public IActionResult Update(Guid bookId, Guid reviewId, [FromBody]UpdateReviewModel model)
        {
            ReviewService.UpdateReview(bookId, reviewId, model);
            return Ok();
        }
    }
}