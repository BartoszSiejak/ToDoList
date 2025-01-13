using ToDoList.Data;

namespace ToDoList.JsonConversion;

public interface IJsonConverter
{
    List<ToDo> JsonToObject(string data);
    string ObjectToJson(List<ToDo> data);
}