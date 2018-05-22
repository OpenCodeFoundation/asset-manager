using AssetManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManager.Infrastructure.Data
{
    public class AssetManagerContext : DbContext
    {
        public AssetManagerContext( DbContextOptions<AssetManagerContext> options) : base(options) { } 

        public DbSet<Company> Companies { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Depreciation> Depreciations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<StatusLabel> StatusLabel { get; set; }

        public DbSet<CustomFields> CustomFields { get; set; }
        public DbSet<AssetModels> AssetModels { get; set; }
        public DbSet<Location> Location { get; set; }
    }
}
