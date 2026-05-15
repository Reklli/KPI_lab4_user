using System;
using System.Linq;
using System.Threading;

namespace ParkingSystemApp
{
    public class MobileApp
    {
        private ParkingSystem _system;
        private Driver _currentDriver;

        public MobileApp(ParkingSystem system, Driver driver)
        {
            _system = system;
            _currentDriver = driver;
        }

        private void DrawHeader()
        {
            Console.Clear();
            Console.WriteLine("============================================================");
            Console.WriteLine("                P A R K I N G   S Y S T E M                 ");
            Console.WriteLine("============================================================");
            Console.Write(" STATUS: ");
            if (_currentDriver.CurrentReservation == null)
            {
                Console.WriteLine("[ No Active Reservation ]");
            }
            else
            {
                var res = _currentDriver.CurrentReservation;
                Console.WriteLine($"[{res.Spot.Status}] at {res.Spot.SpotId} ({res.Spot.Location}) | Card: **** 4421");
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        public void DisplayMainScreen()
        {
            DrawHeader();
            Console.WriteLine("  1. [ ] Search Parking Space (Filters)");

            if (_currentDriver.CurrentReservation != null)
            {
                var status = _currentDriver.CurrentReservation.Spot.Status;
                if (status == SpotStatus.RESERVED)
                {
                    Console.WriteLine("  2. [>] Drive to Spot");
                    Console.WriteLine("  5. [!] Cancel Reservation (Refund)");
                }
                else if (status == SpotStatus.OCCUPIED)
                {
                    Console.WriteLine("  3. [<] Leave Spot");
                }
            }

            Console.WriteLine("  4. [x] Exit");
            Console.WriteLine("------------------------------------------------------------");
            Console.Write("  Select option: ");
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                DisplayMainScreen();
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": StartReservationFlow(); break;
                    case "2": HandleDriveToSpot(); break;
                    case "3": HandleLeaveSpot(); break;
                    case "4": running = false; break;
                    case "5": CancelReservationFlow(); break;
                }
            }
        }

        private void StartReservationFlow()
        {
            if (_currentDriver.CurrentReservation != null)
            {
                ShowMessage("You already have an active reservation! Release it first.", true);
                return;
            }

            DrawHeader();
            Console.WriteLine(" [ FILTER OPTIONS ]");
            Console.Write(" > Enter minimum car length (meters): ");
            double.TryParse(Console.ReadLine()?.Replace('.', ','), out double minLength);

            Console.Write(" > Enter max distance to spot (km, 0 for any): ");
            double.TryParse(Console.ReadLine()?.Replace('.', ','), out double maxDist);

            var spots = _system.GenerateParkingMap()
                .Where(s => s.Length >= minLength && (maxDist <= 0 || s.Distance <= maxDist))
                .OrderBy(s => s.Distance)
                .ToList();

            DrawHeader();
            if (!spots.Any())
            {
                ShowMessage("No spots found matching your criteria.", true);
                return;
            }

            Console.WriteLine(" [ AVAILABLE SPOTS ]");
            Console.WriteLine(string.Format("  {0,-5} | {1,-10} | {2,-8} | {3,-8} | {4,-8}", "ID", "LOCATION", "LENGTH", "DIST", "PRICE/h"));
            Console.WriteLine("  ------+------------+----------+----------+---------");

            foreach (var s in spots)
            {
                Console.WriteLine(string.Format("  {0,-5} | {1,-10} | {2,-8} | {3,-8} | {4,-8}",
                    s.SpotId, s.Location, s.Length.ToString("0.0") + "m", s.Distance.ToString("0.0") + "km", s.HourlyRate + "$"));
            }

            Console.Write("\n > Enter Spot ID to reserve (or '0' to cancel): ");
            string? inputId = Console.ReadLine()?.ToUpper();

            if (string.IsNullOrWhiteSpace(inputId) || inputId == "0") return;

            var selectedSpot = spots.FirstOrDefault(s => s.SpotId == inputId);
            if (selectedSpot == null)
            {
                ShowMessage("Invalid Spot ID.", true);
                return;
            }

            Console.Write($" > Enter duration for {selectedSpot.SpotId} (hours): ");
            if (!int.TryParse(Console.ReadLine(), out int hours) || hours <= 0)
            {
                ShowMessage("Invalid duration.", true);
                return;
            }

            double totalCost = selectedSpot.HourlyRate * hours;

            Console.WriteLine("\n ----------------------------------------");
            Console.WriteLine("  CONFIRMATION");
            Console.WriteLine($"  Spot:      {selectedSpot.SpotId} ({selectedSpot.Location})");
            Console.WriteLine($"  Duration:  {hours} hour(s)");
            Console.WriteLine($"  Total:     {totalCost}$");
            Console.WriteLine("  Payment:   Card **** 4421");
            Console.WriteLine(" ----------------------------------------");
            Console.Write("  Confirm and pay? (Y/N): ");

            if (Console.ReadLine()?.ToUpper() == "Y")
            {
                Console.WriteLine("\n  Connecting to Payment Gateway...");
                Thread.Sleep(1200);

                var res = _system.ReserveSpot(selectedSpot, _currentDriver, hours);
                if (res != null && res.Payment.ProcessPayment() == PaymentStatus.CONFIRMED)
                {
                    res.Confirm();
                    _currentDriver.CurrentReservation = res;
                    ShowMessage($"Success! {totalCost}$ charged. Spot {selectedSpot.SpotId} is reserved.");
                }
            }
            else
            {
                ShowMessage("Reservation cancelled.");
            }
        }

        private void CancelReservationFlow()
        {
            if (_currentDriver.CurrentReservation == null) return;

            Console.WriteLine("\n  [!] Confirm cancellation? Funds will be refunded.");
            Console.Write("  Cancel reservation? (Y/N): ");

            if (Console.ReadLine()?.ToUpper() == "Y")
            {
                var spot = _currentDriver.CurrentReservation.Spot;
                spot.Status = SpotStatus.FREE;
                _currentDriver.CurrentReservation = null;

                Console.WriteLine("\n  Processing refund...");
                Thread.Sleep(1000);
                ShowMessage("Cancelled. Money refunded to Card **** 4421.");
            }
        }

        private void HandleDriveToSpot()
        {
            if (_currentDriver.CurrentReservation != null)
            {
                _currentDriver.CurrentReservation.Spot.Status = SpotStatus.OCCUPIED;
                Console.WriteLine("\n  Driving to spot...");
                Thread.Sleep(1000);
                _currentDriver.DriveToSpot();
                ShowMessage("You have arrived. Spot status: OCCUPIED.");
            }
        }

        private void HandleLeaveSpot()
        {
            if (_currentDriver.CurrentReservation != null)
            {
                _system.ReleaseSpot(_currentDriver);
                _currentDriver.LeaveSpot();
                ShowMessage("Spot is now FREE. Thank you!");
            }
        }

        private void ShowMessage(string m, bool e = false)
        {
            Console.WriteLine($"\n  {(e ? "![ERROR]" : "i")} {m}");
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }
    }
}