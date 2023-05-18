namespace assignment2;

public class Handlers
{
    protected static bool RetryHandler(string message = "Please enter a valid value!")
    {
        Console.WriteLine($"{message} Press Q to exit or any other key to retry.");
        var retry_validator = Validors.InputValidator(Console.ReadLine());
        if (retry_validator.valid && (retry_validator.value.ToLower() == "q" || retry_validator.value.ToLower() == "quit"))
        {
            return true;
        }
        return false;
    }
    protected static void PauseHandler() {
        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }
}
