using CarParkingApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ParkingLotViewModel
    {
        [Display(Name = "Lot No.")]
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        [Display(Name = "Number of Floors")]
        public int InitialNumberOfFloors { get; set; }

        [Display(Name = "Number of Spots per Floor")]
        public int InitialNumberOfSpotsPerFloor { get; set; }

        [Display(Name = "Parking Floors")]
        public IEnumerable<ParkingFloor> ParkingFloors { get; set; }
    }
}
