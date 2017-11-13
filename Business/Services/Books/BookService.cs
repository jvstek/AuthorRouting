using Business.Entities;
using Business.Models.Book;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Business.Models;
using Business.Models.Author;

namespace Business.Services.Books
{
    public class BookService:IBookService
    {
        private readonly IAuthorRepository _repository;
        public BookService(IAuthorRepository repository)
        {
            this._repository = repository;
        } 
        public Guid CreateBook(Guid authorId, CreateBookModel model)
        {
            var parent =_repository.Get(authorId);
            var newBook = new Book
            {
                Genre = model.Genre,
                Title = model.Title,
                Summary = model.Summary,
            };
            parent.Books.Add(newBook);  
            return newBook.Id;
        }

        public IEnumerable<BookModel> GetAllBooks(Guid authorId)
        { 
            var models = _repository.Get(authorId).Books.Select(book => new BookModel
            {
                Id =  book.Id,
                Genre = book.Genre,
                Summary = book.Summary ,
                Title = book.Title
            });
            return models;
        }

        public BookModel GetBook(Guid authorId, Guid bookId)
        {
            var child = _repository.Get(authorId).Books.Single(book =>  book.Id ==bookId);
            var childModel = new BookModel {
                Id = child.Id,
                Title = child.Title,
                Genre = child.Genre,
                Summary = child.Summary 
            };
            return childModel;
                 
        }

        public void RemoveBook(Guid authorId, Guid bookId)
        {
            _repository.Get(authorId).Books.RemoveAll(book => book.Id == bookId);
        }

        public void UpdateBook(Guid authorId, Guid bookId, UpdateBookModel model)
        {
            var child = _repository.Get(authorId).Books.SingleOrDefault(book => book.Id == bookId);
            Debug.Assert(child != null, nameof(child) + " != null");
            child.Summary = model.Summary;
            child.Title = model.Title;
            child.Genre = model.Genre;
        }
    }
}
