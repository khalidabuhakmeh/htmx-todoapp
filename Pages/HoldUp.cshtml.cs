using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace htmx_todoapp.Pages;

public class HoldUp : PageModel
{
    [BindProperty] public string Name { get; set; }
    
    public bool HasValidationMessage { get; set; }
    public bool AllGoodHere { get; set; }

    public PartialViewResult OnPost()
    {
        HasValidationMessage = false;
        AllGoodHere = true;
        
        return Partial("_Form", this);
    }

    public async Task<IActionResult> OnPostValidate()
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
        HasValidationMessage = true;
        return Partial("_Input", this);
    }
}