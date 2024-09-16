using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> villaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
                    new Villa()
                    {
                        Id = 1,
                        Name = "Royal Villa",
                        Description = "Fusse 11 ticidunt max",
                        ImageUrl = "https://placehold.co/600x400",
                        Occupancy = 4,
                        Price = 200,
                        Sqft = 550
                    },
                    new Villa()
                    {
                        Id = 2,
                        Name = "Preminum Pool Villa",
                        Description = "Mai ben nhau ban nhe so 2 oi olala",
                        ImageUrl = "https://placehold.co/600x401",
                        Occupancy = 4,
                        Price = 300,
                        Sqft = 420
                    },
                    new Villa()
                    { 
                        Id = 3,
                        Name = "Luxury Pool Villa",
                        Description = "Chim con tren canh cay hot liu lo hot liu lo",
                        ImageUrl = "https://placehold.co/600x402",
                        Occupancy = 4,
                        Price = 460,
                        Sqft = 291
                    }

                );

            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 102,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 103,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 104,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 201,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 202,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 203,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 301,
                    VillaId = 3,
                },
                new VillaNumber
                {
                    Villa_Number = 302,
                    VillaId = 3,
                }
                );
        }

    }
}
