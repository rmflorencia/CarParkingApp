using CarParkingApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkingApp.Data
{
    public class Vehicle : BaseEntity
    {
        public override int Id { get; set; }

        public string LicensePlate { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Owner { get; set; }

        public int ParkingSpotId { get; set; }

        public virtual ParkingSpot ParkingSpot { get; set; }

    }
}
