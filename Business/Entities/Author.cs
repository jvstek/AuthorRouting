using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class Author
    {
        public Guid AuthorId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Book> Books { get; set; }
        public Author()
        {
            AuthorId = Guid.NewGuid();
            Books = new List<Book>();
        }
        public string FullName() { return FirstName + " " + LastName; }

        public int GetAge()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - DateOfBirth.Year;
            return age;
        }
    }
}
