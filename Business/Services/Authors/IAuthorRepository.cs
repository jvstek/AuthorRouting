using Business.Entities;
using Business.Models.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        IEnumerable<Author> GetAll();
        Author Get(Guid id); 
        void Remove(Guid id);

        //Book GetBook(Guid bookId);
        // void Update(Guid id, UpdateAuthorModel model);
    }
}
