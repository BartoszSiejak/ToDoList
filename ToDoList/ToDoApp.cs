using ToDoList.FileHandling;
using ToDoList.UserInteraction;

public class ToDoApp(IFileHandler fileHandler, IUserInteractor userInteractor)
{
    private readonly IFileHandler _fileHandler = fileHandler;
    private readonly IUserInteractor _userInteractor = userInteractor;

    public void Run()
    {
        if (!_fileHandler.IsExist("path"))
        {
            InitUser();
        }
        else
        {
            _userInteractor.Print("Hi ");
        }

    }

    private void InitUser()
    {
        _userInteractor.Print("Welcome in ToDoApp!");
        var name = _userInteractor.AskForSingleWord("What is your name?");
        var age = _userInteractor.AskForInt("How old are you?");

    }
}
