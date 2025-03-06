using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boeing,Airbus}
    public class Plane
    {
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return ("PlaneId : " + this.PlaneId+" Capacity "+ this.Capacity + " \n");
        }

        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            this.Capacity = capacity;
            this.ManufactureDate = date;
           this.PlaneType = pt;
        }

        public Plane()
        {
        }
    }
}
