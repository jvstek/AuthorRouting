using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Business.Models;
using Business.Models.Author;

namespace api.Controllers
{

    [Route("api/Author")]
    public class AuthorsController : Controller
    {
        public readonly IAuthorService AuthorService;
        public AuthorsController(IAuthorService authorService)
        {
            this.AuthorService = authorService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var author = AuthorService.GetAll();
            return Ok(author);
            
        }

        [HttpPost("")]
        public IActionResult Create([FromBody]CreateAuthorModel model)
        {
           Guid id= AuthorService.Create(model);
           
            return CreatedAtRoute("GetAuthor", new { Id = id }, model);
        }


        [HttpGet("{id:guid}", Name = "GetAuthor")]
        public IActionResult Get(Guid id)
        {
            var author = AuthorService.Get(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        
        }
        [HttpPost("{id:guid}", Name = "DeleteAuthor")]
        public IActionResult Delete(Guid id)
        {
            AuthorService.Remove(id);
            return NoContent();
        }
        [HttpPut("{id:guid}", Name = "UpdateAuthor")]
        public IActionResult Update([FromBody]UpdateAuthorModel model, Guid id)
        {
            AuthorService.Update(id, model);
            return Ok();
        }
    }
}
