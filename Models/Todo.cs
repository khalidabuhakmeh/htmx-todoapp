namespace htmx_todoapp.Models;

public record Todo(
    int Id, 
    string Text,
    bool IsCompleted);