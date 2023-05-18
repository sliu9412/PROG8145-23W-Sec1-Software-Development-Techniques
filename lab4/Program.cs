namespace lab4;
class Program
{
    static void Main(string[] args)
    {
        var flight = new Flight();
        flight.passenget_list.Add(new PassengerInfo()
        {
            full_name = "Siyu Liu",
            phone_number = "(604)690-4016",
            bag_count = 1,
            bag_weight = 8859412
        });
        flight.Menu();
    }
}
