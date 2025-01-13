using System.Net.WebSockets;
using ToDoList;
using ToDoList.Data;
using ToDoList.FileHandling;
using ToDoList.Mapping;
using ToDoList.Settings;
using ToDoList.UserInteraction;
using ToDoList.JsonConversion;

const string FilePath = "data.json";

var app = new ToDoApp(
    new FileHandler(FilePath),
    new JsonConverter(),
    new UserInteractor(),
    new UserConfigurator(),
    new MenuMapping(),
    new ToDoCollection());


try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Exception was thrown. Message: " + ex.Message);
}


