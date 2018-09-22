using AssetManager.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManager.Infrastructure.Data
{
    public class AssetManagerContext : DbContext
    {
        public AssetManagerContext( DbContextOptions<AssetManagerContext> options) : base(options) { } 

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Depreciation> Depreciations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<StatusLabel> StatusLabel { get; set; }
        public DbSet<CustomFields> CustomFields { get; set; }
        public DbSet<AssetModels> AssetModels { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<Accessory> Accessory { get; set; }
        public DbSet<Consumable> Consumable { get; set; }
        public DbSet<Components> Components { get; set; }
        public DbSet<License> License { get; set; }
    }
}
