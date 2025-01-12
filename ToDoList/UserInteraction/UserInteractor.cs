namespace ToDoList.UserInteraction;

public class UserInteractor : IUserInteractor
{
    private const string NullInputWarning = "Name cannot be null! Did you press CTRL + Z?";
    public void Print(string message) => Console.WriteLine(message);

    public string AskForSingleWord(string message) => GetValidStringFromUser(ValidateSingleWord, message);

    public int AskForInt(string message) => int.Parse(GetValidStringFromUser(ValidateAge, message));

    public int ShowMenuAndGetValidOption()
    {
        Print("1. Show TODOs");
        Print("2. Create TODO");
        Print("3. Settings");
        Print("4. Exit");

        var input = GetValidStringFromUser(ValidateMenuOption, "Select option:");

        return int.Parse(input);
    }

    public void ClearText()
    {
        Console.Clear();
    }

    private string GetValidStringFromUser(Func<string?, bool> IsValid, string message)
    {
        string? result;

        do
        {
            Print(message);
            result = Console.ReadLine();
        }
        while (!IsValid(result));

        if (result is null)
        {
            throw new NullReferenceException(nameof(result) + " is null");
        }

        return result;
    }

    private bool ValidateSingleWord(string? input)
    {
        if (input is null)
        {
            Print(NullInputWarning);
            return false;
        }
        if (input.Any(character => char.IsLetter(character)))
        {
            return true;
        }

        Print("Invalid name! Name must contain only letters!");
        return false;
    }

    private bool ValidateAge(string? input)
    {
        if (input is null)
        {
            Print(NullInputWarning);
            return false;
        }

        var result = int.TryParse(input, out int age);

        if (result == false)
        {
            Print("Invalid number! Must contain digits only.");
            return false;
        }

        if (age < 0)
        {
            Print("Age cannot be smaller than 0!");
            return false;
        }

        if (age > 140)
        {
            Print("Age cannot be larger than 140!");
            return false;
        }

        return true;
    }

    private bool ValidateMenuOption(string? input)
    {
        if (input is null)
        {
            Print(NullInputWarning);
            return false;
        }

        var result = int.TryParse(input, out int value);

        if (result == false)
        {
            Print("Invalid number! Must contain digits only.");
            return false;
        }
        else if (value > 0 && value < 5)
        {
            return true;
        }

        Print("Invalid option!");
        return false;
    }

}