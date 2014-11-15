namespace TheFishingSpot.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public virtual ApplicationUser Author { get; set; }

        [Required]
        public int NewsId { get; set; }

        [Required]
        public virtual News News { get; set; }
    }
}
