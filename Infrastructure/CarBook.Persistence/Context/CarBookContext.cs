using System;
using CarBook.CarBookDomain.Entities;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Context;

public class CarBookContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;User Id=SA;Password=reallyStrongPwd123;initial Catalog=CarBook;integrated security=true;TrustServerCertificate=true;Trusted_Connection=false;");

    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDescription> CarDescriptions { get; set; }
    public DbSet<CarFeature> CarFeatures { get; set; }
    public DbSet<CarPricing> CarPricings { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<FooterAddress> FooterAddresses { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Pricing> Pricings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Author> Authors { get; set; }
}
