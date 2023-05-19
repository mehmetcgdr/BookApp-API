﻿namespace BooksApp.API.Models.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Url { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        //public BookModel[] Books { get; set; }
    }
}
