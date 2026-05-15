using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystemApp
{
    public class Database
    {
        public List<ParkingSpot> ParkingSpots { get; set; } = new List<ParkingSpot>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<ParkingSpot> GetAvailableSpots()
        {
            return ParkingSpots.Where(s => s.Status == SpotStatus.FREE).ToList();
        }

        public void SaveReservation(Reservation res)
        {
            Reservations.Add(res);
        }

        public void UpdateSpotStatus(string spotId, SpotStatus status)
        {
            var spot = ParkingSpots.FirstOrDefault(s => s.SpotId == spotId);
            if (spot != null)
            {
                spot.Status = status;
            }
        }

        public ParkingSpot? GetSpotById(string spotId)
        {
            return ParkingSpots.FirstOrDefault(s => s.SpotId == spotId);
        }
    }
}