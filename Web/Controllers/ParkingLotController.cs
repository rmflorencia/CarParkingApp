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
    public class ParkingLotController : Controller
    {
        private readonly IParkingLotService parkingLotService;
        private readonly IParkingFloorService parkingFloorService;

        public ParkingLotController(IParkingLotService parkingLotService, IParkingFloorService parkingFloorService)
        {
            this.parkingLotService = parkingLotService;
            this.parkingFloorService = parkingFloorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ParkingLotViewModel> model = new List<ParkingLotViewModel>();

            parkingLotService.GetAll().ToList().ForEach(pl =>
            {
                ParkingLotViewModel parkingLot = new ParkingLotViewModel
                {
                    Id = pl.Id,
                    CompanyName = pl.CompanyName,
                    Address = pl.Address,
                    ZipCode = pl.ZipCode,
                    InitialNumberOfFloors = pl.InitialNumberOfFloors,
                    InitialNumberOfSpotsPerFloor = pl.InitialNumberOfSpotsPerFloor,
                    ParkingFloors = pl.ParkingFloors
                };

                model.Add(parkingLot);
            });

            return View(model);
        }

        [HttpGet]
        public ActionResult AddParkingLot()
        {
            ParkingLotViewModel model = new ParkingLotViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddParkingLot(ParkingLotViewModel model)
        {
            ParkingLot parkingLotEntity = new ParkingLot
            {
                CompanyName = model.CompanyName,
                Address = model.Address,
                ZipCode = model.ZipCode,
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                InitialNumberOfFloors = model.InitialNumberOfFloors,
                InitialNumberOfSpotsPerFloor = model.InitialNumberOfSpotsPerFloor
            };

            List<ParkingFloor> parkingFloors = new List<ParkingFloor>();

            for (int i = 0; i < model.InitialNumberOfFloors; i++)
            {
                ParkingFloor parkingFloor = new ParkingFloor
                {
                    AddedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                };

                parkingFloor.ParkingSpots = new List<ParkingSpot>();

                for (int j = 0; j < model.InitialNumberOfSpotsPerFloor; j++)
                {
                    ParkingSpot parkingSpot = new ParkingSpot
                    {
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow,
                    };

                    parkingSpot.ParkingFloor = parkingFloor;
                    parkingFloor.ParkingSpots.Add(parkingSpot);
                }

                parkingFloor.ParkingLot = parkingLotEntity;
                parkingFloors.Add(parkingFloor);
            }

            parkingLotEntity.ParkingFloors = parkingFloors;
            parkingLotService.Insert(parkingLotEntity);
            if (parkingLotEntity.Id > 0)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditParkingLot(int? id)
        {
            ParkingLotViewModel model = new ParkingLotViewModel();
            if (id.HasValue && id != 0)
            {
                ParkingLot parkingLotEntity = parkingLotService.Get(id.Value);
                model.Address = parkingLotEntity.Address;
                model.CompanyName = parkingLotEntity.CompanyName;
                model.ZipCode = parkingLotEntity.ZipCode;

            }
            return View("EditParkingLot", model);
        }

        [HttpPost]
        public ActionResult EditParkingLot(ParkingLotViewModel model)
        {
            ParkingLot parkingLotEntity = parkingLotService.Get(model.Id);
            parkingLotEntity.Address = model.Address;
            parkingLotEntity.CompanyName = model.CompanyName;
            parkingLotEntity.ZipCode = model.ZipCode;
            parkingLotEntity.ModifiedDate = DateTime.UtcNow;
            parkingLotService.Update(parkingLotEntity);

            if (parkingLotEntity.Id > 0)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteParkingLot(int id)
        {
            ParkingLot parkingLot = parkingLotService.Get(id);
            string name = $"{parkingLot.Id} {parkingLot.CompanyName}";
            return View("DeleteParkingLot", name);
        }

        [HttpPost]
        public ActionResult DeleteParkingLot(int id, IFormCollection form)
        {
            parkingLotService.Delete(id);
            return RedirectToAction("Index");
        }        
    }
}




                   