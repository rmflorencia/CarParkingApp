using System;
using System.Collections.Generic;
using System.Linq;
using CarParkingApp.Data;
using CarParkingApp.Repository;
using Repository;

namespace CarParkingApp.Service
{
    public class ParkingLotService : IParkingLotService
    {
        private IRepository<ParkingLot> parkingLotRepository;

        public ParkingLotService(IRepository<ParkingLot> parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }

        public IEnumerable<ParkingLot> GetAll()
        {            
            return parkingLotRepository.GetAll();
        }

        public ParkingLot Get(long id)
        {
            return parkingLotRepository.Get(id);
        }

        public void Insert(ParkingLot parkingLot)
        {
            parkingLotRepository.Insert(parkingLot);
        }

        public void Update(ParkingLot parkingLot)
        {
            parkingLotRepository.Update(parkingLot);
        }

        public void Delete(long id)
        {
            ParkingLot parkingLot = parkingLotRepository.Get(id);
            parkingLotRepository.Remove(parkingLot);
            parkingLotRepository.SaveChanges();
        }             

    }
}
