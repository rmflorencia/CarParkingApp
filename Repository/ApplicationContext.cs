using CarParkingApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       
            base.OnModelCreating(modelBuilder);
            new ParkingLotMap(modelBuilder.Entity<ParkingLot>());
            new ParkingFloorMap(modelBuilder.Entity<ParkingFloor>());
            new ParkingSpotMap(modelBuilder.Entity<ParkingSpot>());
            new VehicleMap(modelBuilder.Entity<Vehicle>());
        }
    }
}
