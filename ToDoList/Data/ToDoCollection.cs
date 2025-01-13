namespace ToDoList.Data;

public class ToDoCollection : IToDoCollection
{
    private readonly List<ToDo> _items;

    public ToDoCollection()
    {
        _items = [];
    }

    public int Count => _items.Count;

    public void Add(string description)
    {
        _items.Add(new ToDo(description));
    }

    public bool IsEmpty()
    {
        return _items.Count == 0;
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
