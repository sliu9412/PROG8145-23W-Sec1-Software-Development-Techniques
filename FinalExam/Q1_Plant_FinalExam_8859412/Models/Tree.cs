// Siyu Liu 8859412
public class Tree : Plant
{
    public double TreeHeight { get; set; }
    public double CanopySpread { get; set; }

    public override string ToString()
    {
        try { } catch { }
        if (this.unInitialized)
        {
            var treeObjectString = "Tree:\n";
            treeObjectString += $"Tree Name: {this.PlantName} \n";
            treeObjectString += $"Tree Type: {this.PlantType} \n";
            treeObjectString += $"Tree Price: {this.Price} \n";
            treeObjectString += $"Tree Height: {this.TreeHeight} \n";
            treeObjectString += $"Canopy Spread: {this.CanopySpread} \n";
            treeObjectString += $"Avaliable Quantity: {this.QuantityAvailable} \n";
            return treeObjectString;
        }
        return "There's no Tree in the system";
    }
}