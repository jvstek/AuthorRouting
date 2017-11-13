using Business.Entities;
using System; 

namespace Business.Services.Books
{
    public interface IBookForReviewRepository
    {
        Book GetBook(Guid bookId);
    }
}
