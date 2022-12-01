using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using ReviewApp.Core;
using ReviewApp.Core.Exceptions;
using ReviewApp.RestAPI.Model;
using ReviewApp.RestAPI.Mapper;

namespace ReviewApp.RestAPI.Controllers
{
    [ApiController]
    [Route("reviews")]
    public class ReviewController : ControllerBase

    {

        private ReviewApplicationManager _manager;

        public ReviewController(ReviewApplicationManager manager)
        {

            _manager = manager;

        }

        [HttpGet]
        public ActionResult<List<ReviewDto>> GetAllReviews() =>
            Ok(_manager.GetAllReviews().Select(r =>
            ReviewDtoMapper.From(r)).ToList());

        [HttpGet]
        [Route("{review-id}")]
        public ActionResult<ReviewDto> GetReviewById([FromRoute(Name = "review-id")] int reviewId)
        {

            try
            {
                var r = _manager.GetReview(reviewId);
                return Ok(ReviewDtoMapper.From(r));
            }
            catch (ReviewNotFoundException e)
            {
                return NotFound(new ErrorResponse(e.Message));
            }
        }

        [HttpPost]
        public ActionResult<ReviewDto> CreateSamurai([FromBody] ReviewRequest body)
        {
            try
            {
                var r = _manager.CreateReview(body.Comment, body.UserId, body.MovieId);
                var uri = $"/reviews/{r.Id}";
                return Created(uri, ReviewDtoMapper.From(r));
            }
            catch (ShortCommentException ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }
        [HttpPut]
        [Route("{review-id}")]
        public ActionResult<ReviewDto> UpdateReview(
            [FromRoute(Name = "review-id")] int reviewId,
            [FromBody] ReviewRequest body)
        {
            try
            {
                var r = _manager.UpdateReview(reviewId, body.Comment, body.MovieId, body.UserId);
                return Ok(ReviewDtoMapper.From(r));
            }
            catch (ReviewNotFoundException e)
            {
                return NotFound(new ErrorResponse(e.Message));
            }

            catch (ShortCommentException ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }

        }

        [HttpDelete]
        [Route("{review-id}")]
        public ActionResult<ReviewDto> DeleteReview([FromRoute(Name = "review-id")] int reviewId)
        {

            try
            {
                var r = _manager.DeleteReview(reviewId);
                return Ok();
            }
            catch (ReviewNotFoundException e)
            {
                return NotFound(new ErrorResponse(e.Message));
            }
        }

    }

}

