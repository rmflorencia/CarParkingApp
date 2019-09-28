using CarParkingApp.Data;
using CarParkingApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkingApp.Service
{
    public class ParkingFloorService : IParkingFloorService
    {
        private IRepository<ParkingFloor> parkingFloorRepository;
        private IParkingSpotService parkingSpotService;

        public ParkingFloorService(IRepository<ParkingFloor> parkingFloorRepository, IParkingSpotService parkingSpotService)
        {
            this.parkingFloorRepository = parkingFloorRepository;
            this.parkingSpotService = parkingSpotService;
        }

        public IEnumerable<ParkingFloor> GetAll()
        {
            return parkingFloorRepository.GetAll();
        }

        public ParkingFloor Get(long id)
        {
            return parkingFloorRepository.Get(id);
        }

        public void Insert(ParkingFloor parkingFloor)
        {
            parkingFloorRepository.Insert(parkingFloor);
        }

        public void Update(ParkingFloor parkingFloor)
        {
            parkingFloorRepository.Update(parkingFloor);
        }

        public void Delete(long id)
        {
            ParkingFloor parkingFloor = parkingFloorRepository.Get(id);
            parkingFloorRepository.Remove(parkingFloor);
            parkingFloorRepository.SaveChanges();
        }       

    }
}
