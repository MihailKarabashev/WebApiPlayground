namespace WebApiPlayground.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Genre;

    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}