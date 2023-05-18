namespace assignment2;

public class MakeReservation: Handlers
{
    private int client_id = 0;
    private DateTime reservation_date = DateTime.Now.AddDays(1);
    private int date_slot_number = 0;
    private Dictionary<int, string> slot_number_to_time = new Dictionary<int, string>();
    public List<Reservation> reservation_list = new List<Reservation>();
    public List<Service> service_list = new List<Service>();

    public MakeReservation()
    {
        slot_number_to_time.Add(0, "8a.m. -- 9a.m.");
        slot_number_to_time.Add(1, "9a.m. -- 10a.m.");
        slot_number_to_time.Add(2, "10a.m. -- 11a.m.");
        slot_number_to_time.Add(3, "11a.m. -- 12p.m.");
        slot_number_to_time.Add(4, "12p.m. -- 1p.m.");
        slot_number_to_time.Add(5, "1p.m. -- 2p.m.");
        slot_number_to_time.Add(6, "2p.m. -- 3p.m.");
        slot_number_to_time.Add(7, "3p.m. -- 4p.m.");
        service_list.Add(new Service() { service_name = "Light Cleaning", service_price = 299.99 });
        service_list.Add(new Service() { service_name = "Medium Cleaning", service_price = 329.99 });
        service_list.Add(new Service() { service_name = "Deep Cleaning", service_price = 439.99 });
    }

    public void Menu() {
        while (true) {
            Console.WriteLine("---------------------------------------\nWelcome to Siyu Liu's Carpet Cleaning Company!\n---------------------------------------\nSelect an option to do:\n - 1. Create a reservation\n - 2. List all Reservations\n - 3. Clear All Reservations\n - 4. Exit");
            var option_validator = Validors.IntegerRangeValidator(Console.ReadLine(), new List<int>{1, 2, 3, 4});
            if (option_validator.valid) {
                if (option_validator.value == 1) {
                    CreateReservation();
                    PauseHandler();
                } else if (option_validator.value == 2) {
                    ShowAllReservations();
                    PauseHandler();
                } else if (option_validator.value == 3) {
                    ClearReservationList();
                    PauseHandler();
                } else {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            } else {
                if (RetryHandler("Please enter 1 to 4 to choose what to do")) {
                    break;
                }
            }
        }
    }

    public bool CreateReservation()
    {
        while (true)
        {
            Console.WriteLine("What's your name?");
            var name_validator = Validors.InputValidator(Console.ReadLine());
            if (name_validator.valid)
            {
                while (true)
                {
                    Console.WriteLine("What's your phone number? (e.g. 604-690-4016)");
                    var phone_number_validator = Validors.PhoneNumberValidator(Console.ReadLine());
                    if (phone_number_validator.valid)
                    {
                        while (true)
                        {
                            Console.WriteLine("What kind of building you own?\n - 1.Home\n - 2.Office\n - 3.Industrial");
                            var build_type_validator = Validors.IntegerRangeValidator(Console.ReadLine(), new List<int> { 1, 2, 3 });
                            if (build_type_validator.valid)
                            {
                                var customized_service_list = new List<Service>();
                                customized_service_list = customized_service_list.Concat(service_list).ToList();
                                if (build_type_validator.value == 1)
                                {
                                    customized_service_list.Add(new Service() { service_name = "Carpet Drying", service_price = 49.01 });
                                }
                                else if (build_type_validator.value == 2)
                                {
                                    customized_service_list.Add(new Service() { service_name = "Carpet Repair", service_price = 69.02 });
                                }
                                else if (build_type_validator.value == 3)
                                {
                                    customized_service_list.Add(new Service() { service_name = "Carpet Replacement", service_price = 79.03 });
                                }
                                while (true)
                                {
                                    string service_selections = "What kind of service do you need?";
                                    int service_index = 1;
                                    foreach (var service in customized_service_list)
                                    {
                                        service_selections += $"\n - {service_index}. {service.service_name}: ${service.service_price}";
                                        service_index++;
                                    }
                                    Console.WriteLine(service_selections);
                                    var service_validator = Validors.IntegerRangeValidator(Console.ReadLine(), new List<int> { 1, 2, 3, 4 });
                                    if (service_validator.valid)
                                    {
                                        AddReservation(
                                            name_validator.value,
                                            phone_number_validator.value,
                                            build_type_validator.value,
                                            customized_service_list[service_validator.value - 1]
                                        );
                                        Console.WriteLine("Add new reservation successfully!");
                                        return true;
                                    }
                                    else
                                    {
                                        if (RetryHandler("Please enter 1 to 4 to choose your service type"))
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (RetryHandler("Please enter 1 to 3 to choose your building type"))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (RetryHandler("Phone number's format is incorrect"))
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                if (RetryHandler("Name should not be empty"))
                {
                    return false;
                }
            }
        }
    }

    public void AddReservation(string name, string phone_number, int client_type_number, Service service)
    {
        if (date_slot_number >= 8)
        {
            date_slot_number = 0;
            reservation_date = reservation_date.AddDays(1);
        }
        var new_reservation = new Reservation()
        {
            reservation_date = reservation_date.ToString("yyyy-MM-dd"),
            reservation_slot_num = date_slot_number,
            client = new Client()
            {
                client_number = (++client_id).ToString().PadLeft(10, '0'),
                name = name,
                phone_number = phone_number,
                client_type = (ClientType)client_type_number
            },
            service = service,
        };
        reservation_list.Add(new_reservation);
        date_slot_number++;
    }

    public void ClearReservationList()
    {
        reservation_list.Clear();
        Console.WriteLine("Clear Reservation List successfully!");
    }

    public void ShowAllReservations()
    {
        if (reservation_list.Count <= 0)
        {
            Console.WriteLine("There's no reservation in the system");
        }
        else
        {
            string output = "\n---------------------------------------\nReservations List\n---------------------------------------\n";
            double total_price = 0;
            foreach (Reservation reservation in reservation_list)
            {
                string changed_phone_number = "XXX" + reservation.client.phone_number.Substring(3);
                output += $"Client Number: {reservation.client.client_number}\nClient Name: {reservation.client.name}\nClient Phone Number: {changed_phone_number}\nClient Type: {reservation.client.client_type}\nService Type: {reservation.service.service_name}\nService Price: ${reservation.service.service_price}\nReservation Date: {reservation.reservation_date}\nReservation Time: {slot_number_to_time[reservation.reservation_slot_num]}\n---------------------------------------\n";
                total_price += reservation.service.service_price;
            }
            output += $"Total Price: ${total_price}\n---------------------------------------\n";
            Console.WriteLine(output);
        }
    }
    
}