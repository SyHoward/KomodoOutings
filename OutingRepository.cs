using System;
using System.ComponentModel;

public class OutingRepository 
{
    protected readonly List<OutingItems> _outingDirectory = new List<OutingItems>();
    public OutingRepository()
    {
        Seed();
    }

//CRUD
    //Create
    public bool AddOutingToDirectory(OutingItems item)
    {
        int startingCount = _outingDirectory.Count;
        _outingDirectory.Add(item);
        bool wasAdded = _outingDirectory.Count > startingCount;
        return wasAdded;
    }

    //Read
    public List<OutingItems> GettAllOutingItems()
    {
        return _outingDirectory;
    }
    public OutingItems GetItemByType(Type type)
    {
        foreach (OutingItems item in _outingDirectory)
        {
            if (item.Type == type)
            {
                return item;
            }
        }
        return default;
    }
    //Read with calcs
    // public OutingItems GetTotalCost(OutingItems item)
    // {
    //     foreach(OutingItems item)
    //     {
    //         switch(item.Type)
    //         {
        //This is where I got stuck.
    //         }
    //     }
    // }

// //Update 
// public bool UpdateExistingItem(string orginalItem, OutingItems newItem)
// {
//     OutingItems oldItem = GetItemByType(orginalItem);
//     if (oldItem != default)
//     {
//         oldItem.Type = newItem.Type;
//         oldItem.People = newItem.People;
//         oldItem.Date = newItem.Date;
//         oldItem.IndividualCost = newItem.IndividualCost;
//         oldItem.EventCost = newItem.EventCost;
//         return true;
//     }
//     else
//     {
//         return false;
//     }
// }
//! I did both of these, but they weren't in the brief.
// //Delete
// public bool DeleteExistingItem(string type)
// {
//     OutingItems ItemToDelete = GetItemByType(type);
//     {
//         if(ItemToDelete != default)
//         {
//             bool deleteResult = _outingDirectory.Remove(ItemToDelete);
//             return deleteResult;
//         }
//         else
//         {
//             return false;
//         }
//     }
// }

//Seed
    public void Seed()
    {
        OutingItems outingOne = new OutingItems
        (
            Type.Bowling,
            15,
            "January 15th",
            16.67,
            250
        );
        AddOutingToDirectory(outingOne);
        OutingItems outingTwo = new OutingItems
        (
            Type.Golf,
            30, 
            "March 15th",
            15.50,
            465
        );
        AddOutingToDirectory(outingTwo);
        OutingItems outingThree = new OutingItems
        (
            Type.Bowling,
            20,
            "May 17th",
            15,
            300
        );
        AddOutingToDirectory(outingThree);
        OutingItems outingFour = new OutingItems
        (
            Type.Golf,
            45,
            "July 10th",
            15.50,
            697.50
        );
        AddOutingToDirectory(outingFour);
        OutingItems outingFive = new OutingItems
        (
            Type.AmusementPark,
            45,
            "September 11th",
            50.00,
            2250
        );
        AddOutingToDirectory(outingFive);
    }
}