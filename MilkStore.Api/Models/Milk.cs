namespace MilkStore.Api.Models;

public class Milk
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Storage { get; set; }
    public Guid Id { get; set; }
}