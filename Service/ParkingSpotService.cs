using CarParkingApp.Data;
using CarParkingApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkingApp.Service
{
    public class ParkingSpotService : IParkingSpotService
    {
        private IRepository<ParkingSpot> parkingSpotRepository;
        private IVehicleService vehicleService;

        public ParkingSpotService(IRepository<ParkingSpot> parkingSpotRepository, IVehicleService vehicleService)
        {
            this.parkingSpotRepository = parkingSpotRepository;
            this.vehicleService = vehicleService;
        }

        public IEnumerable<ParkingSpot> GetParkingSpots()
        {
            return parkingSpotRepository.GetAll();
        }

        public ParkingSpot GetParkingSpot(long id)
        {
            return parkingSpotRepository.Get(id);
        }

        public void InsertParkingSpot(ParkingSpot parkingSpot)
        {
            parkingSpotRepository.Insert(parkingSpot);
        }

        public void UpdateParkingSpot(ParkingSpot parkingSpot)
        {
            parkingSpotRepository.Update(parkingSpot);
        }

        public void DeleteParkingSpot(long id)
        {
            ParkingSpot parkingSpot = parkingSpotRepository.Get(id);
            parkingSpotRepository.Remove(parkingSpot);
            parkingSpotRepository.SaveChanges();
        }

        public IEnumerable<ParkingSpot> GetParkingSpotsFromFloor(int floorId)
        {
            return GetParkingSpots().Where(s => s.ParkingFloorId == floorId);
        }

        public bool ParkingSpotsAvailable()
        {
            return GetParkingSpots().Any(s => s.Vehicle == null);
        }

        public ParkingSpot GetNextFreeSpace()
        {            
            return GetParkingSpots().FirstOrDefault(s => s.Vehicle == null);                      
        }

        public void ParkVehicle(Vehicle vehicle, ParkingSpot parkingSpot)
        {  
            vehicleService.Insert(vehicle);
            parkingSpot.Vehicle = vehicle;
            UpdateParkingSpot(parkingSpot);          
        }
    }
}
