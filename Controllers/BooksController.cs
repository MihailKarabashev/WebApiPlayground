namespace WebApiPlayground.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApiPlayground.Dtos.Books;
    using WebApiPlayground.Models;
    using WebApiPlayground.Services;

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
        public async Task<ActionResult<BookReadDto>> Create([FromBody] BookCreateDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookService.CreateAsync(book);

            var bookReadDto = _mapper.Map<BookReadDto>(book);

            return this.CreatedAtAction(nameof(GetBookById), new { id = bookReadDto.Id }, bookReadDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookReadDto>> GetBookById(string id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if(book == null)
            {
                return this.NotFound();
            }

            var bookReadDto = _mapper.Map<BookReadDto>(book);

            return this.Ok(bookReadDto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookReadDto>>> GetAllBooks()
        {
            var allBooks = await _bookService.GetAllAsync();
            var allBookDtos = _mapper.Map<IEnumerable<BookReadDto>>(allBooks);
            return this.Ok(allBookDtos);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteBook(string id)
        {
            await _bookService.RemoveAsync(id);
            return this.NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateBook(string id, BookUpdateDto bookUpdateDto)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                return this.NotFound();
            }

            _mapper.Map(bookUpdateDto, book);

            await _bookService.UpdateAsync(book);

            return this.NoContent();
        }
    }
}
