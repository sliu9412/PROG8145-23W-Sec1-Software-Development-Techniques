namespace program2;
class ParkingCalculator
{
    public bool is_member;
    public double hourly_rate;
    public int parking_hour;

    // Menu part, generate the menu of the questions
    public void Menu()
    {
        if (RequireParkingInfo())
        {
            FinalOutput();
        }
    }

    // print the receipt of the parking
    public void FinalOutput() {
        string have_member_card = is_member ? "Yes" : "No";
        double total_charge = CalculateCharge(hourly_rate, parking_hour);
        Console.WriteLine($"\n-- Receipt --\nMembership Card: {have_member_card}\nHourly Rate: ${hourly_rate}\nNumber of Hours Charged: {parking_hour}\nTotal Charge: {total_charge}");
    }

    // Calculate parking charge, according to the requirment, inputing hourly_rate and parking_hour, and return total charge
    public double CalculateCharge(double hourly_rate, int parking_hour)
    {
        double total_charge = hourly_rate * parking_hour;
        return total_charge >= 120 ? 120 : total_charge;
    }

    // Get parking details
    public bool RequireParkingInfo()
    {
        while (true)
        {
            Console.WriteLine("How many hours are you parking the car?");
            var hour_validator = Validors.DoubleValidator(Console.ReadLine(), ">");
            if (hour_validator.valid)
            {
                parking_hour = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(hour_validator.value)));
                // ensure the user is a member or not
                while (true)
                {
                    Console.WriteLine("Do you have a member card? Y/N");
                    var member_validator = Validors.YesNoValidator(Console.ReadLine());
                    if (member_validator == "Y")
                    {
                        is_member = true;
                        hourly_rate = 0.75;
                        return true;
                    }
                    else if (member_validator == "N")
                    {
                        is_member = false;
                        hourly_rate = parking_hour > 7 ? 1.25 : 1.5;
                        return true;
                    }
                    else
                    {
                        if (RetryHandler("Please input Y or N."))
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                if (RetryHandler("Please input a valid number of parking hours."))
                {
                    return false;
                }
            }
        }
    }

    // 
    private static bool RetryHandler(string message = "Please enter a valid value!")
    {
        Console.WriteLine($"{message} Press Q to exit or any other key to retry.");
        var retry_validator = Validors.InputValidator(Console.ReadLine());
        if (retry_validator.valid && (retry_validator.value.ToLower() == "q" || retry_validator.value.ToLower() == "quit"))
        {
            return true;
        }
        return false;
    }
}
