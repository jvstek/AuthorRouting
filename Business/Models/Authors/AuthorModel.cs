using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class AuthorModel
    {
        public Guid Id{get;set;}
        public int Age { get; set; }
        public string FulName { get; set; }
       
    }
}
