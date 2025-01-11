using ToDoList.FileHandling;

var app = new ToDoApp(
    new FileHandler(),
    new UserInteractor());
app.Run();
Console.ReadKey();

