using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Review
    {
        public Guid Id { get; private set; }
        public int Rating { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }

        public Review()
        {
            Id = Guid.NewGuid();
        }
         
    }
}
