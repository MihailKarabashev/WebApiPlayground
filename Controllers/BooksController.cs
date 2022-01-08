using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiPlayground.Dtos.Books;
using WebApiPlayground.Models;
using WebApiPlayground.Services;

namespace WebApiPlayground.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(
            IBookService bookService,
            IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookReadDto>> Create(BookCreateDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookService.CreateAsync(book);

            var bookReadDto = _mapper.Map<BookReadDto>(book);

            return this.CreatedAtAction(nameof(GetBookById), new { id = bookReadDto.Id }, bookReadDto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookReadDto> GetBookById(string id)
        {
            return this.Ok();
        }
    }
}
