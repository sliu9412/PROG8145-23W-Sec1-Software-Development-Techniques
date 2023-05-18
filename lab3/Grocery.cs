namespace week3
{
    public class Grocery
    {
        public string? good;
        public int count;
        public decimal weight;
        private bool output_cheaked = false;

        private decimal CalculateAverageWeight()
        {
            return weight / count;
        }

        public void FinalOutput()
        {
            if (output_cheaked == true)
            {
                Console.WriteLine($"{count} {good} with an average weight of {CalculateAverageWeight()} lbs.");
            }
        }

        public bool GetGoodInfo()
        {

            Console.WriteLine("Please enter a fruit or vegetable:");
            string? input_good = Console.ReadLine();
            if (Grocery.InputValidator(input_good, "good name"))
            {
                good = input_good;
            }
            else
            {
                return false;
            }

            // Count and weight should not be string and greater than 0
            Console.WriteLine($"How many {good} did you purchase:");
            string? input_count = Console.ReadLine();
            if (Grocery.InputValidator(input_count, "good count"))
            {
                try
                {
                    count = Convert.ToInt32(input_count);
                    if (count <= 0)
                    {
                        throw new ArgumentException("Sorry, count must be greater than zero");
                    }
                }
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is OverflowException)
                    {
                        Console.WriteLine("Sorry, please enter a right number of count");
                    }
                    else if (ex is ArgumentException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return false;
                }
            }

            // Count and weight should not be string and greater than 0
            Console.WriteLine($"How much did the {good} weigh, in total:");
            string? input_weight = Console.ReadLine();
            if (Grocery.InputValidator(input_weight, "weight"))
            {
                try
                {
                    weight = Convert.ToDecimal(input_weight);
                    if (weight <= 0)
                    {
                        throw new ArgumentException("Sorry, weight must be greater than zero");
                    }
                }
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is OverflowException)
                    {
                        Console.WriteLine("Sorry, please enter a right number of weight");
                    }
                    else if (ex is ArgumentException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return false;
                }
            }

            output_cheaked = true;
            return true;
        }

        public static bool InputValidator(string? input_string, string item_name)
        {
            string error_message = "Sorry, please don't input empty {0}";
            if (String.IsNullOrWhiteSpace(input_string) || String.IsNullOrEmpty(input_string))
            {
                Console.WriteLine(string.Format(error_message, item_name));
                return false;
            }
            return true;
        }
    }
}