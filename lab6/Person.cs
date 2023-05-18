namespace lab6;
public class Person : IPerson
{
    public int id;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime Birthday { get; set; }
    private DateTime _currentDate = DateTime.Now;

    public void CalculateAge(){
        var age = _currentDate.Year - Birthday.Year;
        Console.WriteLine($"Person{id}: {FirstName} {LastName} is {age} years old");
    }

    public Person Compare(Person obj)
    {
        if(obj.FirstName == FirstName && obj.LastName == LastName && obj.Birthday == Birthday) {
            Console.WriteLine($"The objects of Person{id} and Person{obj.id} are the same");
        }
        return this;
    }
}
