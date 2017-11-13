using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Models.Reviews
{
    public class CreateReviewModel
    {
        [IgnoreDataMember]
        public Guid Id { get; internal set; }
        public int Rating { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
    }
}
