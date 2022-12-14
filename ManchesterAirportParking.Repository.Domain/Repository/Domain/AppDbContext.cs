namespace ManchesterAirportParking.Repository.Domain
{
    using ManchesterAirportParking.Repository.Domain.Converters;
    using ManchesterAirportParking.Repository.Domain.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingArea> ParkingAreas { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Space> Spaces { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        /// <summary>
        ///     Configures the schema needed for the identity framework.
        /// </summary>
        /// <param name="builder">
        ///     The builder being used to construct the model for this context.
        /// </param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // do the identity model building stuff
            base.OnModelCreating(builder);

            // Seed in the admin account
            builder.Entity<IdentityUser>(x =>
                                         {
                                             IdentityUser superUser = new IdentityUser
                                                                      {
                                                                          // not great idea, pops up in migrations
                                                                          Id = Guid.NewGuid()
                                                                                   .ToString(),
                                                                          UserName = "admin@ca.vu",
                                                                          Email = "admin@ca.vu",
                                                                          NormalizedEmail = "ADMIN@CA.VU",
                                                                          EmailConfirmed = true,
                                                                          PhoneNumberConfirmed = true,
                                                                      };

                                             superUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superUser, "password123");

                                             x.HasData(superUser);
                                         });

            builder.Entity<ParkingArea>(x =>
                                        {
                                            x.ToTable("ParkingAreas");

                                            x.HasKey(y => y.Id);

                                            x.Property(y => y.Id)
                                             .ValueGeneratedOnAdd();

                                            x.HasMany<Space>()
                                             .WithOne()
                                             .HasForeignKey(y => y.ParkingAreaId);

                                            x.HasData(new ParkingArea
                                                      {
                                                          Id = 1,
                                                          Name = "North"
                                                      });
                                        });

            builder.Entity<Reservation>(x =>
                                        {
                                            x.ToTable("Reservations");

                                            x.HasKey(y => y.Id);

                                            x.Property(y => y.Id)
                                             .ValueGeneratedOnAdd();

                                            x.HasOne(y => y.Space)
                                             .WithMany()
                                             .HasForeignKey(y => y.SpaceId);

                                            x.HasOne(y => y.Vehicle)
                                             .WithMany()
                                             .HasForeignKey(y => y.VehicleId);

                                            x.Property(y => y.From)
                                             .HasConversion<LocalDateConverter>()
                                             .HasColumnType("date");

                                            x.Property(y => y.To)
                                             .HasConversion<LocalDateConverter>()
                                             .HasColumnType("date");
                                        });

            builder.Entity<Space>(x =>
                                  {
                                      x.ToTable("Spaces");

                                      x.HasKey(y => y.Id);

                                      x.Property(y => y.Id)
                                       .ValueGeneratedOnAdd();

                                      x.HasOne(y => y.ParkingArea)
                                       .WithMany(y => y.Spaces)
                                       .HasForeignKey(y => y.ParkingAreaId)
                                       .IsRequired()
                                       .OnDelete(DeleteBehavior.NoAction);

                                      x.HasMany(y => y.Reservations)
                                       .WithOne(y => y.Space)
                                       .HasForeignKey(y => y.SpaceId)
                                       .IsRequired()
                                       .OnDelete(DeleteBehavior.NoAction);

                                      x.HasData(new Space { Id = 1, ParkingAreaId = 1, Alias = "1", Reference = "North.Space.1" },
                                                new Space { Id = 2, ParkingAreaId = 1, Alias = "2", Reference = "North.Space.2" },
                                                new Space { Id = 3, ParkingAreaId = 1, Alias = "3", Reference = "North.Space.3" },
                                                new Space { Id = 4, ParkingAreaId = 1, Alias = "4", Reference = "North.Space.4" },
                                                new Space { Id = 5, ParkingAreaId = 1, Alias = "5", Reference = "North.Space.5" },
                                                new Space { Id = 6, ParkingAreaId = 1, Alias = "6", Reference = "North.Space.6" },
                                                new Space { Id = 7, ParkingAreaId = 1, Alias = "7", Reference = "North.Space.7" },
                                                new Space { Id = 8, ParkingAreaId = 1, Alias = "8", Reference = "North.Space.8" },
                                                new Space { Id = 9, ParkingAreaId = 1, Alias = "9", Reference = "North.Space.9" },
                                                new Space { Id = 10, ParkingAreaId = 1, Alias = "10", Reference = "North.Space.10" });
                                  });

            builder.Entity<Vehicle>(x =>
                                    {
                                        x.ToTable("Vehicles");

                                        x.HasKey(y => y.Id);

                                        x.Property(y => y.Id)
                                         .ValueGeneratedOnAdd();

                                        x.HasMany(y => y.Reservations)
                                         .WithOne(y => y.Vehicle)
                                         .HasForeignKey(y => y.VehicleId)
                                         .IsRequired()
                                         .OnDelete(DeleteBehavior.NoAction);
                                    });

            builder.Entity<Customer>(x =>
                                     {
                                         x.ToTable("Customers");

                                         x.HasKey(y => y.Id);

                                         x.Property(y => y.Id)
                                          .ValueGeneratedOnAdd();
                                     });
        }
    }
}
