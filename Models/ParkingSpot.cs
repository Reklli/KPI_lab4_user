namespace ParkingSystemApp
{
    public class ParkingSpot
    {
        public string SpotId { get; set; }
        public string Location { get; set; }
        public SpotStatus Status { get; set; }
        public double HourlyRate { get; set; }
        public double Distance { get; set; }
        public double Length { get; set; } 

        public ParkingSpot(string id, string location, double length, double distance, double rate)
        {
            SpotId = id;
            Location = location;
            Length = length;
            Distance = distance;
            HourlyRate = rate;
            Status = SpotStatus.FREE;
        }

        public bool IsAvailable() => Status == SpotStatus.FREE;
    }
}