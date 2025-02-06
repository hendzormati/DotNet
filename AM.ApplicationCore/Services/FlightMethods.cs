using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> flights { get; set; }= new List<Flight>{};
        public IList<DateTime> GetFlightDates(string destination)
        {
           
            // using a for loop
           /***
            List<DateTime> dates = new List<DateTime> { };
            for(int i = 0; i < flights.Count; i++)
            {
                if (flights[i].Destination == destination)
                {
                    dates.Add(flights[i].FlightDate);
                }
            }
            return dates;
           ***/
            // using a foreach loop 
            List<DateTime> dates = new List<DateTime> { };
            foreach (Flight f in flights)
            {
                if (f.Destination == destination)
                {
                    dates.Add(f.FlightDate);
                }
            }
            return dates;
            // generated automatically easier than a for loop :LINQ
            /*** 
            return flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();
            ***/
        }
        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    flights = flights.Where(f => f.Destination == filterValue).ToList();
                    break;
                case "Departure":
                    flights = flights.Where(f => f.Departure == filterValue).ToList();
                    break;
                case "FlightDate":
                    flights = flights.Where(f => f.FlightDate == DateTime.Parse(filterValue)).ToList();
                    break;
                default:
                    break;
            }
            foreach(Flight f in flights)
            {
                Console.WriteLine(f.ToString());
            }
        }
        public void ShowFlightDetails(Plane plane)
        { 
                flights = flights.Where(f => f.Plane == plane).ToList();
            foreach (Flight f in flights)
            {
                Console.WriteLine(f.Destination + "    "+ f.FlightDate.ToString());
            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            return flights.Where(f => (f.FlightDate == startDate.AddDays(7))).Count();
        }
        public float DurationAverage(string destination)
        {
            return flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration).Average();
        }
        public IList<Flight> OrderedDurationFlights()
        {
            return flights.OrderByDescending(f => f.EstimatedDuration).ToList();
        }
    }
}

