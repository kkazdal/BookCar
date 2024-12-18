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
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<RentACarProcess> RentACarProcesses { get; set; }
    public DbSet<RentACar> RentACar { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
        .HasOne(x => x.PickUpLocation)
        .WithMany(y => y.PickUpReservation)
        .HasForeignKey(z => z.PickUpLocationId)
        .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Reservation>()
        .HasOne(x => x.DropOffLocation)
        .WithMany(y => y.DropOffReservation)
        .HasForeignKey(z => z.DropOffLocationId)
        .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
