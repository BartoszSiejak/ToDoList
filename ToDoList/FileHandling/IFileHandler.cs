namespace ToDoList.FileHandling;

public interface IFileHandler
{
    string Read();
    void Write(string value);
    bool IsExist();
}