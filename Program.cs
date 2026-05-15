namespace ParkingSystemApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();

            db.ParkingSpots.Add(new ParkingSpot("A01", "Sector A", 6.2, 14.8, 65));
            db.ParkingSpots.Add(new ParkingSpot("A02", "Sector A", 6.6, 5.2, 43));
            db.ParkingSpots.Add(new ParkingSpot("A03", "Sector A", 4.2, 8.3, 44));
            db.ParkingSpots.Add(new ParkingSpot("A04", "Sector A", 5.5, 0.1, 73));
            db.ParkingSpots.Add(new ParkingSpot("A05", "Sector A", 4.5, 9.0, 64));
            db.ParkingSpots.Add(new ParkingSpot("A06", "Sector A", 5.5, 12.1, 55));
            db.ParkingSpots.Add(new ParkingSpot("A07", "Sector A", 4.3, 11.8, 77));
            db.ParkingSpots.Add(new ParkingSpot("A08", "Sector A", 5.2, 0.2, 33));
            db.ParkingSpots.Add(new ParkingSpot("A09", "Sector A", 6.7, 5.8, 75));
            db.ParkingSpots.Add(new ParkingSpot("A10", "Sector A", 4.2, 0.4, 77));
            db.ParkingSpots.Add(new ParkingSpot("B11", "Sector B", 4.4, 13.6, 55));
            db.ParkingSpots.Add(new ParkingSpot("B12", "Sector B", 5.2, 11.7, 48));
            db.ParkingSpots.Add(new ParkingSpot("B13", "Sector B", 6.0, 3.0, 48));
            db.ParkingSpots.Add(new ParkingSpot("B14", "Sector B", 6.1, 0.4, 44));
            db.ParkingSpots.Add(new ParkingSpot("B15", "Sector B", 6.3, 1.3, 68));
            db.ParkingSpots.Add(new ParkingSpot("B16", "Sector B", 5.7, 1.9, 74));
            db.ParkingSpots.Add(new ParkingSpot("B17", "Sector B", 5.7, 11.2, 48));
            db.ParkingSpots.Add(new ParkingSpot("B18", "Sector B", 5.1, 12.5, 69));
            db.ParkingSpots.Add(new ParkingSpot("B19", "Sector B", 5.8, 3.0, 45));
            db.ParkingSpots.Add(new ParkingSpot("B20", "Sector B", 6.5, 8.7, 54));
            db.ParkingSpots.Add(new ParkingSpot("C21", "Sector C", 5.6, 11.6, 67));
            db.ParkingSpots.Add(new ParkingSpot("C22", "Sector C", 5.7, 14.3, 80));
            db.ParkingSpots.Add(new ParkingSpot("C23", "Sector C", 6.3, 9.7, 74));
            db.ParkingSpots.Add(new ParkingSpot("C24", "Sector C", 4.8, 9.7, 60));
            db.ParkingSpots.Add(new ParkingSpot("C25", "Sector C", 4.7, 5.3, 42));
            db.ParkingSpots.Add(new ParkingSpot("C26", "Sector C", 4.1, 4.1, 39));
            db.ParkingSpots.Add(new ParkingSpot("C27", "Sector C", 6.3, 9.7, 75));
            db.ParkingSpots.Add(new ParkingSpot("C28", "Sector C", 5.6, 11.5, 68));
            db.ParkingSpots.Add(new ParkingSpot("C29", "Sector C", 6.3, 2.9, 40));
            db.ParkingSpots.Add(new ParkingSpot("C30", "Sector C", 5.5, 1.0, 70));
            db.ParkingSpots.Add(new ParkingSpot("D31", "Sector D", 5.9, 10.2, 49));
            db.ParkingSpots.Add(new ParkingSpot("D32", "Sector D", 4.1, 5.1, 75));
            db.ParkingSpots.Add(new ParkingSpot("D33", "Sector D", 4.4, 0.9, 79));
            db.ParkingSpots.Add(new ParkingSpot("D34", "Sector D", 6.4, 14.9, 62));
            db.ParkingSpots.Add(new ParkingSpot("D35", "Sector D", 6.7, 10.9, 70));
            db.ParkingSpots.Add(new ParkingSpot("D36", "Sector D", 4.8, 14.0, 39));
            db.ParkingSpots.Add(new ParkingSpot("D37", "Sector D", 6.8, 4.2, 59));
            db.ParkingSpots.Add(new ParkingSpot("D38", "Sector D", 6.7, 2.9, 55));
            db.ParkingSpots.Add(new ParkingSpot("D39", "Sector D", 4.9, 10.2, 37));
            db.ParkingSpots.Add(new ParkingSpot("D40", "Sector D", 4.9, 1.2, 45));
            db.ParkingSpots.Add(new ParkingSpot("E41", "Sector E", 5.6, 5.8, 50));
            db.ParkingSpots.Add(new ParkingSpot("E42", "Sector E", 6.6, 6.2, 58));
            db.ParkingSpots.Add(new ParkingSpot("E43", "Sector E", 4.3, 1.1, 66));
            db.ParkingSpots.Add(new ParkingSpot("E44", "Sector E", 6.0, 8.3, 40));
            db.ParkingSpots.Add(new ParkingSpot("E45", "Sector E", 6.7, 6.6, 41));
            db.ParkingSpots.Add(new ParkingSpot("E46", "Sector E", 5.6, 6.2, 49));
            db.ParkingSpots.Add(new ParkingSpot("E47", "Sector E", 5.4, 11.6, 50));
            db.ParkingSpots.Add(new ParkingSpot("E48", "Sector E", 4.5, 13.2, 39));
            db.ParkingSpots.Add(new ParkingSpot("E49", "Sector E", 5.5, 6.8, 33));
            db.ParkingSpots.Add(new ParkingSpot("E50", "Sector E", 6.0, 3.1, 34));

            ParkingSystem system = new ParkingSystem(db);
            Driver me = new Driver(1, "AA1234BB");

            MobileApp app = new MobileApp(system, me);
            app.Run();
        }
    }
}