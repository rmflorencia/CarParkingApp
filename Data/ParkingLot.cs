using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkingApp.Data
{
    public class ParkingLot : BaseEntity
    {
        public string ParkingLotCode { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int InitialNumberOfFloors { get; set; }
        public int InitialNumberOfSpotsPerFloor { get; set; }
        public virtual List<ParkingFloor> ParkingFloors { get; set; }
    }
}