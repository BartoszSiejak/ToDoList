namespace ToDoList.Data;

public interface IToDoCollection
{
    List<ToDo> List { get; set; }
    int Count { get; }
     void Add(string description);
     bool IsEmpty();
     void RemoveAtIndex(int index);
    string ToString();
}