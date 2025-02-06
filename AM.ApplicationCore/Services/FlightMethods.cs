using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> flights { get; set; }= new List<Flight>{};
        public IList<DateTime> GetFlightDates(string destination)
        {
            // generated automatically easier than a for loop
            /*** 
            return flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();
            ***/
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
        }

    }
}
