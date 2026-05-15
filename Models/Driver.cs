using System;

namespace ParkingSystemApp
{
    public class Driver
    {
        public int DriverId { get; private set; }
        public string CarPlate { get; private set; }

        public string LicensePlate => CarPlate;

        public string CarSize { get; set; } = "Medium";
        public bool IsCardLinked { get; set; } = true;
        public Reservation? CurrentReservation { get; set; }

        public Driver(int id, string plate)
        {
            DriverId = id;
            CarPlate = plate;
        }

        public void DriveToSpot() => Console.WriteLine($"Driver {CarPlate} is driving to the spot...");

        public void LeaveSpot() => Console.WriteLine($"Driver {CarPlate} left the spot.");
    }
}