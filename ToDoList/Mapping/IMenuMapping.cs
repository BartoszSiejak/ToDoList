namespace ToDoList.Mapping;

public interface IMenuMapping
{
    public IEnumerable<string> MainMenu { get; }
    public IEnumerable<string> SettingsMenu { get; }
}