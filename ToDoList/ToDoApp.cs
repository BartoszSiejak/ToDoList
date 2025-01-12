using ToDoList.FileHandling;
using ToDoList.Settings;
using ToDoList.UserInteraction;

public class ToDoApp(
    IFileHandler fileHandler,
    IUserInteractor userInteractor,
    IUserConfigurator userConfigurator)
{
    private readonly IFileHandler _fileHandler = fileHandler;
    private readonly IUserInteractor _userInteractor = userInteractor;
    private readonly IUserConfigurator _userConfigurator = userConfigurator;

    public void Run()
    {
        if (!_userConfigurator.Exist())
        {
            InitUser();
        }

        _userInteractor.Print($"Hi {_userConfigurator.GetUserName()}! You're {_userConfigurator.GetUserAge()} years old.");
        _userInteractor.Print($"What you want to do?");
        var option = _userInteractor.ShowMenuAndGetValidOption();


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