using CarParkingApp.Data;
using System.Collections.Generic;

namespace CarParkingApp.Service
{
    public interface IParkingSpotService
    {
        IEnumerable<ParkingSpot> GetParkingSpots();

        ParkingSpot GetParkingSpot(long id);

        void InsertParkingSpot(ParkingSpot parkingSpot);

        void UpdateParkingSpot(ParkingSpot parkingSpot);

        void DeleteParkingSpot(long id);

        IEnumerable<ParkingSpot> GetParkingSpotsFromFloor(int floorId);

        ParkingSpot GetNextFreeSpace();

        void ParkVehicle(Vehicle vehicle, ParkingSpot parkingSpot);

        bool ParkingSpotsAvailable();
    }
}
