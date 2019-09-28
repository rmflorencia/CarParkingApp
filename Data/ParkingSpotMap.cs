using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarParkingApp.Data
{
    public class ParkingSpotMap
    {
        public ParkingSpotMap(EntityTypeBuilder<ParkingSpot> entityBuilder)
        {
            entityBuilder.HasOne(ps => ps.ParkingFloor).WithMany(pf => pf.ParkingSpots).HasForeignKey(ps => ps.ParkingFloorId).IsRequired();
            //entityBuilder.HasOne(v => v.ParkingSpot).WithOne(ps => ps.Vehicle).HasForeignKey<ParkingSpot>(ps => new { ps.VehicleId, ps.VehicleLicensePlate }).IsRequired(false);
            entityBuilder.HasOne(ps => ps.Vehicle).WithOne(v => v.ParkingSpot).OnDelete(DeleteBehavior.Cascade).HasForeignKey<Vehicle>(v => v.ParkingSpotId);

        }
    }
}

