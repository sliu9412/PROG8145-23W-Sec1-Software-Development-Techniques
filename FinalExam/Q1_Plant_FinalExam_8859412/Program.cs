// Siyu Liu 8859412
using System.Text.Json;
namespace Q1_Plant_FinalExam_8859412;
class Program
{
    static void Main(string[] args)
    {
        Program.ShowMenu();
    }

    public static void ShowMenu()
    {
        try { } catch { }
        var loop = true;
        var flower = new Flower();
        var tree = new Tree();
        var flower_json_path = Path.Join(Directory.GetCurrentDirectory(), "flower.json");
        do
        {
            System.Console.WriteLine("1. Add Flower");
            System.Console.WriteLine("2. Add Tree");
            System.Console.WriteLine("3. View Flower and Tree");
            System.Console.WriteLine("4. Save Flower");
            System.Console.WriteLine("5. Load Flower");
            System.Console.WriteLine("6. Exit");
            var menu_selection = Program.InputValidtor();
            if (menu_selection.valid)
            {
                if (menu_selection.value == "1")
                {
                    var addFlower = Program.AddFlower();
                    if (addFlower.valid)
                    {
                        flower = addFlower.newFlower;
                        flower.unInitialized = true;
                        System.Console.WriteLine("Add flower successfully");
                    }
                    else
                    {
                        System.Console.WriteLine("Add flower failed");
                    }

                }
                else if (menu_selection.value == "2")
                {
                    var AddTree = Program.AddTree();
                    if (AddTree.valid)
                    {
                        tree = AddTree.newTree;
                        tree.unInitialized = true;
                        System.Console.WriteLine("Add tree successfully");
                    }
                    else
                    {
                        System.Console.WriteLine("Add tree failed");
                    }
                }
                else if (menu_selection.value == "3")
                {
                    Program.ViewPlants(flower, tree);
                }
                else if (menu_selection.value == "4")
                {
                    SaveFlower(flower, flower_json_path);
                }
                else if (menu_selection.value == "5")
                {
                    flower = LoadFlower(flower, flower_json_path);
                }
                else if (menu_selection.value == "6")
                {
                    loop = false;
                }
                else
                {
                    System.Console.WriteLine("Please select a right option");
                }
            }
            else
            {
                System.Console.WriteLine("Please select an option");
            }
        } while (loop);
    }
    public static Flower LoadFlower(Flower flower, string Json_path)
    {
        try
        {
            using (var f = new FileStream(Json_path, FileMode.Open, FileAccess.Read))
            {
                using (var fr = new StreamReader(f))
                {
                    var newFlower = JsonSerializer.Deserialize<Flower>(fr.ReadToEnd());
                    System.Console.WriteLine("Load flower successfully");
                    return newFlower!;
                }
            }
        }
        catch
        {
            System.Console.WriteLine("Load flower failed");
        }
        return flower;
    }

    public static void SaveFlower(Flower flower, string Json_path)
    {
        try
        {
            if (flower.unInitialized)
            {
                if (File.Exists(Json_path))
                {
                    File.Delete(Json_path);
                }
                using (var f = new FileStream(Json_path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (var fw = new StreamWriter(f))
                    {
                        fw.Write(flower.ToJson());
                        System.Console.WriteLine("Save flower successfully");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("There's no flower in the system");
            }
        }
        catch
        {
            System.Console.WriteLine("Save flower failed");
        }

    }

    public static void ViewPlants(Flower flower, Tree tree)
    {
        try { } catch { }
        System.Console.WriteLine(flower.ToString());
        System.Console.WriteLine(tree.ToString());
    }

    public static (bool valid, Flower newFlower) AddFlower()
    {
        var newFlower = new Flower();
        System.Console.WriteLine("1. What is flower's name?");
        var flowerName = Program.InputValidtor();
        if (!flowerName.valid)
        {
            return (false, newFlower);
        }
        System.Console.WriteLine("2. What is flower's type?");
        var flowerType = Program.InputValidtor();
        if (!flowerType.valid)
        {
            return (false, newFlower);
        }
        System.Console.WriteLine("3. What is flower's price");
        var flowerPrice = Program.InputValidtor();
        if (!flowerPrice.valid)
        {
            return (false, newFlower);
        }
        System.Console.WriteLine("4. What is flower's color?");
        var flowerColor = Program.InputValidtor();
        if (!flowerColor.valid)
        {
            return (false, newFlower);
        }
        System.Console.WriteLine("5. What is flower's scent?");
        var flowerSent = Program.InputValidtor();
        if (!flowerSent.valid)
        {
            return (false, newFlower);
        }
        System.Console.WriteLine("6. How many flowers are available?");
        var flowerQuantity = Program.InputValidtor();
        if (!flowerQuantity.valid)
        {
            return (false, newFlower);
        }
        try
        {
            newFlower.PlantName = flowerName.value;
            newFlower.PlantType = flowerType.value;
            newFlower.Price = Double.Parse(flowerPrice.value);
            newFlower.FlowerColor = flowerColor.value;
            newFlower.Scent = flowerSent.value;
            newFlower.QuantityAvailable = Int32.Parse(flowerQuantity.value);
            return (true, newFlower);
        }
        catch
        {
            return (false, newFlower);
        }

    }

    public static (bool valid, Tree newTree) AddTree()
    {
        var newTree = new Tree();
        System.Console.WriteLine("1. What is tree's name?");
        var treeName = Program.InputValidtor();
        if (!treeName.valid)
        {
            return (false, newTree);
        }
        System.Console.WriteLine("2. What is tree's type?");
        var treeType = Program.InputValidtor();
        if (!treeType.valid)
        {
            return (false, newTree);
        }
        System.Console.WriteLine("3. What is tree's price");
        var treePrice = Program.InputValidtor();
        if (!treePrice.valid)
        {
            return (false, newTree);
        }
        System.Console.WriteLine("4. What is tree's height?");
        var treeHeight = Program.InputValidtor();
        if (!treeHeight.valid)
        {
            return (false, newTree);
        }
        System.Console.WriteLine("5. What is tree's CanopySpread?");
        var treeCanopySpread = Program.InputValidtor();
        if (!treeCanopySpread.valid)
        {
            return (false, newTree);
        }
        System.Console.WriteLine("6. How many trees are available?");
        var treeQuantity = Program.InputValidtor();
        if (!treeQuantity.valid)
        {
            return (false, newTree);
        }
        try
        {
            newTree.PlantName = treeName.value;
            newTree.PlantType = treeType.value;
            newTree.Price = Double.Parse(treePrice.value);
            newTree.TreeHeight = Double.Parse(treeHeight.value);
            newTree.CanopySpread = Double.Parse(treeCanopySpread.value);
            newTree.QuantityAvailable = Int32.Parse(treeQuantity.value);
            return (true, newTree);
        }
        catch
        {
            return (false, newTree);
        }

    }

    public static (bool valid, string value) InputValidtor()
    {
        try { } catch { }
        var InputString = Console.ReadLine();
        if (string.IsNullOrEmpty(InputString) || string.IsNullOrWhiteSpace(InputString))
        {
            return (false, InputString!);
        }
        return (true, InputString!);
    }
}
