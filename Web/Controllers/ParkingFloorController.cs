using CarParkingApp.Data;
using CarParkingApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class ParkingFloorController : Controller
    {
        private readonly IParkingFloorService parkingFloorService;
        private readonly IParkingLotService parkingLotService;

        public ParkingFloorController(IParkingFloorService parkingFloorService, IParkingLotService parkingLotService)
        {
            this.parkingFloorService = parkingFloorService;
            this.parkingLotService = parkingLotService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ParkingFloorViewModel> model = new List<ParkingFloorViewModel>();

            parkingFloorService.GetAll().ToList().ForEach(pf =>
            {
                ParkingFloorViewModel parkingFloor = new ParkingFloorViewModel
                {
                    Id = pf.Id,
                    ParkingSpots = pf.ParkingSpots,
                    ParkingLotId = pf.ParkingLotId
                };
                model.Add(parkingFloor);
            });

            if (TempData["NoLotMessage"] != null)
                ViewBag.NoLotMessage = TempData["NoLotMessage"].ToString();

            return View(model);
        }        

        [HttpGet]
        public ActionResult AddParkingFloor()
        {
            ParkingFloorViewModel model = new ParkingFloorViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddParkingFloor(ParkingFloorViewModel model)
        {
            var parkingLot = parkingLotService.Get(model.ParkingLotId);

            if (parkingLot != null)
            {
                ParkingFloor parkingFloorEntity = new ParkingFloor
                {
                    NumberOfSpots = model.NumberOfSpots,
                    AddedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    ParkingLotId = model.ParkingLotId
                };

                List<ParkingSpot> parkingSpots = new List<ParkingSpot>();

                for (int j = 0; j < model.NumberOfSpots; j++)
                {
                    ParkingSpot parkingSpot = new ParkingSpot
                    {
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow,
                    };

                    parkingFloorEntity.ParkingSpots = parkingSpots;
                    parkingSpots.Add(parkingSpot);
                }

                parkingFloorEntity.ParkingSpots = parkingSpots;
                parkingFloorService.Insert(parkingFloorEntity);
                if (parkingFloorEntity.Id > 0)
                {
                    return RedirectToAction("index");
                }
                return View(model);
            }
            else
            {
                TempData["NoLotMessage"] = "The Lot number does not exist";
                return RedirectToAction("Index");
            }            
        }

        [HttpGet]
        public ActionResult DeleteParkingFloor(int id)
        {
            ParkingFloor parkingFloor = parkingFloorService.Get(id);
            string name = $"{parkingFloor.Id}";
            return View("DeleteParkingFloor", name);
        }


        [HttpPost]
        public ActionResult DeleteParkingFloor(int id, IFormCollection form)
        {
            parkingFloorService.Delete(id);
            return RedirectToAction("Index");
        }

    
    }
}

