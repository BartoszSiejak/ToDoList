using ToDoList.Data;
using ToDoList.FileHandling;
using ToDoList.Settings;
using ToDoList.UserInteraction;

namespace ToDoList;

public class ToDoApp(
    IFileHandler fileHandler,
    IUserInteractor userInteractor,
    IUserConfigurator userConfigurator,
    IMenuMapping menuMapping,
    IToDoCollection toDos)
{
    private readonly IFileHandler _fileHandler = fileHandler;
    private readonly IUserInteractor _userInteractor = userInteractor;
    private readonly IUserConfigurator _userConfigurator = userConfigurator;
    private readonly IMenuMapping _menuMapping = menuMapping;
    private readonly IToDoCollection _toDos = toDos;

    public void Run()
    {

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
        _userInteractor.Print(_toDos.ToString());

        if (!_toDos.IsEmpty())
        {
            var canIDelete = _userInteractor.AskForDeleteToDo("Do you want delete todo?(y/n)");

            if (canIDelete)
            {
                RemoveToDo();
            }
        }
    }

    private void ResetUserData()
    {
        _userConfigurator.ResetUserData();
        _userInteractor.Print("User data has been removed!");
    }

    private void CreateTODO()
    {
        _userInteractor.ClearText();
        var todoDescription = _userInteractor.AskForValidToDo("Enter your TODO:");
        _toDos.Add(todoDescription);
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
        var toDoID = _userInteractor.AskForValidToDoID("Which ID?", _toDos.Count);
        _toDos.RemoveAtIndex(toDoID);
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
}