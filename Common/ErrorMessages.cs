namespace WebApiPlayground.Common
{
    public static class ErrorMessages
    {
        public static class Book
        {
            public const string BookAlreadyExist = "Book you want to add already exist";

            public const string NameIsRequired = "Book name is required";

            public const string BodyIsRequired = "Book body is required";

            public const string PriceIsRequired = "Book price is required";

            public const string BookDoestNotExist = "Book doesn't exist.";

            public const string BookMinPriceValidation = "Minimum price cannot be less than zero";

            public const string BookMaxPriceValidation = "Maximum price cannot be less zero";

            public const string BookPriceValidationException = "Max price of book cannot be less than min price of book";

        }
    }
}
