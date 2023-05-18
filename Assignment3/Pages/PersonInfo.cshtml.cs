using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class PersonInfoModel : PageModel
{
    public Person person = new Person();

    public IActionResult OnPostPostPersonInfo(Person person)
    {
        var new_person = new Person()
        {
            First_Name = person.First_Name,
            Last_Name = person.Last_Name,
            Address = person.Address,
            City = person.City,
            Country = person.Country,
            Province = person.Province
        };
        return RedirectToPage("PersonAdded", new_person);
    }
}