namespace TheFishingSpot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class News
    {
        private ICollection<Comment> comments;
        public News()
        {
            this.comments = new HashSet<Comment>();
        }
        
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        
        [Required]
        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Comment> Comments 
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}