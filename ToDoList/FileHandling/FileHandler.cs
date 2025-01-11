namespace ToDoList.FileHandling;

public class FileHandler : IFileHandler
{
    public bool IsExist(string path) => File.Exists(path);

}