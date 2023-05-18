namespace lab6;

interface IComparable
{
    Person Compare(Person obj);
}

interface IPerson: IComparable
{
    string? FirstName { get; set; }
    string? LastName { get; set; }
    DateTime Birthday { get; set; }
    void CalculateAge();
}