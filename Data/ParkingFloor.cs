using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkingApp.Data
{
    public class ParkingFloor : BaseEntity
    {
        public int ParkingLotId { get; set; }
        public virtual ParkingLot ParkingLot { get; set; }
        public int? NumberOfSpots { get; set; }
        public virtual List<ParkingSpot> ParkingSpots { get; set; }
    }
}