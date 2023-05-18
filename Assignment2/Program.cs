namespace assignment2;
class Program
{
    static void Main(string[] args)
    {
        var make_reservation = new MakeReservation();
        make_reservation.AddReservation(
            name: "Siyu Liu",
            phone_number: "604-690-4016",
            client_type_number: 1,
            service: make_reservation.service_list[0]
        );
        make_reservation.AddReservation(
            name: "User2",
            phone_number: "980-028-0289",
            client_type_number: 2,
            service: make_reservation.service_list[1]
        );
        make_reservation.AddReservation(
            name: "User3",
            phone_number: "970-280-3786",
            client_type_number: 3,
            service: make_reservation.service_list[2]
        );
        make_reservation.Menu();
    }
}
