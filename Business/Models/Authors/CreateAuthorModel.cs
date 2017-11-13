using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
