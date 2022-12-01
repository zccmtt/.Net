using System;
using ReviewApp.Core.Exceptions;
using ReviewApp.Core.Model;
using ReviewApp.Core.Service;

namespace ReviewApp.Core
{
    public class ReviewApplicationManager
    {

        StorageService _storageService;

        public ReviewApplicationManager(StorageService storageService)
        {
            _storageService = storageService;
        }

        public List<Review> GetAllReviews() => _storageService.GetReview();

        public Review GetReview(int reviewId) => _storageService.GetReview(reviewId);

        public Review CreateReview(string comment, int userId, int movieId)
        {
            if (comment.Length < 10) throw new ShortCommentException();
            return _storageService.CreateReview(comment, userId, movieId);
        }

        public Review UpdateReview(int id, string updatedComment, int updatedUserId, int updatedMovieId)
        {
            if (updatedComment.Length < 10) throw new ShortCommentException();
            return _storageService.UpdateReview(id, updatedComment, updatedUserId, updatedMovieId);
        }

        public bool DeleteReview(int id) => _storageService.DeleteReview(id);

        public bool IsReviewListEmpty() => GetAllReviews().Count == 0;

    }
}

