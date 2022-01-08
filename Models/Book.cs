namespace WebApiPlayground.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Book;

    public class Book
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(BodyMaxLenght)]
        public string Body { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
