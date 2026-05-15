using VehicleMaintenance.Console.Models;

namespace VehicleMaintenance.Console.Agents;

public class MaintenanceAgent
{
    public List<MaintenanceItem> GetDueMaintenances(
        List<MaintenanceItem> items,
        int currentKm)
    {
        return items
            .Where(item =>
                item.IsDue(currentKm) ||
                item.IsNearDue(currentKm))
            .ToList();
    }
}
