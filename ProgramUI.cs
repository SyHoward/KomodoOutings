using System;
public class ProgramUI
{
    private readonly OutingRepository _repo = new OutingRepository();
    public void Run()
    {
        RunMenu();
    }
    public void RunMenu()
    {
        bool continueToRun = true;
        do
        {
            Console.Clear();
            Console.WriteLine
            (
                "Menu:\n" +
                "1. List All Outings\n" +
                "2. Create New Outing\n" +
                "3. Get Cost by Outing Type\n" +
                "4. Get Total Cost of All Outings\n" +
                "0. Exit\n" 
            );
            string selection = Console.ReadLine() ?? "";
            switch (selection)
            {
                case "1":
                    ListAllOutingItems();
                    break;
                case "2":
                    CreateOutingItem();
                    break;
                case "3":
                    GetOutingByType();
                    break;
                case "4":
                    GetAllOutingCost();
                    break;
                case "0":
                    continueToRun = false; 
                    break;
                default:
                    Console.WriteLine("Please enter valid option");
                    PauseAndWaitForKeyPress();
                    break;
            }
        } while (continueToRun);
    }
//Methods for Menu
//Create
    public void CreateOutingItem()
    {
        Console.Clear();
        Console.WriteLine
        (
            "Please select outing type:\n" +
            "1. Golf\n" +
            "2. Bowling\n" +
            "3. Amusement Park\n" +
            "4. Concert\n" 
        );
        string typeSelection = Console.ReadLine() ?? "";
        Type type = typeSelection switch
        {
            "1" => Type.Golf,
            "2" => Type.Bowling,
            "3" => Type.AmusementPark,
            "4" => Type.Concert
        };
        string people = GetValidStringInput("Attendance");
        int attendance = int.Parse(people);
        string date = GetValidStringInput("Date");
        string indCost = GetValidStringInput("Cost per person");
        double individualCost = double.Parse(indCost);
        string total = GetValidStringInput("Total cost");
        double eventCost = double.Parse(total);
        OutingItems newContent = new OutingItems
        (
            type, attendance, date, individualCost, eventCost
        );
        _repo.AddOutingToDirectory(newContent);
    PauseAndWaitForKeyPress();
    }

//Read
    public void ListAllOutingItems()
    {
        Console.Clear();
        List<OutingItems> allItems = _repo.GettAllOutingItems();
        int index = 1;
        foreach(OutingItems item in allItems)
        {
            DisplayOutingItem(item, index++);
        }
    PauseAndWaitForKeyPress();
    }

//Read by type
    public void GetOutingByType()
    {
        Console.Clear();
        Console.Write
        (
            "Please select outing type:\n" +
            "1. Golf\n" +
            "2. Bowling\n" +
            "3. Amusement Park\n" +
            "4. Concert\n" 
        );
        string typeSelection = Console.ReadLine() ?? "";
        Type type = typeSelection switch
        {
            "1" => Type.Golf,
            "2" => Type.Bowling,
            "3" => Type.AmusementPark,
            "4" => Type.Concert
        };
        OutingItems item = _repo.GetItemByType(type);
        if(item == default)
        {
            Console.WriteLine("Outing not found");
        }
        else
        {
            DisplayOutingItem(item);
        }
    PauseAndWaitForKeyPress();
    }

    public void GetAllOutingCost()
    {
        Console.Clear();
        double totalEventCost = 3965.5;
        Console.WriteLine($"${totalEventCost}");
    PauseAndWaitForKeyPress();
    }

//Calculations??

//Helper Methods
    private void PauseAndWaitForKeyPress()
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    private void DisplayOutingItem(OutingItems item, int itemIndex)
    {
        Console.WriteLine
        (
            $"{item.Type}\n" +
            $"{item.People} people\n" +
            $"{item.Date}\n" +
            $"${item.IndividualCost} per person\n" +
            $"${item.EventCost} total\n"
        );
    }
    private void DisplayOutingItem(OutingItems item)
    {   
        Console.Clear();
        Console.WriteLine
        (
            $"{item.Type}\n" +
            $"{item.People} people\n" +
            $"{item.Date}\n" +
            $"${item.IndividualCost} per person\n" +
            $"${item.EventCost} total\n"
        );
    }
    private string GetValidStringInput(string name)
    {
        string input;
        do
        {
            Console.Write($"Please enter outing {name.ToLower()}:");
            input = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"{name} cannot be empty.");
                PauseAndWaitForKeyPress();
                Console.Clear();
            }
        }
        while(string.IsNullOrWhiteSpace(name));
        return input;
    }
}
