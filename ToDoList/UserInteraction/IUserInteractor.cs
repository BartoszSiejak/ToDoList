namespace ToDoList.UserInteraction;

public interface IUserInteractor
{
    int AskForInt(string message);
    string AskForSingleWord(string message);
    public void Print(string message);
}