using System;
using CarBook.Domain.Entities;
namespace CarBook.CarBookDomain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name{ get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
