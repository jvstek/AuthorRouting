using Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Summary { get; set; }
        public List<Review> Reviews { get; set; }
        public Book()
        {
            Id = Guid.NewGuid();
            Reviews = new List<Review>();
        }
    }
}
