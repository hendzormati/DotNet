namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        public IList<DateTime> GetFlightDates(string destination);
    }
}
