using VehicleMaintenance.Console.Agents;
using VehicleMaintenance.Console.Models;

namespace VehicleMaintenance.Console.Services;

public class VehicleMaintenanceService
{
    private readonly CsvAgent _csvAgent = new();
    private readonly MileageAgent _mileageAgent = new();
    private readonly MaintenanceAgent _maintenanceAgent = new();

    private static readonly string FilePath =
        Path.Combine(
            AppContext.BaseDirectory,
            "Data",
            "maintenance.csv");

    public int CurrentKm { get; private set; }

    public List<MaintenanceItem> CheckMaintenances(string mileageInput)
    {
        CurrentKm = _mileageAgent.ParseMileage(mileageInput);

        if (CurrentKm <= 0)
            return [];

        var items = _csvAgent.LoadMaintenanceItems(FilePath);

        return _maintenanceAgent.GetDueMaintenances(
            items,
            CurrentKm);
    }
}