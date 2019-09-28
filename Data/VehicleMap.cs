using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkingApp.Data
{
    public class VehicleMap
    {
        public VehicleMap(EntityTypeBuilder<Vehicle> entityBuilder)
        {
            entityBuilder.HasKey(v => v.LicensePlate);
            entityBuilder.Property(v => v.Brand).IsRequired();
            entityBuilder.Property(v => v.Model).IsRequired();
            entityBuilder.Property(v => v.Owner).IsRequired();
           // entityBuilder.HasOne(v => v.ParkingSpot).WithOne(ps => ps.Vehicle).HasForeignKey<ParkingSpot>(ps => new { ps.VehicleId, ps.VehicleLicensePlate }).IsRequired(false); 
        }
    }
}