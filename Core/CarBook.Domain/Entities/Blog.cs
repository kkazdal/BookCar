using System;
using CarBook.CarBookDomain.Entities;

namespace CarBook.Domain.Entities;

public class Blog
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public required Author Author { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CategoryId { get; set; }
    public required Category Category { get; set; }

}