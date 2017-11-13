

using Business.Entities;
using Business.Models.Book;
using Business.Models.Reviews;
using Business.Services.Books;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        // public readonly IBookForReviewRepository Repository;//specially to get that 1 book thought me alot. (and now i have to do it the way it is suppose to be like each having their own repository's)

        private readonly IAuthorRepository Repository;
        public ReviewService(IAuthorRepository repository)
        {
            this.Repository = repository;
        }
        public Guid CreateReview(Guid bookId, CreateReviewModel model)
        {

            Book books = BookFromAuthor(bookId);

             
            var newReview = new Review
            {
                Comment = model.Comment,
                Rating = model.Rating,
                ReviewerName = model.ReviewerName
            };
            books.Reviews.Add(newReview);
            return newReview.Id;
        }

        public IEnumerable<ReviewModel> GetAllReviews(Guid bookId)
        {
            
            var models = BookFromAuthor(bookId).Reviews.Select(review => new ReviewModel
            {
                Id = review.Id,
                Comment = review.Comment,
                Rating = review.Rating,
                ReviewerName = review.ReviewerName
            });
            return models;


        }

        public ReviewModel GetReview(Guid bookId, Guid reviewId)
        {
            var child = BookFromAuthor(bookId).Reviews.Single(review => review.Id == reviewId);
            var childModel = new ReviewModel
            {
                
                Id = child.Id,
                Comment = child.Comment,
                Rating = child.Rating,
                ReviewerName = child.ReviewerName
            };
            return childModel;
        }

        public void RemoveReview(Guid bookId, Guid reviewId)
        {
            BookFromAuthor(bookId).Reviews.RemoveAll(review => review.Id == reviewId);
        }

        public void UpdateReview(Guid bookId, Guid reviewId, UpdateReviewModel model)
        {
            var child = BookFromAuthor(bookId).Reviews.Single(review => review.Id == reviewId); 
            child.Comment = model.Comment;
            child.Rating = model.Rating;
            child.ReviewerName = model.ReviewerName;
          
        }

        // would have been so much easier to give the AuthorId to search for the book but i dont know if that is best practice......
        // and why that would be best practice. (especially that one why a best practice is the best practice. 
        // This way is les information is given and it wil take longer to get the information... 
        // pulling apart the repository with a seperate review/book repository is a option. I dont know what "best practice is"
        private Book BookFromAuthor(Guid bookId)
        { 
            return Repository.GetAll().SelectMany(author => author.Books).FirstOrDefault(book => book.Id == bookId);
            //return Repository.GetBook(bookId);
            //return repository.Get().Books.Single(book => book.AuthorId == bookId);
            //repository.GetAll
            //return Book;
        }
    }
}
