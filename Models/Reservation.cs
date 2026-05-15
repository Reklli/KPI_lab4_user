namespace ParkingSystemApp
{
    public class Reservation
    {
        public int ReservationId { get; private set; }
        public Driver Driver { get; private set; }
        public ParkingSpot Spot { get; private set; }
        public Payment Payment { get; private set; }
        public ReservationStatus Status { get; set; }

        public Reservation(int id, Driver driver, ParkingSpot spot, Payment payment)
        {
            ReservationId = id;
            Driver = driver;
            Spot = spot;
            Payment = payment;
            Status = ReservationStatus.ACTIVE;
        }

        public void Confirm() => Status = ReservationStatus.COMPLETED;
    }
}