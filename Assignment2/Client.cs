namespace assignment2;
public enum ClientType
    {
        Home = 1,
        Office = 2,
        Industrial = 3
    }
public class Client: Person
{
    public string client_number = "";
    public ClientType client_type;
}
