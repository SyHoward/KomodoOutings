using System.Runtime.Serialization;
public enum Type {Golf, Bowling, AmusementPark, Concert}
public class OutingItems
{
    public Type Type{get; set;}
    public int People{get; set;}
    public string Date{get; set;} 
    public double IndividualCost {get; set;}
    public double EventCost {get; set;}

    // Constructor
    public OutingItems(){}
    public OutingItems(Type type, int people, string date, double individualCost, double eventCost)
    {
        Type = type;
        People = people;
        Date = date; 
        IndividualCost = individualCost;
        EventCost = eventCost;
    }
}