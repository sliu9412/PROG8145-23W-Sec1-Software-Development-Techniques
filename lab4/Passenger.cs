
namespace lab4
{
    public class PassengerInfo
    {
        public string? full_name;
        public string? phone_number;
        public int bag_count;
        public double bag_weight;
        public double average_weight
        {
            get
            {
                return bag_weight / bag_count;
            }
        }
        public static bool checkPhoneNumber(string input_phone_number)
        {
            if (input_phone_number.Length == 13)
            {
                int i = 0;
                foreach (char item in input_phone_number)
                {
                    if (Char.IsLetter(item))
                    {
                        return false;
                    }
                    else if (i != 0 && i != 4 && i != 8 && !Char.IsDigit(item))
                    {
                        return false;
                    }
                    else if (i == 0 && item != '(')
                    {
                        return false;
                    }
                    else if (i == 4 && item != ')')
                    {
                        return false;
                    }
                    else if (i == 8 && item != '-')
                    {
                        return false;
                    }
                    i++;
                }
                return true;
            }
            return false;
        }
    }
}