namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int passengerId { get; set; }
        public DateTime BirthDate { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PassportNumber { get; set; }
        public string? TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return ("FirstName : " + this.FirstName+"\nLastName : "+ this.LastName +"\nEmailAddress : "+ this.EmailAddress  + " \n");
        }
        // polymorphisme 
        public bool CheckProfile(String? fn,string? ln)
        {
            return (this.FirstName.Equals(fn) && this.LastName.Equals(ln));  
        }

        public bool CheckProfile(String? fn, string ln,string? email)
        {
            return (this.FirstName.Equals(fn) && this.LastName.Equals(ln) && this.EmailAddress.Equals(email));
        }
        public bool CheckProfileComplete(String? fn, string? ln, string? email =null)
        {
            return (this.FirstName.Equals(fn) && this.LastName.Equals(ln) &&( this.EmailAddress.Equals(email) || email==null));
        }
        // polymorphisme + héritage : virtual
        public virtual void PassengerType()
        {
            Console.WriteLine( " i am a passenger \n");
        }

    }
}
