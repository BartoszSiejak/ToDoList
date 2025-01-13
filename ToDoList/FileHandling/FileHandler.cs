namespace ToDoList.FileHandling;

public class FileHandler(string filePath) : IFileHandler
{

    private readonly string _filePath = filePath;
    public bool IsExist() => File.Exists(_filePath);


    public string Read()
    {
        return File.ReadAllText(_filePath);
    }

    public void Write(string value)
    {
        File.WriteAllText(_filePath, value);
    }
}