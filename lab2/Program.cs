namespace week2assignment;
enum Luggages
{
    Bag1,
    Bag2,
    ComputerBag,
    Handbag
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            decimal total_weight = 0;
            Console.WriteLine("Where I flow from?");
            string place = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(place) && string.IsNullOrWhiteSpace(place))
            {
                System.Console.WriteLine("I need to input a place or I have to do it again.\n");
            }
            else
            {
                var luggages = Enum.GetValues(typeof(Luggages));
                foreach (var luggage in luggages)
                {
                    while (true)
                    {
                        System.Console.WriteLine("\nDo I have {0}? y/n", luggage);
                        string is_luggage = Console.ReadLine();
                        if (is_luggage == "y" || is_luggage == "Y")
                        {
                            System.Console.WriteLine("\nThe weight(KG) of this luggage is:");
                            try {
                                string luggage_weight_str = Console.ReadLine();
                                decimal luggage_weight = decimal.Parse(luggage_weight_str);
                                if (luggage_weight > 0) {
                                    total_weight += luggage_weight;
                                    break;
                                } else {
                                    System.Console.WriteLine("\nI need to input my luggage weight or I have to do it again");
                                    continue;
                                }
                            } catch {
                                System.Console.WriteLine("\nI need to input my luggage weight or I have to do it again");
                                continue;
                            }
                            
                        } else if (is_luggage == "n" || is_luggage == "N") {
                            break;
                        } else {
                            System.Console.WriteLine("\nI must ensure whether I have {0}, or I have to check it again", luggage);
                            continue;
                        }
                    }
                }
                System.Console.WriteLine("\nI flew from {0} with {1}KG of luggage.", place, total_weight);
                break;
            }
        }
    }
}
