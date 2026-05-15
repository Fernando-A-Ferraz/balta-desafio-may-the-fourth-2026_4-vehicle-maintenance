using VehicleMaintenance.Console.Services;

Console.Title = "Vehicle Maintenance - May The Fourth 2026";

ExibirCabecalho();

var vehicleService = new VehicleMaintenanceService();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("🚗 Informe a quilometragem atual do veículo: ");
Console.ResetColor();

var mileageInput = Console.ReadLine() ?? string.Empty;

var maintenances = vehicleService
    .CheckMaintenances(mileageInput);

Console.WriteLine();

if (maintenances.Count == 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("✅ Nenhuma manutenção necessária no momento.");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("⚠️ Sua atenção é necessária!");
    Console.WriteLine("As seguintes manutenções precisam ser verificadas:");
    Console.ResetColor();

    foreach (var item in maintenances)
    {
        Console.WriteLine();

        Console.WriteLine($"🔧 {item.Name}");
        Console.WriteLine($"📍 Quilometragem ideal: {item.NextMaintenanceKm:N0} km");
        Console.WriteLine($"🚘 Quilometragem atual: {vehicleService.CurrentKm:N0} km");
        Console.WriteLine($"🛒 Peças sugeridas: {item.SuggestedParts}");

        if (item.IsDue(vehicleService.CurrentKm))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Manutenção vencida!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️ Manutenção próxima.");
        }

        Console.ResetColor();
    }
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Pressione qualquer tecla para encerrar...");
Console.ResetColor();
Console.ReadKey();

static void ExibirCabecalho()
{
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine("======================================");
    Console.WriteLine(" 🌌 MAY THE FOURTH 2026");
    Console.WriteLine("  VEHICLE MAINTENANCE");
    Console.WriteLine("======================================");

    Console.ResetColor();
    Console.WriteLine();
}