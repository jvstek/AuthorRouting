using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Services.Books;
using Business.Models.Book;

namespace api.Controllers
{
  
    [Route("api/authors/{authorId:guid}/books")]
    public class BooksController : Controller
    {
        public readonly IBookService BookService;
        public BooksController(IBookService booksService)
        {
            this.BookService = booksService;
        }

        [HttpGet("")]
        public IActionResult GetAllBooks(Guid authorId )
        {
            var author = BookService.GetAllBooks(authorId);
            return Ok(author);
            
        }

        [HttpPost("")]
        public IActionResult Create(Guid authorId, [FromBody]CreateBookModel model)
        {
             
            var newlyCreated = BookService.CreateBook(authorId,model);
            return CreatedAtRoute("GetBook", new {authorId,  bookid=newlyCreated }, newlyCreated);
        }   


        [HttpGet("{bookId:guid}" ,Name = "GetBook")]
        public IActionResult Get(Guid authorId, Guid bookId)
        {
            var author = BookService.GetBook(authorId,bookId);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
      
        }
        [HttpPost("{id:guid}", Name = "RemoveBook")]
        public IActionResult Delete(Guid authorId, Guid bookId)
        {
            BookService.RemoveBook(authorId, bookId);
            return NoContent();
        }
        [HttpPut("{id:guid}", Name = "UpdateBook")]
        public IActionResult Update(Guid authorId,Guid bookId,[FromBody]UpdateBookModel model)
        {
            BookService.UpdateBook(authorId, bookId, model);
            return Ok();
        }

    }
}