using ToDoList.Data;
using ToDoList.FileHandling;
using ToDoList.JsonConversion;
using ToDoList.Mapping;
using ToDoList.Settings;
using ToDoList.UserInteraction;

namespace ToDoList;

public class ToDoApp(
    IFileHandler fileHandler,
    IJsonConverter jsonConverter,
    IUserInteractor userInteractor,
    IUserConfigurator userConfigurator,
    IMenuMapping menuMapping,
    IToDoCollection toDos)
{
    private readonly IFileHandler _fileHandler = fileHandler;
    private readonly IJsonConverter _jsonConverter = jsonConverter;
    private readonly IUserInteractor _userInteractor = userInteractor;
    private readonly IUserConfigurator _userConfigurator = userConfigurator;
    private readonly IMenuMapping _menuMapping = menuMapping;
    public IToDoCollection ToDos { get; set; } = toDos;

    public void Run()
    {
        if (_fileHandler.IsExist())
        {
            try 
            {
                var data = _fileHandler.Read();
                ToDos.List = _jsonConverter.JsonToObject(data);
            }
            catch
            {
                _userInteractor.Print("Data are broken. ToDoList will be empty!");
                _userInteractor.WaitForKey();
            }  
        }

        do
        {
            if (!_userConfigurator.Exist())
            {
                InitUser();
            }

            _userInteractor.ClearText();
            _userInteractor.Print($"Hi {_userConfigurator.GetUserName()}! You're {_userConfigurator.GetUserAge()} years old.");
            _userInteractor.Print($"What you want to do?");
            _userInteractor.PrintMenu(_menuMapping.MainMenu);
            var userOption = _userInteractor.GetValidMenuOption(_menuMapping.MainMenu.Count());
            MainMenuHandling(userOption);
            _userInteractor.WaitForKey();
        }
        while (true);

    }

    private void InitUser()
    {
        _userInteractor.Print("Welcome in ToDoApp!");
        var name = _userInteractor.AskForSingleWord("What is your name?");
        var age = _userInteractor.AskForInt("How old are you?");
        _userConfigurator.SaveUserData(name, age);

    }

    private void MainMenuHandling(int userOption)
    {
        switch (userOption)
        {
            case 1:
                ShowTODOs();
                break;
            case 2:
                CreateTODO();
                break;
            case 3:
                ShowSettings();
                break;
            case 4:
                ExitApplication();
                break;
        }
    }
    private void ShowTODOs()
    {
        _userInteractor.ClearText();
        _userInteractor.Print(ToDos.ToString());

        if (!ToDos.IsEmpty())
        {
            var canIDelete = _userInteractor.AskForDeleteToDo("Do you want delete todo?(y/n)");

            if (canIDelete)
            {
                RemoveToDo();
                SaveDataToStorage();
            }
        }
    }
    private void CreateTODO()
    {
        _userInteractor.ClearText();
        var todoDescription = _userInteractor.AskForValidToDo("Enter your TODO:");
        ToDos.Add(todoDescription);
        SaveDataToStorage();
        _userInteractor.Print("ToDo has been added!");
    }

    private void ExitApplication()
    {
        _userInteractor.ClearText();
        _userInteractor.ExitMessage();
        Environment.Exit(0);
    }

    private void RemoveToDo()
    {
        var toDoID = _userInteractor.AskForValidToDoID("Which ID?", ToDos.Count);
        ToDos.RemoveAtIndex(toDoID);
        _userInteractor.Print("ToDo has been deleted!");
    }

    private void ShowSettings()
    {
        _userInteractor.ClearText();
        _userInteractor.PrintMenu(_menuMapping.SettingsMenu);
        var userOption = _userInteractor.GetValidMenuOption(_menuMapping.SettingsMenu.Count());
        SettingsMenuHandling(userOption);
    }

    private void SettingsMenuHandling(int userOption)
    {
        switch (userOption)
        {
            case 1:
                ResetUserData();
                break;
        }
    }

    private void ResetUserData()
    {
        _userConfigurator.ResetUserData();
        _userInteractor.Print("User data has been removed!");
    }
    private void SaveDataToStorage()
    {
        var data = _jsonConverter.ObjectToJson(ToDos.List);
        _fileHandler.Write(data);
    }
}
