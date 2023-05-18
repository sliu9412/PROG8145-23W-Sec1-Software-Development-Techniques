namespace assignment2;

public enum Gender {
    Unknown,
    Male,
    Female
}

public class Person
{
    public string name = "";
    public string phone_number = "";
    public DateTime birth_date = DateTime.Now;
    public Gender gender = Gender.Unknown;
}
