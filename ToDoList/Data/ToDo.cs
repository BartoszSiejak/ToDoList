namespace ToDoList.Data;

public struct ToDo(string description)
{
    public string Description { get; set; } = description;
}
