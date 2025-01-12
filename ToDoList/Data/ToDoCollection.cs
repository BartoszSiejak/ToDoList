namespace ToDoList.Data;

public class ToDoCollection : IToDoCollection
{
    private readonly List<ToDo> _items;

    public ToDoCollection()
    {
        _items = [];
    }

    public void Add(string description)
    {
        _items.Add(new ToDo(description));
    }

    public void Remove(string description)
    {
        _items.Remove(new ToDo(description));
    }

    public void RemoveAtIndex(int index)
    {
        _items.RemoveAt(index);
    }

    public override string ToString()
    {
        var index = 0;
        var result = _items.Select(todo => $"{++index}. {todo.Description}");

        if(!result.Any())
        {
            return "ToDo list is empty!";
        }
        return string.Join(Environment.NewLine, result);
    }
}
