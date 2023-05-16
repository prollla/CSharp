namespace Task6_2;
using System.Windows.Forms;
public partial class Form1 : Form
{
    private Rocket rocket;
    private Astronaut astronaut;
    private InsuranceCompany insuranceCompany;
    private Button launchButton;

    public Form1()
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
