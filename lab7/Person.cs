public class Person : InterfacePerson
{
    public string? First_Name { get; set; }
    public string? Last_Name { get; set; }
    public DateTime Birthdate { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Province { get; set; }

    public string GenerateRow()
    {
        return $"{First_Name},{Last_Name},{Birthdate.ToString("MM/dd/yyyy")},{Address},{City},{Country},{Province}";
    }

    public bool LoadRow(string line)
    {
        try
        {
            var line_array = line.Split(",");
            var date_array = line_array[2].Split("/");
            First_Name = line_array[0];
            Last_Name = line_array[1];
            Birthdate = new DateTime(Convert.ToInt16(date_array[2]), Convert.ToInt16(date_array[0]), Convert.ToInt16(date_array[1]));
            Address = line_array[3];
            City = line_array[4];
            Country = line_array[5];
            Province = line_array[6];
            return true;
        }
        catch
        {
            return false;
        }

    }
}