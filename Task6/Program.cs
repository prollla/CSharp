using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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

public partial class MainForm : Form
{
    private Rocket rocket;
    private Astronaut astronaut;
    private InsuranceCompany insuranceCompany;
    private Button launchButton;

    public MainForm()
    {
        InitializeComponent();

        rocket = new Rocket();
        astronaut = new Astronaut();
        insuranceCompany = new InsuranceCompany();

        rocket.Launched += astronaut.EnterSpace;
        rocket.Crashed += insuranceCompany.PayOutCompensation;

        // Создание кнопки запуска
        launchButton = new Button();
        launchButton.Text = "Launch Rocket";
        launchButton.Size = new Size(100, 50);
        launchButton.Location = new Point(10, 10);
        launchButton.Click += launchButton_Click;

        // Добавление кнопки на форму
        this.Controls.Add(launchButton);
    }

    private async void launchButton_Click(object sender, EventArgs e)
    {
        Random random = new Random();
        if (random.NextDouble() < 0.1) // 10% вероятность аварии
        {
            await rocket.Crash();
        }
        else
        {
            await rocket.Launch();
        }
    }
}
