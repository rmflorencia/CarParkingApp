using CarParkingApp.Data;
using CarParkingApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkingApp.Service
{
    public class VehicleService : IVehicleService
    {
        private IRepository<Vehicle> VehicleRepository;

        public VehicleService(IRepository<Vehicle> VehicleRepository)
        {
            this.VehicleRepository = VehicleRepository;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return VehicleRepository.GetAll();
        }

        public Vehicle Get(long id)
        {
            return VehicleRepository.Get(id);
        }

        public void Insert(Vehicle Vehicle)
        {
            VehicleRepository.Insert(Vehicle);
        }

        public void Update(Vehicle Vehicle)
        {
            VehicleRepository.Update(Vehicle);
        }

        public void Delete(long id)
        {
            Vehicle Vehicle = VehicleRepository.Get(id);
            VehicleRepository.Remove(Vehicle);
            VehicleRepository.SaveChanges();
        }
    }
}
