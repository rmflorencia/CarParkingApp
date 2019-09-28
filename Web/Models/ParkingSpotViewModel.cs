using CarParkingApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ParkingSpotViewModel
    {
        [Display(Name = "Spot No.")]
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Parking Floor")]
        public int ParkingFloorId { get; set; }

        [Display(Name = "Vehicle")]
        public Vehicle Vehicle { get; set; }
    }
}
