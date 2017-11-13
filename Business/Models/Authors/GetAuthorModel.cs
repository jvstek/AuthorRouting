using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.Author
{
    public class GetAuthorModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } 
    }
}
