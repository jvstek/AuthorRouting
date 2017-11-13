using Business.Models.Reviews;
using System;
using System.Collections.Generic;

namespace Business.Services.Reviews
{
    public interface IReviewService
    {
        Guid CreateReview(Guid bookId, CreateReviewModel model);
        IEnumerable<ReviewModel> GetAllReviews(Guid bookId);
        ReviewModel GetReview(Guid bookId, Guid reviewId);
        void RemoveReview(Guid bookId, Guid reviewId);
        void UpdateReview(Guid bookId, Guid reviewId,UpdateReviewModel model);
    }
}