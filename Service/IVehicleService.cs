using CarParkingApp.Data;
using System.Collections.Generic;

namespace CarParkingApp.Service
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetAll();

        Vehicle Get(long id);

        void Insert(Vehicle Vehicle);

        void Update(Vehicle Vehicle);

        void Delete(long id);

    }
}
