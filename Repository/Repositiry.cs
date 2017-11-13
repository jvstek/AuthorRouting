using Business.Entities;
using Business.Models.Author;
using Business.Services;
using Business.Services.Books;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class Repository : IAuthorRepository, IBookForReviewRepository
    {

        private Dictionary<Guid, Author> _authorDictionary;
        //private Dictionary<Guid, Author> authorDictionary = DictionaryFiller(dat.AuthorList);


        public Repository()
        {
            _authorDictionary = new Dictionary<Guid, Author>();

            foreach (Author item in InitialData.AuthorList)
            {
                _authorDictionary.Add(item.AuthorId, item);
            }
        }

        public void Add(Author author)
        {
            _authorDictionary.Add(author.AuthorId, author);
        }

        public IEnumerable<Author> GetAll()
        {
            var allItems = _authorDictionary.Values.ToList();
            return allItems;
        }

        public Author Get(Guid id)
        {
            if (_authorDictionary.TryGetValue(id, out var model))
            {
                return model;
            }
            return null;
        }

        public void Remove(Guid id)
        {
            _authorDictionary.Remove(id);
        }

        public void AddBook(Guid id, Book book)
        {
            if (_authorDictionary.TryGetValue(id, out var model))
            {
                model.Books.Add(book);
            }

        }
        public void Update(Guid id, UpdateAuthorModel author)
        {
            if (!_authorDictionary.TryGetValue(id, out var model)) return;
            model.FirstName = author.FirstName;
            model.LastName = author.LastName;
            model.DateOfBirth = author.DateOfBirth;
        }
        public Book GetBook(Guid bookId)
        {
            return _authorDictionary.SelectMany(item => item.Value.Books).FirstOrDefault(book => book.Id == bookId);
        }

    }
}

