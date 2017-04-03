using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VehicleManager.API.Models;

namespace VehicleManager.API.Data
{
    public class VehicleManagerDataContext: DbContext
    {
        //Constructor
        public VehicleManagerDataContext() :base("VehicleManager")
        {

        }
        //DbSets
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Sale> Sales { get; set; }
        public IDbSet<Vehicle> Vehicles{ get; set; }

        //ModelConfiguration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                        .HasMany(vehicle => vehicle.Sales)
                        .WithRequired(sale => sale.Vehicle)
                        .HasForeignKey(sale => sale.VehicleId);
            modelBuilder.Entity<Customer>()
                        .HasMany(customer => customer.Sales)
                        .WithRequired(sale => sale.Customer)
                        .HasForeignKey(sale => sale.CustomerId);
        }

    }
}