namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival {  get; set; } 
         public float EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public Plane Plane { get; set; }
        public ICollection<Passenger> Passengers { get; set; }

        public override string ToString()
        {
            return ("FlightId : " + this.FlightId+" Destination "+ this.Destination + " estimated duration "+ this.EstimatedDuration+  " \n");
        }

    }
}
