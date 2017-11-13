using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.Author
{
    public class UpdateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
