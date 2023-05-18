namespace program1;
class Purchase
{
    public double total_price;
    public double tax_rate = 0.13;
    public int store_bag_count = 0;
    public bool has_scence_card = false;
    public double scene_card_discount = 0.1;
    public double scene_points = 0;

    // Add four objects to the list, then iterate the list
    public List<Product> product_list = new List<Product>() {
        new Product() {
            name = "Chillies",
            base_price = 1.29,
        },
        new Product() {
            name = "Tomatoes",
            base_price = 1.45,
        },
        new Product() {
            name = "Apple",
            base_price = 1.75,
        },
        new Product() {
            name = "Milk",
            base_price = 6.54,
            measurement = "bag"
        }
    };

    // Show Menu of the products, only it returns true, it will execute calculations step
    public void UserMenu()
    {
        if (AddProductInfo())
        {
            CalculatePrice();
        }
    }

    private bool AddProductInfo()
    {
        foreach (var product in product_list)
        {
            // ask every item in the list whether customer has purchase it.
            Console.WriteLine($"Did you purchase {product.name}? Y/N");
            string purchase_validator = Validors.YesNoValidator(Console.ReadLine());
            if (purchase_validator == "Y")
            {
                // milk doesn't need ask weight and store bag
                if (product.name == "Milk")
                {
                    Console.WriteLine($"The count of milk bag you have purchased:");
                    var milk_validator = Validors.IntegerValidator(Console.ReadLine(), ">");
                    if (milk_validator.valid)
                    {
                        product.weight = milk_validator.value;
                    }
                    else
                    {
                        ErrorHandler("Please input correct count of milk bag.");
                        return false;
                    }
                }
                // Chillies, Tomatoes and Apples
                else 
                {
                    Console.WriteLine($"Please input the weight of {product.name}:");
                    var weight_validator = Validors.DoubleValidator(Console.ReadLine(), ">");
                    if (weight_validator.valid)
                    {
                        product.weight = weight_validator.value;
                        Console.WriteLine($"How many store bags do you need for {product.name}?");
                        var bag_count_validator = Validors.IntegerValidator(Console.ReadLine(), ">");
                        if (bag_count_validator.valid)
                        {
                            store_bag_count += bag_count_validator.value;
                        }
                        else
                        {
                            ErrorHandler("Please input correct count of store bags.");
                            return false;
                        }
                    } else {
                        ErrorHandler($"Please input correct weight of {product.name}.");
                        return false;
                    }
                }
            }
            // If the answer is No, skip this product, it will not be calculated
            else if (purchase_validator == "N")
            {
                continue;
            }
            // If the answer is not yes or no, it's an invalid input
            else
            {
                ErrorHandler();
                return false;
            }
        }
        return true;
    }

    private bool CalculatePrice()
    {

        Console.WriteLine("Do you have a scene card? Y/N");
        string secene_card_validator = Validors.YesNoValidator(Console.ReadLine());
        if (secene_card_validator == "Y")
        {
            has_scence_card = true;
        }
        else if (secene_card_validator != "Y" && secene_card_validator != "N")
        {
            ErrorHandler();
            return false;
        }
        // Forloop items in the list
        string output = "-- SIU LIU'S GROCERY STORE RECEIPT --\nProduct List:";
        foreach (var product in product_list)
        {
            double real_price;
            if (has_scence_card)
            {
                if (product.name != "Milk")
                {
                    scene_points += product.weight * 20;
                    real_price = product.base_price * (1 - scene_card_discount);
                }
                else
                {
                    real_price = 6;
                }
            }
            else
            {
                real_price = product.base_price;
            }
            if (product.weight > 0)
            {
                double subtotal_price = real_price * product.weight;
                total_price += subtotal_price;
                output += $"\n {product.name}:\n - Base price: {product.base_price}\n - Real Price: {real_price}\n - Amount: {product.weight} {product.measurement}\n - Subtotal Price: {subtotal_price}";
            }
        }
        double store_bag_cost = store_bag_count * 0.5;
        total_price += store_bag_cost;
        double tax = total_price * tax_rate;
        double grand_total_price = total_price + tax;
        output += $"\nStore Bag Cost: {store_bag_cost}\nHST Amount: {tax}\nGrand Total: {grand_total_price}\nTotal Scene Points Earned: {scene_points}";
        Console.WriteLine(output);
        return true;
    }

    private static void ErrorHandler(string message = "Please enter a valid value!")
    {
        Console.WriteLine(message);
    }

}