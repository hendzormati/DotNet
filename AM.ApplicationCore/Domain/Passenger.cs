using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int passengerId { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        public FullName fullName { get; set; }

        [Key]
        [StringLength(7)]
        public string? PassportNumber { get; set; }

        [RegularExpression(@"^[0-9]{8}$")]
        public string? TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return ("FirstName : " + this.fullName.FirstName+"\nLastName : "+ this.fullName.LastName +"\nEmailAddress : "+ this.EmailAddress  + " \n");
        }
        // polymorphisme 
        public bool CheckProfile(String? fn,string? ln)
        {
            return (this.fullName.FirstName.Equals(fn) && this.fullName.LastName.Equals(ln));  
        }

        public bool CheckProfile(String? fn, string ln,string? email)
        {
            return (this.fullName.FirstName.Equals(fn) && this.fullName.LastName.Equals(ln) && this.EmailAddress.Equals(email));
        }
        public bool CheckProfileComplete(String? fn, string? ln, string? email =null)
        {
            return (this.fullName.FirstName.Equals(fn) && this.fullName.LastName.Equals(ln) &&( this.EmailAddress.Equals(email) || email==null));
        }
        // polymorphisme + héritage : virtual
        public virtual void PassengerType()
        {
            Console.WriteLine( " i am a passenger \n");
        }

    }
}
