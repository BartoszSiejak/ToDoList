using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using ToDoList.Data;

namespace ToDoList.UserInteraction;

public class UserInteractor : IUserInteractor
{
    private const string NullInputWarning = "Name cannot be null! Did you press CTRL + Z?";
    private const int MinToDoSize = 5;
    public void Print(string message) => Console.WriteLine(message);
    public void WaitForKey()
    {
        Print("Press any key to continue...");
        Console.ReadKey();
    }
    public void ClearText()
    {
        Console.Clear();
    }
    public void ExitMessage()
    {
        Print("Press any key to exit...");
        Console.ReadKey();
    }
    public void PrintMenu(IEnumerable<string> menu)
    {
        Print(string.Join(Environment.NewLine, menu));
    }
    public string AskForSingleWord(string message) => GetValidStringFromUser(ValidateSingleWord, message);
    public string AskForValidToDo(string message) => GetValidStringFromUser(ValidateToDo, message);
    public int AskForInt(string message) => int.Parse(GetValidStringFromUser(ValidateAge, message));
    public bool AskForDeleteToDo(string message)
    {
        var validInput = GetValidStringFromUser(ValidateYesOrNo, message);

        if(validInput == "y" || validInput == "Y")
        {
            return true;
        }

        return false;
    }

    public int AskForValidToDoID(string message, int maxId)
    {
        do
        {
            var input = GetValidStringFromUser(IsValidInt, message);
            var result = int.Parse(input);
            result--;

            if (result < 0 || result >= maxId)
            {
                Print("Selected ID does not exist.");
            }
            else
            {
                return result;
            }
        }
        while (true);
    }

    public int GetValidMenuOption(int max)
    {
        do
        {
            var input = GetValidStringFromUser(IsValidInt, "Select option:");
            var result = int.Parse(input);

            if (result <= 0 || result > max)
            {
                Print("Invalid choice!");
            }
            else
            {
                return result;
            }
        }
        while (true);
    }

    private bool ValidateYesOrNo(string? input)
    {
        if (string.Equals(input, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "n", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        Print("Invalid input. Type y for yes or n for no.");
        return false;
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

    private bool IsValidInt(string? input)
    {
        if (input is null)
        {
            Print(NullInputWarning);
            return false;
        }

        var result = int.TryParse(input, out _);

        if (result == false)
        {
            Print("Invalid number! Must contain digits only.");
            return false;
        }

        return true;
    }

    private bool ValidateToDo(string? input)
    {
        if (input is null)
        {
            Print(NullInputWarning);
            return false;
        }

        if (!char.IsUpper(input.First()))
        {
            Print("Todo must begin with a uppercase letter.");
            return false;
        }

        if (input.Length > MinToDoSize)
        {
            return true;
        }

        Print($"Todo length must be bigger than {MinToDoSize}!");
        return false;
    }
}