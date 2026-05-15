namespace VehicleMaintenance.Console.Agents;

public class MileageAgent
{
    public int ParseMileage(string input)
    {
        return int.TryParse(input, out var mileage)
            ? mileage
            : 0;
    }
}
