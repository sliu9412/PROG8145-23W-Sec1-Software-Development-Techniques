namespace lab5;
class Program
{
    static void Main(string[] args)
    {
        var sport = new Sport() {
            FirstName = "Mitoma",
            LastName = "Kaoru",
            Age = 25,
            Birthdate = new DateTime(1997, 5, 20),
            Country = "Japan",
            SportName = "Football",
            TeamName = "Brighton",
            PlayerNumber = 22
        };

        Console.WriteLine(sport.ToString());
    }
}
