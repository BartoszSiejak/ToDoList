
namespace ToDoList.UserInteraction;

public interface IUserInteractor
{
    int AskForInt(string message);
    string AskForSingleWord(string message);
    public void Print(string message);
    int GetValidMenuOption(int max);
    void ClearText();
    public void ExitMessage();
    public string AskForValidToDo(string message);
    public void WaitForKey();
    public void PrintMenu(IEnumerable<string> menu);
}