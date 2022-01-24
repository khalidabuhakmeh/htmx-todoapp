namespace htmx_todoapp.Models;

public class Database
{
    private int counter = 0;
    public List<Todo> Items { get; } = new();

    public void Add(string text)
    {
        Interlocked.Increment(ref counter);
        
        var todo = new Todo(
            Id: counter,
            Text: text,
            IsCompleted: false
        );
        
        Items.Add(todo);
    }

    public void Remove(int id)
    {
        Items.RemoveAll(t => t.Id == id);
    }

    public void Update(int id, bool isCompleted)
    {
        var todo = Items.Find(x => x.Id == id);

        if (todo is { })
        {
            var index = Items.IndexOf(todo);
            // replace
            Items[index] = todo with {IsCompleted = isCompleted};
        }
    }
}