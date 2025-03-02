using SchedulingApplication.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SchedulingApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            //this.Database.Log = s => Console.WriteLine(s);

            // Disable migration checks
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Configure table names to match database conventions
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Country>().ToTable("country");
            modelBuilder.Entity<City>().ToTable("city");
            modelBuilder.Entity<Address>().ToTable("address");
            modelBuilder.Entity<Customer>().ToTable("customer");
            modelBuilder.Entity<Appointment>().ToTable("appointment");

            // Configure relationships
            modelBuilder.Entity<City>()
                .HasRequired(c => c.Country)
                .WithMany(ct => ct.Cities)
                .HasForeignKey(c => c.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasRequired(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasRequired(c => c.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(c => c.AddressId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.AppointmentId)
                .Property(a => a.AppointmentId)
                .HasColumnName("appointmentId");

            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);

            // Property configurations to match database schema
            modelBuilder.Entity<Country>()
                .Property(c => c.CountryName)
                .HasColumnName("country");

            modelBuilder.Entity<City>()
                .Property(c => c.CityName)
                .HasColumnName("city");

            modelBuilder.Entity<Address>()
                .Property(a => a.AddressLine)
                .HasColumnName("address");

            modelBuilder.Entity<Address>()
                .Property(a => a.AddressLine2)
                .HasColumnName("address2");
        }

        /*
        public override int SaveChanges()
        {
            // Iterate through all Added/Modified entities
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    // Check if it's our entity type with DateTime properties
                    if (entry.Entity is BaseEntity)
                    {
                        // Update audit timestamps
                        var entity = entry.Entity as BaseEntity;

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreateDate = DateTime.UtcNow;
                            entity.CreatedBy = LoginForm.LoggedInUser?.UserName ?? "system";
                        }

                        entity.LastUpdate = DateTime.UtcNow;
                        entity.LastUpdateBy = LoginForm.LoggedInUser?.UserName ?? "system";
                    }

                    // Get entity type and properties
                    var entityType = entry.Entity.GetType();
                    var dateTimeProperties = entityType.GetProperties()
                        .Where(p => (p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?)) && 
                        !p.GetCustomAttributes(typeof(NotMappedAttribute), true).Any());


                    // Ensure all DateTime properties are in UTC
                    foreach (var prop in dateTimeProperties)
                    {
                        // Get current value
                        var value = prop.GetValue(entry.Entity) as DateTime?;

                        if (value.HasValue && value.Value.Kind != DateTimeKind.Utc)
                        {
                            // Set value back as UTC
                            prop.SetValue(entry.Entity, DateTime.SpecifyKind(value.Value, DateTimeKind.Utc));
                        }
                    }
                }
            }

            return base.SaveChanges();
        }
        */
    }
}