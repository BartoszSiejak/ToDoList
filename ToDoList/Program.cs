using System.Net.WebSockets;
using ToDoList.FileHandling;
using ToDoList.Settings;
using ToDoList.UserInteraction;

var userInteractor = new UserInteractor();
var userConfigurator = new UserConfigurator();

var app = new ToDoApp(
    new FileHandler(),
    userInteractor,
    userConfigurator,
    new MainMenu(
        userInteractor,
        new SettingsMenu(
            userInteractor,
            userConfigurator)));

app.Run();


