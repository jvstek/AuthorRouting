using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.Reviews
{
    public class UpdateReviewModel
    {  
        public int Rating { get; internal set; }
        public string ReviewerName { get; internal set; }
        public string Comment { get; internal set; }
    }
}
