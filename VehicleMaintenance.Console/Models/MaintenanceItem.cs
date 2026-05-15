namespace VehicleMaintenance.Console.Models;

public class MaintenanceItem
{
    public string Name { get; set; } = string.Empty;
    public int LastMaintenanceKm { get; set; }
    public int IntervalKm { get; set; }
    public string SuggestedParts { get; set; } = string.Empty;

    public int NextMaintenanceKm => LastMaintenanceKm + IntervalKm;

    public bool IsDue(int currentKm) => currentKm >= NextMaintenanceKm;

    public bool IsNearDue(int currentKm) =>
        currentKm >= NextMaintenanceKm - 500 &&
        currentKm < NextMaintenanceKm;
}
