using System;
using Microsoft.EntityFrameworkCore;
using Parsage.BikeShop.Models;

namespace Parsage.BikeShop.Context
{
    public class BikeContext : DbContext
    {
        public BikeContext(DbContextOptions options)
            : base(options){}

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
