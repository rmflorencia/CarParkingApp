using CarParkingApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkingApp.Service
{
    public interface IParkingLotService
    {
        IEnumerable<ParkingLot> GetAll();

        ParkingLot Get(long id);

        void Insert(ParkingLot parkingLot);

        void Update(ParkingLot parkingLot);

        void Delete(long id);
    }
}
