using Business.Models.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Books
{
    public interface IBookService
    {
        Guid CreateBook(Guid id,CreateBookModel model);
        IEnumerable<BookModel> GetAllBooks(Guid authorId);
        BookModel GetBook(Guid authorId, Guid bookId);
        void RemoveBook(Guid authorId, Guid bookId);
        void UpdateBook(Guid authorId, Guid bookId, UpdateBookModel model);
    }
}
