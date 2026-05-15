using VehicleMaintenance.Console.Models;

namespace VehicleMaintenance.Console.Agents;

public class CsvAgent
{
    public List<MaintenanceItem> LoadMaintenanceItems(string filePath)
    {
        if (!File.Exists(filePath))
            return [];

        var lines = File.ReadAllLines(
        filePath,
        System.Text.Encoding.UTF8)
                        .Skip(1);

        var items = new List<MaintenanceItem>();

        foreach (var line in lines)
        {
            var columns = line.Split(',');

            if (columns.Length < 4)
                continue;

            items.Add(new MaintenanceItem
            {
                Name = columns[0],
                LastMaintenanceKm = int.Parse(columns[1]),
                IntervalKm = int.Parse(columns[2]),
                SuggestedParts = columns[3]
            });
        }

        return items;
    }
}