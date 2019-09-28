using CarParkingApp.Data;
using CarParkingApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IParkingSpotService parkingSpotService;

        public VehicleController(IVehicleService vehicleService, IParkingSpotService parkingSpotService)
        {
            this.vehicleService = vehicleService;
            this.parkingSpotService = parkingSpotService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<VehicleViewModel> model = new List<VehicleViewModel>();

            vehicleService.GetAll().ToList().ForEach(v =>
            {
                VehicleViewModel Vehicle = new VehicleViewModel
                {
                    Id = v.Id,
                    Brand = v.Brand,
                    LicensePlate = v.LicensePlate,
                    Model = v.Model,
                    ParkingSpotId = v.ParkingSpotId
                };
                model.Add(Vehicle);
            });

            if (TempData["spotAvailabilityMessage"] != null)
                ViewBag.SpotAvailabilityMessage = TempData["spotAvailabilityMessage"].ToString();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
           //if (parkingSpotService.ParkingSpotsAvailable())
           //{
                VehicleViewModel model = new VehicleViewModel();
                return View(model);
           // }
           //else
           // {
           //     TempData["spotAvailabilityMessage"] = "There are no free spaces available";
           //     return RedirectToAction("Index");
           // }          
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleViewModel vehicleModel)
        {
            ParkingSpot parkingSpot = parkingSpotService.GetNextFreeSpace();
                       
            if (parkingSpot != null)
            {
                Vehicle VehicleEntity = new Vehicle
                {
                    Brand = vehicleModel.Brand,
                    LicensePlate = vehicleModel.LicensePlate,
                    Model = vehicleModel.Model,
                    Owner = vehicleModel.Owner,
                    AddedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    ParkingSpotId = parkingSpot.Id
                };

                parkingSpotService.ParkVehicle(VehicleEntity, parkingSpot);
            }
            else
            {
                TempData["spotAvailabilityMessage"] = "There are no free spaces available";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            Vehicle Vehicle = vehicleService.Get(id);
            string name = $"{Vehicle.LicensePlate} {Vehicle.Model}";
            return PartialView("DeleteVehicle", name);
        }

        [HttpPost]
        public ActionResult DeleteVehicle(int id, IFormCollection form)
        {
            vehicleService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}




