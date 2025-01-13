
namespace ToDoList.UserInteraction;

public interface IUserInteractor
{
     void Print(string message);
     void WaitForKey();
    void ClearText();
     void ExitMessage();
     void PrintMenu(IEnumerable<string> menu);
    int AskForInt(string message);
    string AskForSingleWord(string message);
    bool AskForDeleteToDo(string message);
    int AskForValidToDoID(string message, int maxId);
     string AskForValidToDo(string message);
    int GetValidMenuOption(int max);
}