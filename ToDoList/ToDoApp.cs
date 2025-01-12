using ToDoList.FileHandling;
using ToDoList.Settings;
using ToDoList.UserInteraction;

public class ToDoApp(
    IFileHandler fileHandler,
    IUserInteractor userInteractor,
    IUserConfigurator userConfigurator,
    IMenu mainMenu)
{
    private readonly IFileHandler _fileHandler = fileHandler;
    private readonly IUserInteractor _userInteractor = userInteractor;
    private readonly IUserConfigurator _userConfigurator = userConfigurator;
    private readonly IMenu _mainMenu = mainMenu;

    public void Run()
    {
        if (!_userConfigurator.Exist())
        {
            InitUser();
        }

        _userInteractor.Print($"Hi {_userConfigurator.GetUserName()}! You're {_userConfigurator.GetUserAge()} years old.");
        _userInteractor.Print($"What you want to do?");
        var option = _userInteractor.ShowMenuAndGetValidOption(_mainMenu);
        _mainMenu.Execute(option);

    }

    private void InitUser()
    {
        _userInteractor.Print("Welcome in ToDoApp!");
        var name = _userInteractor.AskForSingleWord("What is your name?");
        var age = _userInteractor.AskForInt("How old are you?");
        _userConfigurator.SaveUserData(name, age);
        _userInteractor.ClearText();
    }
}

public class MainMenu : IMenu
{
    private readonly IUserInteractor _userInteractor;
    private readonly IMenu _settingsMenu;
    private readonly Dictionary<string, Action> _menuMapping;

    public MainMenu(IUserInteractor userInteractor, IMenu settingsMenu)
    {
        _userInteractor = userInteractor;
        _settingsMenu = settingsMenu;

        _menuMapping = new()
    {
        { "1. Show TODOs", ShowToDos},
        { "2. Create TODO", CreateToDo},
        { "3. Settings", ShowSettings},
        { "4. Exit", ExitApplication}
    };
    }

    public int Length => _menuMapping.Count;

    public void Execute(int option)
    {
        _userInteractor.ClearText();
        _menuMapping.ElementAt(option - 1).Value.Invoke();
    }

    private void ExitApplication()
    {
        _userInteractor.ExitMessage();
    }

    private void ShowSettings()
    {
        var option = _userInteractor.ShowMenuAndGetValidOption(_settingsMenu);
        _settingsMenu.Execute(option);
    }

    private void CreateToDo()
    {
        Console.WriteLine("Create TODO"); ;
    }

    private void ShowToDos()
    {
        Console.WriteLine("Showing TODOS");
    }

    public override string ToString()
    {
        var keys = _menuMapping.Keys.ToArray();
        return string.Join(Environment.NewLine, keys);
    }
}

public interface IMenu
{
    public int Length { get; }
    void Execute(int option);
    public string ToString();
}

public class SettingsMenu : IMenu
{
    private readonly IUserInteractor _userInteractor;
    private readonly IUserConfigurator _userConfigurator;
    private readonly Dictionary<string, Action> _menuMapping;

    public SettingsMenu(IUserInteractor userInteractor, IUserConfigurator userConfigurator)
    {
        _userInteractor = userInteractor;
        _userConfigurator = userConfigurator;
        _menuMapping = new()
    {
        { "1. Reset user data!", ResetUserData}
    };
    }

    public int Length => _menuMapping.Count;

    public void Execute(int option)
    {
        _userInteractor.ClearText();
        _menuMapping.ElementAt(option - 1).Value.Invoke();
    }

    private void ResetUserData()
    {
        _userConfigurator.ResetUserData();
        _userInteractor.Print("Data has been removed");
        _userInteractor.Print("Restart your app!");
        _userInteractor.ExitMessage();
    }
    public override string ToString()
    {
        var keys = _menuMapping.Keys.ToArray();
        return string.Join(Environment.NewLine, keys);
    }
}