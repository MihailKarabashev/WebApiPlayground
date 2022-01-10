namespace WebApiPlayground.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants.Book;
    using static Common.ErrorMessages.Book;


    public class BookParameters : QueryStringParameters
    {
        [Range(BookMinPrice, BookMaxPrice)]
        public decimal MinPrice { get; set; }

        [Range(BookMinPrice, BookMaxPrice)]
        public decimal MaxPrice { get; set; } = BookMaxPrice;

        public bool IsPriceValid => MaxPrice > MinPrice;
    }
}
