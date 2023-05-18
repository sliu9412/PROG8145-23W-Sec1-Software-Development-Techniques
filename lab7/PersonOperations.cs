using System.Text.RegularExpressions;
public class PersonOperations : Handlers
{
    private string csv_path = Path.Join(Directory.GetCurrentDirectory(), "Person.csv");
    private List<Person> PersonList = new List<Person>();
    public void Menu()
    {
        var is_break = false;
        do
        {
            Console.WriteLine("================================");
            Console.WriteLine("Please Select an Option");
            Console.WriteLine("================================");
            Console.WriteLine("1. Add Person");
            Console.WriteLine("2. List People");
            Console.WriteLine("3. Save List");
            Console.WriteLine("4. Load List");
            Console.WriteLine("5. Exit");
            var option_validator = Validators.IntegerRangeValidator(Console.ReadLine(), new List<int> { 1, 2, 3, 4, 5 });
            if (option_validator.valid)
            {
                if (option_validator.value == 5)
                {
                    is_break = true;
                    Console.WriteLine("Goodbye");
                }
                else if (option_validator.value == 1)
                {
                    AddPerson();
                }
                else if (option_validator.value == 2)
                {
                    ListPeople();
                }
                else if (option_validator.value == 3)
                {
                    SaveList();
                }
                else if (option_validator.value == 4)
                {
                    LoadList();
                }
            }
            else
            {
                Message("Invalid option, please try again.");
            }
        } while (!is_break);
    }

    public void LoadList()
    {
        FileStream f;
        if (File.Exists(csv_path))
        {
            f = new FileStream(csv_path, FileMode.Open, FileAccess.Read);
            var row_pattern = @"^.+?,.+?,\d{2}\/\d{2}\/\d{4},.+?,.+?,.+?,.+?$";
            var row_reg = new Regex(row_pattern);
            using (var reader = new StreamReader(f))
            {
                // PersonList.Clear();
                var temporary_person_list = new List<Person>();
                var has_error_row = false;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (row_reg.IsMatch(line!))
                    {
                        var new_person = new Person();
                        var is_valid_person = new_person.LoadRow(line!);
                        if (is_valid_person)
                        {
                            temporary_person_list.Add(new_person);
                        }
                        else
                        {
                            has_error_row = true;
                            break;
                        }
                    }
                    else
                    {
                        has_error_row = true;
                    }
                }
                if (!has_error_row)
                {
                    PersonList = PersonList.Concat(temporary_person_list).ToList<Person>();
                    Message("Load data successfully, person list has been flushed.");
                }
                else
                {
                    Message("Load data failed, csv file's format is incorrect.");
                }
            }
            f.Close();
        }
        else
        {
            Message("Loading person list failed, file not found");
        }
    }

    public void SaveList()
    {
        // To clear previous content of the file
        if (File.Exists(csv_path))
        {
            File.Delete(csv_path);
        }
        using (var f = new FileStream(csv_path, FileMode.Create, FileAccess.ReadWrite))
        {
            using (var writer = new StreamWriter(f))
            {
                foreach (var person in PersonList)
                {
                    writer.WriteLine(person.GenerateRow());
                }
                Message("Saving data successfully");
            }
        }
    }

    public void AddPerson()
    {
        while (true)
        {
            Console.WriteLine("What's your first name?");
            var first_name_validator = Validators.InputValidator(Console.ReadLine());
            if (first_name_validator.valid)
            {
                Console.WriteLine("What's your last name?");
                var last_name_validator = Validators.InputValidator(Console.ReadLine());
                if (last_name_validator.valid)
                {
                    Console.WriteLine("What's your birthdate? eg. YYYY-MM-DD");
                    var birthdate_validator = Validators.DateValidator(Console.ReadLine());
                    if (birthdate_validator.valid)
                    {
                        Console.WriteLine("What country are you from?");
                        var country_validator = Validators.InputValidator(Console.ReadLine());
                        if (country_validator.valid)
                        {
                            Console.WriteLine("What province are you from?");
                            var province_validator = Validators.InputValidator(Console.ReadLine());
                            if (province_validator.valid)
                            {
                                Console.WriteLine("What city are you from?");
                                var city_validator = Validators.InputValidator(Console.ReadLine());
                                if (city_validator.valid)
                                {
                                    Console.WriteLine("What's your address?");
                                    var address_validator = Validators.InputValidator(Console.ReadLine());
                                    if (address_validator.valid)
                                    {
                                        var new_person = new Person()
                                        {
                                            First_Name = first_name_validator.value,
                                            Last_Name = last_name_validator.value,
                                            Birthdate = birthdate_validator.value,
                                            Address = address_validator.value,
                                            City = city_validator.value,
                                            Country = country_validator.value,
                                            Province = province_validator.value,
                                        };
                                        PersonList.Add(new_person);
                                        Message("Add new person successfully");
                                        break;
                                    }
                                    else
                                    {
                                        Message("Address should not be empty.");
                                    }
                                }
                                else
                                {
                                    Message("City should not be empty");
                                }
                            }
                            else
                            {
                                Message("Province should not be empty.");
                            }
                        }
                        else
                        {
                            Message("Country should not be empty.");
                        }
                    }
                    else
                    {
                        Message("birthdate format is wrong.");
                    }
                }
                else
                {
                    Message("Last name should not be empty.");
                }
            }
            else
            {
                Message("First name should not be empty.");
            }
        }
    }

    public void ListPeople()
    {
        if (PersonList.Count <= 0)
        {
            Message("Person List is empty. Please add a new person or load from the csv file.");
        }
        else
        {
            foreach (var person in PersonList)
            {
                Console.WriteLine(person.GenerateRow());
            }
            Message();
        }
    }
}
