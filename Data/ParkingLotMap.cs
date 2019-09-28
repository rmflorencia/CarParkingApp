using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarParkingApp.Data
{
    public class ParkingLotMap
    {
        public ParkingLotMap(EntityTypeBuilder<ParkingLot> entityBuilder)
        {
            entityBuilder.Property(pl => pl.CompanyName).IsRequired();
            entityBuilder.Property(pl => pl.Address).IsRequired();
            entityBuilder.Property(pl => pl.ZipCode).IsRequired();
            entityBuilder.Property(pl => pl.InitialNumberOfFloors).IsRequired();
            entityBuilder.Property(pl => pl.InitialNumberOfSpotsPerFloor).IsRequired();
            entityBuilder.HasMany(pl => pl.ParkingFloors).WithOne(pf => pf.ParkingLot).OnDelete(DeleteBehavior.Cascade).IsRequired();

        }
    }
}
