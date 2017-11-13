using Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.Book
{
    public class CreateBookModel
    { 
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Summary { get; set; }
    }
}
