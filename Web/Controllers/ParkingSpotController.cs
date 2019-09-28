﻿using CarParkingApp.Data;
using CarParkingApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class ParkingSpotController : Controller
    {
        private readonly IParkingSpotService parkingSpotService;
        private readonly IVehicleService vehicleService;

        public ParkingSpotController(IParkingSpotService parkingSpotService, IVehicleService vehicleService)
        {
            this.parkingSpotService = parkingSpotService;
            this.vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ParkingSpotViewModel> model = new List<ParkingSpotViewModel>();

            parkingSpotService.GetParkingSpots().ToList().ForEach(ps =>
            {
                ParkingSpotViewModel parkingSpot = new ParkingSpotViewModel
                {
                    Id = ps.Id,
                    Vehicle = ps.Vehicle,
                    ParkingFloorId = ps.ParkingFloorId
                };
                model.Add(parkingSpot);
            });

            return View(model);
        }

        [HttpGet]
        public ActionResult AddParkingSpot()
        {
            ParkingSpotViewModel model = new ParkingSpotViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddParkingSpot(ParkingSpotViewModel model)
        {
            ParkingSpot parkingSpotEntity = new ParkingSpot
            {
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                ParkingFloorId = model.ParkingFloorId
            };

            parkingSpotService.InsertParkingSpot(parkingSpotEntity);
            if (parkingSpotEntity.Id > 0)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }
       
        [HttpGet]
        public ActionResult DeleteParkingSpot(int id)
        {
            ParkingSpot parkingSpot = parkingSpotService.GetParkingSpot(id);
            string name = $"{parkingSpot.Id}";
            return PartialView("DeleteParkingSpot", name);
        }

        [HttpPost]
        public ActionResult DeleteParkingSpot(int id, IFormCollection form)
        {
            parkingSpotService.DeleteParkingSpot(id);
            return RedirectToAction("Index");
        }          


    }
}




