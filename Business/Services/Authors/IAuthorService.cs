using Business.Entities;
using Business.Models;
using Business.Models.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public interface IAuthorService
    {
        Guid Create(CreateAuthorModel model);
        IEnumerable<AuthorModel> GetAll(); 
        AuthorModel Get(Guid id);
        void Remove(Guid id);

        void Update(Guid id, UpdateAuthorModel model);

    }
}
