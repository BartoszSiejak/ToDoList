namespace ToDoList.Settings;

public interface IUserConfigurator
{
    bool Exist();
    string GetUserName();
    int GetUserAge();
    void SaveUserData(string name, int age);
}