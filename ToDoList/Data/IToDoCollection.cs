namespace ToDoList.Data;

public interface IToDoCollection
{
    public void Add(string description);
    public void Remove(string description);
    public void RemoveAtIndex(int index);
    public string ToString();
}