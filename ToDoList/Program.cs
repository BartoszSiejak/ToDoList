using ToDoList.FileHandling;
using ToDoList.Settings;
using ToDoList.UserInteraction;

var app = new ToDoApp(
    new FileHandler(),
    new UserInteractor(),
    new UserConfigurator());
app.Run();
Console.ReadKey();

