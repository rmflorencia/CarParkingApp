using System.ComponentModel.DataAnnotations.Schema;

namespace CarParkingApp.Data
{
    public class ParkingSpot : BaseEntity
    {
        public string ParkingSpotCode { get; set; }
        public int ParkingFloorId { get; set; }
        public virtual ParkingFloor ParkingFloor { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}