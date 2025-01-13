namespace ToDoList.Data;

public class ToDoCollection : IToDoCollection
{
   public List<ToDo> List { get; set; }

    public ToDoCollection()
    {
        List = [];
    }

    public int Count => List.Count;

    public void Add(string description)
    {
        List.Add(new ToDo(description));
    }

    public bool IsEmpty()
    {
        return List.Count == 0;
    }
    public void RemoveAtIndex(int index)
    {
        List.RemoveAt(index);
    }

    public override string ToString()
    {
        var index = 0;
        var result = List.Select(todo => $"{++index}. {todo.Description}");

        if(!result.Any())
        {
            return "ToDo list is empty!";
        }
        return string.Join(Environment.NewLine, result);
    }
}
