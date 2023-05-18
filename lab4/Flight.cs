namespace lab4
{
    public class Flight
    {
        public List<PassengerInfo> passenget_list = new List<PassengerInfo>();
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to Siyu Liu's flight menu! select an option via number to continue:\n - 1. Add a new Passenger\n - 2. Display Passenger list\n - 3. Exit");
                var menu_validator = InputValidator(Console.ReadLine());
                if (menu_validator.Item1 && menu_validator.Item2 == "1")
                {
                    AddPassenger();
                }
                else if (menu_validator.Item1 && menu_validator.Item2 == "2")
                {
                    DisplayPassengers();
                }
                else if (menu_validator.Item1 && menu_validator.Item2 == "3")
                {
                    break;
                }
            }
        }

        public bool AddPassenger()
        {
            string passenger_name;
            string passenger_phone_number;
            double bag_weight = 0;
            int bag_count = 0;
            // obtain passenger's name
            while (true)
            {
                Console.WriteLine("What's the name of the new passenger?");
                var name_validator = InputValidator(Console.ReadLine());
                if (name_validator.Item1)
                {
                    passenger_name = name_validator.Item2;
                    break;
                }
                else
                {
                    if (!retryHandler("name"))
                    {
                        return false;
                    }
                }
            }
            // obtain passenger's phone number
            while (true)
            {
                Console.WriteLine("What's the phone number of the new passenger?");
                var phone_number_validator = InputValidator(Console.ReadLine());
                if (phone_number_validator.Item1 && PassengerInfo.checkPhoneNumber(phone_number_validator.Item2))
                {
                    passenger_phone_number = phone_number_validator.Item2;
                    break;
                }
                else
                {
                    if (!retryHandler("phone number"))
                    {
                        return false;
                    }
                }
            }
            // obtain passenger's bag weight
            while (true)
            {
                Console.WriteLine("What's the bag weight of the new passenger?");
                var bag_weight_validator = InputValidator(Console.ReadLine());
                if (bag_weight_validator.Item1 && double.TryParse(bag_weight_validator.Item2, out bag_weight) && bag_weight >= 0)
                {
                    break;
                }
                else
                {
                    if (!retryHandler("bag weight"))
                    {
                        return false;
                    }
                }
            }
            // obtain passenger's bag count
            while (true)
            {
                Console.WriteLine("How many bags does the passenger have?");
                var bag_count_validator = InputValidator(Console.ReadLine());
                if (bag_count_validator.Item1 && int.TryParse(bag_count_validator.Item2, out bag_count) && bag_count >= 0)
                {
                    break;
                }
                else
                {
                    if (!retryHandler("bag count"))
                    {
                        return false;
                    }
                }
            }
            // if the data is valid, add to list then return true
            passenget_list.Add(new PassengerInfo()
            {
                full_name = passenger_name,
                phone_number = passenger_phone_number,
                bag_count = bag_count,
                bag_weight = bag_weight
            });
            Console.WriteLine("\nAdd passenger successfully!");
            return true;
        }

        public void DisplayPassengers()
        {
            // Harry Scanlan, (555) 555-5555, 2 Bags, 50.6 Average Weight
            Console.WriteLine("\nThe passenger list is as follows:");
            foreach (var passenger in passenget_list)
            {
                Console.WriteLine($"{passenger.full_name}, {passenger.phone_number}, {passenger.bag_count} bags, {passenger.average_weight} Average Weight");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        // Check whether the keyboard input string is empty
        private static (bool, string) InputValidator(string? str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                return (false, "");
            }
            return (true, str);
        }

        // let user retry or return menu
        private static bool retryHandler(string retry_field)
        {
            Console.WriteLine($"The format of {retry_field} is invalid. Press Q to menu or any other key to retry.");
            var retry_validator = InputValidator(Console.ReadLine());
            if (retry_validator.Item1 && retry_validator.Item2.ToLower() == "q")
            {
                return false;
            }
            return true;
        }
    }
}