using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarParkingApp.Data
{
    public class ParkingFloorMap
    {
        public ParkingFloorMap(EntityTypeBuilder<ParkingFloor> entityBuilder)
        {
            entityBuilder.Property(pf => pf.NumberOfSpots).IsRequired(false);
            entityBuilder.HasOne(pf => pf.ParkingLot).WithMany(pl => pl.ParkingFloors).HasForeignKey(pf => pf.ParkingLotId).IsRequired();
            entityBuilder.HasMany(pf => pf.ParkingSpots).WithOne(ps => ps.ParkingFloor).OnDelete(DeleteBehavior.Cascade).IsRequired();
    
        }
}
}