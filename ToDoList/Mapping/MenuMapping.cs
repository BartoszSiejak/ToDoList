namespace ToDoList.Mapping;

public class MenuMapping : IMenuMapping
{
    public IEnumerable<string> MainMenu => new List<string>
{
    "1. Show TODOs",
    "2. Create new TODO",
    "3. Settings",
    "4. Exit",
};

    public IEnumerable<string> SettingsMenu => new List<string>
{
    "1. Delete user data"
};
}