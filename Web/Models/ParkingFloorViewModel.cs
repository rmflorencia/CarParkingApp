using CarParkingApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ParkingFloorViewModel
    {
        [Display(Name = "Floor No.")]
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "No. of Spots")]
        public int NumberOfSpots{ get; set; }

        [Display(Name = "Parking Lot")]
        public int ParkingLotId { get; set; }

        [Display(Name = "Parking Spots")]
        public IEnumerable<ParkingSpot> ParkingSpots { get; set; }
    }
}
