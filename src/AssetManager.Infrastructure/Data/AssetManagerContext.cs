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

        DbSet<Company> Companies { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
    }
}
