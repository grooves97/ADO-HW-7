using Warehouse.Models;
using System;
using System.Data.Entity;

namespace Warehouse.DataAcces
{

    public class WarehouseContext : DbContext
    {
        public WarehouseContext()
            : base("appConnection")
        {}

        public DbSet<Product> Products { get; set; }
    }
}