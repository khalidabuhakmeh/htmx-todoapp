using htmx_todoapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace htmx_todoapp.Pages;

public class IndexModel : PageModel
{
    private readonly Database database;
    private readonly ILogger<IndexModel> logger;
    
    public List<Todo> Todos => 
        database
        .Items
        .OrderBy(x => x.Id)
        .ToList();

    public IndexModel(Database database, ILogger<IndexModel> logger)
    {
        this.database = database;
        this.logger = logger;
    }

    public void OnGet()
    {
    }
    
    public IActionResult OnPostAddTodo([FromForm] string text)
    {
        database.Add(text);
        return Partial("Shared/_List", this);
    }

    public IActionResult OnPostRemoveTodo([FromQuery] int id)
    {
        database.Remove(id);
        return Partial("Shared/_List", this);
    }

    public IActionResult OnPostUpdateTodo([FromQuery] int id, [FromForm] bool isCompleted)
    {
        database.Update(id, isCompleted);
        return Partial("Shared/_List", this);
    }
}