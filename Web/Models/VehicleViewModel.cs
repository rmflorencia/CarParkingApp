using CarParkingApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class VehicleViewModel
    {
        [Display(Name = "Vehicle No.")]
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "License Plate No.")]
        public string LicensePlate { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Owner { get; set; }

        [Display(Name = "Parking Spot No.")]
        public int ParkingSpotId { get; set; }
    }
}
