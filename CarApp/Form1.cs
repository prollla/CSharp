using System;
using System.Windows.Forms;

namespace CarApp
{
    public partial class Form1 : Form
    {
        private TextBox txtBrand;
        private TextBox txtPower;
        private TextBox txtSeats;
        private TextBox txtYear;
        private Button btnCalculate;
        private Button btnCalculateOld;
        private Label lblResult;
      

        public Form1()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {
            // Создание элементов управления
            txtBrand = new TextBox();
            txtBrand.Location = new System.Drawing.Point(80, 30);
            txtBrand.Size = new System.Drawing.Size(120, 20);

            txtPower = new TextBox();
            txtPower.Location = new System.Drawing.Point(80, 70);
            txtPower.Size = new System.Drawing.Size(120, 20);

            txtSeats = new TextBox();
            txtSeats.Location = new System.Drawing.Point(80, 110);
            txtSeats.Size = new System.Drawing.Size(120, 20);

            txtYear = new TextBox();
            txtYear.Location = new System.Drawing.Point(80, 150);
            txtYear.Size = new System.Drawing.Size(120, 20);
            btnCalculate = new Button();
            btnCalculate.Location = new System.Drawing.Point(80, 230);
            btnCalculate.Text = "Calculate";
            btnCalculate.Click += BtnCalculate_Click;

            btnCalculateOld = new Button();
            btnCalculateOld.Location = new System.Drawing.Point(180, 230);
            btnCalculateOld.Text = "Calculate";
            btnCalculateOld.Click += BtnCalculateOld_Click;
            
            lblResult = new Label();
            lblResult.Location = new System.Drawing.Point(80, 270);
            lblResult.Size = new System.Drawing.Size(120, 20);

            // Добавление элементов управления на форму
            this.Controls.Add(txtBrand);
            this.Controls.Add(txtPower);
            this.Controls.Add(txtSeats);
            this.Controls.Add(txtYear);
            this.Controls.Add(btnCalculate);
            this.Controls.Add(btnCalculateOld);
            this.Controls.Add(lblResult);
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            // Создание объекта ModernCar и установка свойств
            ModernCar car = new ModernCar();
            car.Brand = txtBrand.Text;
            car.Power = int.Parse(txtPower.Text);
            car.Seats = int.Parse(txtSeats.Text);
            car.Year = int.Parse(txtYear.Text);
            // Вычисление качества и вывод результата на метку
            double quality = car.CalculateQuality();
            lblResult.Text = $"Brand: '{car.Brand}' Quality:{quality}";
        }
        private void BtnCalculateOld_Click(object sender, EventArgs e)
        {
            // Создание объекта ModernCar и установка свойств
            Car car = new Car();
            car.Brand = txtBrand.Text;
            car.Power = int.Parse(txtPower.Text);
            car.Seats = int.Parse(txtSeats.Text);
            // Вычисление качества и вывод результата на метку
            double quality = car.CalculateQuality();
            lblResult.Text = $"Brand: '{car.Brand}' Quality:{quality}";
        }
    }
}
