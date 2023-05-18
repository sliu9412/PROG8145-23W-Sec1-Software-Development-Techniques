public class Electronic : StoreInfo
{
    List<Item> InventoryList = new List<Item>();

    // display menu
    public void ShowMenu()
    {
        var isBreak = true;
        do
        {
            Console.WriteLine(ShowStoreInformation());
            Console.WriteLine("1. Add a New Item");
            Console.WriteLine("2. Display Inventory List");
            Console.WriteLine("3. Delete an Individual Item");
            Console.WriteLine("4. Clear Inventory List");
            Console.WriteLine("5. Exit the Program");
            var option_validator = Validors.IntegerRangeValidator(Console.ReadLine(), new List<int>() { 1, 2, 3, 4, 5 });
            if (option_validator.valid)
            {
                if (option_validator.value == 1)
                {
                    AddNewItem();
                }
                else if (option_validator.value == 2)
                {
                    DisplayItemList();
                }
                else if (option_validator.value == 3)
                {
                    DeleteIndividualItem();
                }
                else if (option_validator.value == 4)
                {
                    ClearInventoryList();
                }
                else if (option_validator.value == 5)
                {
                    Console.WriteLine("Goodbye!");
                    isBreak = false;
                }                
            }
            else
            {
                Console.WriteLine("Please input right number of menu");
                Handlers.PauseHandler();
            }
        } while (isBreak);
    }

    // clear inventory list
    public void ClearInventoryList()
    {
        InventoryList.Clear();
        Console.WriteLine("Inventory list has been cleared!");
        Handlers.PauseHandler();
    }

    // delete item by index - 1
    public void DeleteIndividualItem()
    {
        var checkInventory = DisplayItemsString();
        if (checkInventory != "There's no items in inventory list!")
        {
            Console.WriteLine(checkInventory);
            try
            {
                Console.WriteLine("Please input the number of item:");
                var item_index = Validors.IntegerValidator(Console.ReadLine(), "null");
                InventoryList.RemoveAt(item_index.value - 1);
                Console.WriteLine("Item has been removed from Inventory!");
            }
            catch
            {
                Console.WriteLine("Please input a valid number");
            }
        } else {
            Console.WriteLine(checkInventory);
        }
        Handlers.PauseHandler();
    }

    // return string of product list
    private string DisplayItemsString()
    {
        var list_string = "";
        if (InventoryList.Count <= 0)
        {
            list_string = "There's no items in inventory list!";
        }
        else
        {
            list_string = "============\n";
            var item_index = 1;
            foreach (var item in InventoryList)
            {
                var total_price = item.price * item.quantity;
                list_string += $"- {item_index++}. Product Name: {item.name}, Product Quantity: {item.quantity} ,Product Unit Price: ${item.price}, Product Total Price: ${total_price}\n";
            }
            list_string += "============";
        }
        return list_string;
    }

    // display item list
    public void DisplayItemList()
    {
        Console.WriteLine(DisplayItemsString());
        Handlers.PauseHandler();
    }

    // user add a new item
    public void AddNewItem()
    {
        Console.WriteLine("Please input the item's name:");
        var item_name_validator = Validors.InputValidator(Console.ReadLine());
        if (item_name_validator.valid)
        {
            Console.WriteLine("Please input the item's quantity in stock:");
            var item_quantity_validator = Validors.IntegerValidator(Console.ReadLine(), ">");
            if (item_quantity_validator.valid)
            {
                Console.WriteLine("Please input the item's price per unit");
                var item_price_validator = Validors.DoubleValidator(Console.ReadLine(), ">");
                if (item_price_validator.valid)
                {
                    var new_item = new Item()
                    {
                        name = item_name_validator.value,
                        quantity = item_quantity_validator.value,
                        price = item_price_validator.value
                    };
                    InventoryList.Add(new_item);
                    Console.WriteLine("Add item successfully!");
                    Handlers.PauseHandler();
                }
                else
                {
                    Console.WriteLine("Please input a valid price of item");
                    Handlers.PauseHandler();
                }
            }
            else
            {
                Console.WriteLine("Please input a valid quantity of item");
                Handlers.PauseHandler();
            }
        }
        else
        {
            Console.WriteLine("Please input the name of item");
            Handlers.PauseHandler();
        }
    }

    // add hardcore when initialing
    private void InitializedAddItem(string name, int quantity, double price)
    {
        var new_item = new Item()
        {
            name = name,
            quantity = quantity,
            price = price
        };
        InventoryList.Add(new_item);
    }

    // constructor
    public Electronic(string store_name, string store_address, string store_owner_first_name, string store_owner_last_name)
    {
        this.store_name = store_name;
        this.store_address = store_address;
        this.store_owner_first_name = store_owner_first_name;
        this.store_owner_last_name = store_owner_last_name;
        InitializedAddItem("iPad", 100, 599);
        InitializedAddItem("iPhone 14", 80, 999);
        InitializedAddItem("Pixel 7", 100, 899);
    }
}