namespace lab6;
class Program
{
    static void Main(string[] args)
    {
        var person0 = new Person()
        {
            id = 0,
            FirstName = "Siyu",
            LastName = "Liu",
            Birthday = new DateTime(1996, 6, 13)
        };
        var person1 = new Person()
        {
            id = 1,
            FirstName = "Siyu",
            LastName = "Liu",
            Birthday = new DateTime(1996, 6, 13)
        };
        var person2 = new Person()
        {
            id = 2,
            FirstName = "Bruce",
            LastName = "Wayne",
            Birthday = new DateTime(2000, 1, 1)
        };
        person0.CalculateAge();
        person1.CalculateAge();
        person2.CalculateAge();
        person0.Compare(person1).Compare(person2);
    }
}
