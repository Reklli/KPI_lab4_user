using System;
using System.Collections.Generic;

namespace ParkingSystemApp
{
    public class ParkingSystem
    {
        private Database _db;

        public ParkingSystem(Database db) => _db = db;

        public List<ParkingSpot> GenerateParkingMap() => _db.GetAvailableSpots();

        public bool CheckSpotAvailability(ParkingSpot spot) => spot.IsAvailable();

        public Reservation? ReserveSpot(ParkingSpot spot, Driver driver, int hours)
        {
            if (CheckSpotAvailability(spot))
            {
                double totalAmount = spot.HourlyRate * hours;

                var payment = new Payment(new Random().Next(1000, 9999), (float)totalAmount);
                var res = new Reservation(new Random().Next(1, 500), driver, spot, payment);

                _db.SaveReservation(res);
                spot.Status = SpotStatus.RESERVED;
                return res;
            }
            return null;
        }

        public void ReleaseSpot(Driver driver)
        {
            if (driver.CurrentReservation != null)
            {
                var spot = driver.CurrentReservation.Spot;

                spot.Status = SpotStatus.FREE;
                _db.UpdateSpotStatus(spot.SpotId, SpotStatus.FREE);

                driver.CurrentReservation = null;

                Console.WriteLine($"[System] Reservation cleared for driver {driver.LicensePlate}.");
            }
        }
    }
}