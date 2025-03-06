using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

Plane plane1 = new Plane();
plane1.Capacity = 100;
plane1.ManufactureDate = DateTime.Now;
plane1.PlaneType= PlaneType.Boeing;
plane1.PlaneId = 1;
Console.WriteLine("Constructeur par défaut : "+ plane1.ToString());
Plane plane2 = new Plane(PlaneType.Airbus ,50,DateTime.Now);
Console.WriteLine("Constructeur paramétré : "+plane2.ToString());
Plane plane3 = new Plane { PlaneType = PlaneType.Airbus , ManufactureDate=DateTime.Now,Capacity=40, PlaneId=3};
Console.WriteLine("Initialisateur d'objet : "+plane3.ToString());
Plane plane4 = new Plane {  };
Console.WriteLine("Initialisateur d'objet vide : "+plane4.ToString());
// using initialisation from now no more constructeur 
Passenger passenger = new Passenger { fullName = new FullName { FirstName="hend", LastName="zormati" },EmailAddress="a@b.c", PassportNumber= "99gsfgdfgdf243" };

Console.WriteLine(passenger.ToString());
passenger.UpperFullName();
Console.WriteLine(passenger.ToString());
Console.WriteLine(passenger.CheckProfile("hend", "zormati")+"\n");
Console.WriteLine(passenger.CheckProfile("hend", "not")+"\n");
Console.WriteLine(passenger.CheckProfile("hend", "zormati","a@b.c")+"\n");
Console.WriteLine(" CHeck with mail : \n "+ passenger.CheckProfileComplete("hend", "zormati", "a@b.c")+"\n");
Console.WriteLine(" CHeck without mail : \n "+ passenger.CheckProfileComplete("hend", "zormati")+"\n");
Staff staff = new Staff { fullName = new FullName { FirstName="hend", LastName="zormati" }, Function="staff", PassportNumber= "98243" };
Traveller traveller = new Traveller { fullName = new FullName { FirstName="hend", LastName="zormati" }, Nationality ="tunisian", PassportNumber= "99253" };
Console.WriteLine(staff.ToString());
staff.PassengerType();
Console.WriteLine(traveller.ToString());
traveller.PassengerType();
// td 2 ;
FlightMethods fm = new FlightMethods { flights= TestData.listFlights };
string destination = "Madrid";
Console.WriteLine(" List Dates de la destination "+ destination+"  : \n ");
List<DateTime> list = new List<DateTime> { };
list=(List<DateTime>)fm.GetFlightDates(destination);
// using foreach loop
foreach (DateTime d in list)
{
    Console.WriteLine(" Flight Date : "+d);
}
fm.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine(" nb vol : "+fm.ProgrammedFlightNumber(new DateTime(2021,12 ,2)));
Console.WriteLine(" average duration : "+fm.DurationAverage(destination));
foreach( Flight f in fm.OrderedDurationFlights())
{
    Console.WriteLine(" Flight : "+f.ToString());
}
foreach ( Passenger p in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(" Senior Traveller : "+p.ToString());
}
fm.DestinationGroupedFlights();
// methode 2 
Console.WriteLine();
foreach (var g in fm.DestinationGroupedFlightsV2())
{
    Console.WriteLine(" Destination : "+g.Key);
    foreach (Flight f in g)
    {
        Console.WriteLine("Décollage : "+f.FlightDate.ToString());
    }
}
// calling the delegate
Console.WriteLine();
fm.FlightDetailsDel(TestData.BoingPlane);
Console.WriteLine(" average duration : "+fm.DurationAverageDel(destination));

// database linking
// outils -> gestionnaire de packages NuGet -> Console du Gestionnaire de package
// Add-Migration MigrationName
// Update-Database
AMContext context = new AMContext();
context.Flights.Add(TestData.flight2);
context.SaveChanges();

