namespace ToDoList.Data;

public interface IToDoCollection
{
    int Count { get; }
    public void Add(string description);
    public bool IsEmpty();
    public void Remove(string description);
    public void RemoveAtIndex(int index);
    public string ToString();
}