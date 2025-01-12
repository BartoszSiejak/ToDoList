namespace ToDoList.Settings;

public class UserConfigurator : IUserConfigurator
{
    public string GetUserName() => UserSettings.Default.UserName;
    public int GetUserAge() => UserSettings.Default.UserAge;
    public bool Exist() => !(UserSettings.Default.UserName == string.Empty);

    public void SaveUserData(string name, int age)
    {
        UserSettings.Default.UserName = name;
        UserSettings.Default.UserAge = age;
        UserSettings.Default.Save();
    }
}