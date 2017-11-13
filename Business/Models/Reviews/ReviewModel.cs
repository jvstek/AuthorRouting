using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.Reviews
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
    }
}
