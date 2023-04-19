namespace CarApp;
public class Car
{
    public string Brand { get; set; }
    public int Power { get; set; }
    public int Seats { get; set; }

    public double CalculateQuality()
    {
        return 0.1 * Power * Seats;
    }
}

public class ModernCar : Car
{
    public int Year { get; set; }
    public double CalculateQuality()
    {
        double quality = base.CalculateQuality();
        quality = 1.5 * (DateTime.Now.Year - Year);
        return quality;
    }
}
static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}