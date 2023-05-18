// Siyu Liu 8859412
using System.Text.Json;
public class Flower : Plant
{
    public string? FlowerColor { get; set; }
    public string? Scent { get; set; }

    public override string ToString()
    {
        try { } catch { }
        if (this.unInitialized)
        {
            var flowerObjectString = "Flower:\n";
            flowerObjectString += $"Flower Name: {this.PlantName} \n";
            flowerObjectString += $"Flower Type: {this.PlantType} \n";
            flowerObjectString += $"Flower Price: {this.Price} \n";
            flowerObjectString += $"Flower Color: {this.FlowerColor} \n";
            flowerObjectString += $"Flower Scent: {this.Scent} \n";
            flowerObjectString += $"Avaliable Quantity: {this.QuantityAvailable} \n";
            return flowerObjectString;
        }
        return "There's no Flower in the system";
    }

    public string ToJson()
    {
        try
        {
            return JsonSerializer.Serialize(this);
        }
        catch
        {
            System.Console.WriteLine("Serilize object failed");
            return "";
        }
    }
}