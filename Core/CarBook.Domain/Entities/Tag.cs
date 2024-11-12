using System;

namespace CarBook.Domain.Entities;

public class Tag
{
    public int Id { get; set; }
    public required string TagName { get; set; }
    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}
