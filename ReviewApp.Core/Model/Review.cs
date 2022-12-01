using System;
namespace ReviewApp.Core.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public Review(int id, string comment, int userId, int movieId)
        {
            Id = id;
            Comment = comment;
            UserId = userId;
            MovieId = movieId;
        }
    }
}

