using Microsoft.AspNetCore.Mvc.RazorPages;

public class PersonAddedModel : PageModel
{
    public Person person = new Person();
    public void OnGet(Person person)
    {
        this.person = person;
    }
}