using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.Book
{
    public class UpdateBookModel
    { 
        public string Title { get; set; }
        public Enums.Genre Genre { get; set; }
        public string Summary { get; set; }
    }
}
