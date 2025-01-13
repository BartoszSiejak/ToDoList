using System.Text.Json;
using ToDoList.Data;

namespace ToDoList.JsonConversion;

public class JsonConverter : IJsonConverter
{
    public List<ToDo> JsonToObject(string data)
    {
        var result = JsonSerializer.Deserialize<List<ToDo>>(data);

        if (result == null)
        {
            throw new NullReferenceException("Result from JsonConverter class is null");
        }

        return result;
    }

    public string ObjectToJson(List<ToDo> data)
    {
        var result = JsonSerializer.Serialize(data);
        return result;
    }
}
