using Business.Entities;
using Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public static class InitialData
    {

        private static List<Review> lr = new List<Review>() {
            new Review { Comment="testing1",Rating=1,ReviewerName="mew" },
            new Review{ Comment = "testing2",Rating = 1, ReviewerName = "mewe" },
            new Review{ Comment = "testing3",Rating = 2, ReviewerName = "mewe" },
            new Review{ Comment = "testing4",Rating = 3, ReviewerName = "mewe" },
            new Review{ Comment = "testing5",Rating = 4, ReviewerName = "mewe" },
        };
        private static List<Book> bl = new List<Book> {
            new Book {Genre=Genre.Comedy,Summary="heel lang verhaal",Title="tes1",Reviews = lr},
            new Book {Genre=Genre.Fantasy,Summary="heel kort verhaal",Title="test2",Reviews = lr },
            new Book {Genre=Genre.Horror_fiction,Summary="heel kort verhaal",Title="test3" ,Reviews = lr},
            new Book {Genre=Genre.Mythology,Summary="heel lang verhaal",Title="test4",Reviews = lr },
            new Book {Genre=Genre.Romance,Summary="heel lang verhaal",Title="test5" },
        };

        public static ICollection<Author> AuthorList = new List<Author> {
            new Author { FirstName = "kevin", LastName="Te",DateOfBirth= new DateTime(1990, 1, 18),Books = bl} ,
            new Author { FirstName = "Harry", LastName="Te",DateOfBirth= new DateTime(1990, 1, 18),Books = bl },
            new Author { FirstName = "Harry", LastName="Te",DateOfBirth= new DateTime(1990, 1, 18),Books = bl },
        };

    }
}
