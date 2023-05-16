namespace Task6_2;
public interface IInsuranceCompany
{
    void PayOutCompensation(object source, EventArgs args);
}

public class Rocket
{
    public delegate void RocketLaunchEventHandler(object source, EventArgs args);
    public event RocketLaunchEventHandler Launched;

    public delegate void RocketCrashEventHandler(object source, EventArgs args);
    public event RocketCrashEventHandler Crashed;

    public async Task Launch()
    {
        await Task.Run(() =>
        {
            OnLaunched();
        });
    }

    protected virtual void OnLaunched()
    {
        if (Launched != null)
        {
            Launched(this, EventArgs.Empty);
        }
    }

    public async Task Crash()
    {
        await Task.Run(() =>
        {
            OnCrashed();
        });
    }

    protected virtual void OnCrashed()
    {
        if (Crashed != null)
        {
            Crashed(this, EventArgs.Empty);
        }
    }
}

public class Astronaut
{
    public void EnterSpace(object source, EventArgs args)
    {
        MessageBox.Show("Astronaut has entered space...");
    }
}

public class InsuranceCompany : IInsuranceCompany
{
    public void PayOutCompensation(object source, EventArgs args)
    {
        MessageBox.Show("Insurance company is paying compensation...");
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