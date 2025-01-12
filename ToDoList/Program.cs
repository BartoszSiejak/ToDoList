using System.Net.WebSockets;
using ToDoList.Data;
using ToDoList.FileHandling;
using ToDoList.Settings;
using ToDoList.UserInteraction;

var userInteractor = new UserInteractor();
var userConfigurator = new UserConfigurator();

var app = new ToDoApp(
    new FileHandler(),
    userInteractor,
    userConfigurator,
    new MenuMapping(),
    new ToDoCollection());

app.Run();


