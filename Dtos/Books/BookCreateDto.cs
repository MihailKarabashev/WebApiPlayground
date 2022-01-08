namespace WebApiPlayground.Dtos.Books
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Book;
    using static Common.ErrorMessages.Book;

    public class BookCreateDto
    {
        [Required(ErrorMessage = NameIsRequired)]
        [StringLength(NameMaxLength,MinimumLength = NameMinLength)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = PriceIsRequired)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = BodyIsRequired)]
        [StringLength(BodyMaxLength, MinimumLength =BodyMinLength)]
        public string Body { get; set; }
    }
}
