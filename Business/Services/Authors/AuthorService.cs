using Business.Entities;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models.Author;

namespace Business.Services
{
    public class AuthorService:IAuthorService
    {
        public readonly IAuthorRepository repository;
        public AuthorService(IAuthorRepository repository)
        {
            this.repository = repository;
        }
        public Guid Create(CreateAuthorModel model)
        {
            var newAuthor = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth
            };
            repository.Add(newAuthor);
           return newAuthor.AuthorId;
            
        }

        public IEnumerable<AuthorModel> GetAll()
        {

            var models = repository.GetAll().Select(Author => new AuthorModel
            {
                Id = Author.AuthorId,
                FulName = Author.FullName(),
                Age = Author.GetAge(),
              
            }).ToList(); 
            return models;
        }

        public AuthorModel Get(Guid id)
        {
            var Author = repository.Get(id);

            AuthorModel model = null;
            if (Author != null)
            {
                model = new AuthorModel
                {
                    Id = Author.AuthorId,
                    FulName = Author.FullName(),
                    Age = Author.GetAge(),
                };
            }
            return model;
        }

        public void Remove(Guid id)
        {
            repository.Remove(id);
        }

        public void Update(Guid id, UpdateAuthorModel updateModel)
        { 
            var entity = repository.Get(id);
      
            entity.LastName = updateModel.LastName;
            entity.FirstName = updateModel.FirstName;
            entity.DateOfBirth = updateModel.DateOfBirth;
      
            
        }
    }
}
