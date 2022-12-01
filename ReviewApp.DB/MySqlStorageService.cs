using System;
using ReviewApp.Core.Exceptions;
using ReviewApp.Core.Model;
using ReviewApp.Core.Service;
using ReviewApp.DB.Mapper;
using ReviewApp.DB.Model;

namespace ReviewApp.DB
{
    public class MySqlStorageService : StorageService
    {
        private ApplicationContext _contex;

        public MySqlStorageService()
        {
            _contex = new();
            _contex.Database.EnsureCreated();
        }

        public Review CreateReview(string comment, int movieId, int userId)
        {
            var reviewToCreate = new ReviewEntity
            {
                Comment = comment,
                MovieId = movieId,
                UserId = userId
            };
            _contex.Reviews.Add(reviewToCreate);
            _contex.SaveChanges();

            return ReviewEntityMapper.From(reviewToCreate);

        }

        public bool DeleteReview(int reviewId)
        {
            var reviewToDelete = GetReviewOrFail(reviewId);
            _contex.Reviews.Remove(reviewToDelete);
            _contex.SaveChanges();
            return true;
        }

        public List<Review> GetReview() =>
            _contex.Reviews.Select(reviewEntry => ReviewEntityMapper.From(reviewEntry)).ToList();

        public Review GetReview(int reviewId)
        {
            var r = GetReviewOrFail(reviewId);
            return ReviewEntityMapper.From(r);
        }

        public Review UpdateReview(int reviewId, string comment, int userId, int movieId)
        {
            var reviewToUpdate = GetReviewOrFail(reviewId);
            reviewToUpdate.Comment = comment;
            reviewToUpdate.MovieId = movieId;
            reviewToUpdate.UserId = userId;
            _contex.SaveChanges();
            return ReviewEntityMapper.From(reviewToUpdate);
        }

        private ReviewEntity GetReviewOrFail(int reviewId)
        {
            var r = _contex.Reviews.Find(reviewId);

            if (r == null) throw new ReviewNotFoundException(reviewId);
            return r;
        }

    }
}

