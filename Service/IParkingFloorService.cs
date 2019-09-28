using CarParkingApp.Data;
using System.Collections.Generic;

namespace CarParkingApp.Service
{
    public interface IParkingFloorService
    {
        IEnumerable<ParkingFloor> GetAll();

        ParkingFloor Get(long id);

        void Insert(ParkingFloor parkingFloor);

        void Update(ParkingFloor parkingFloor);

        void Delete(long id);

    }
}
