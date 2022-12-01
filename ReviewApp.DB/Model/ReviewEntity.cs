using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewApp.DB.Model
{
    [Table("comment")]
    public class ReviewEntity
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("comment"), StringLength(255), DataType(DataType.Text)]
        public string Comment { get; set; } = "";

        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
    }
}

