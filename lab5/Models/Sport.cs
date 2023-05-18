namespace lab5;
public class Sport: Person
{
    public string? SportName;
    public string? TeamName;
    public int PlayerNumber;

    public override string ToString()
    {      
        return $"FirstName: {FirstName}\nLastName: {LastName}\nAge: {Age}\nBirthdate: {Birthdate.ToString("yyyy/MM/dd")}\nCountry: {Country}\nSportName: {SportName}\nTeamName: {TeamName}\nPlayerNumber: {PlayerNumber}";
    }
}
