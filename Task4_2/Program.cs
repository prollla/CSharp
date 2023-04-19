// Класс Car
class Car
{
    // Свойства автомобиля
    public string Brand { get; set; }
    public int Power { get; set; }
    public int Seats { get; set; }
    public int Quality { get; set; }

    // Конструктор для инициализации свойств
    public Car(string brand, int power, int seats)
    {
        Brand = brand;
        Power = power;
        Seats = seats;
        Quality = CalculateQuality();
    }

    // Функция расчета качества автомобиля
    public int CalculateQuality()
    {
        return (int)(0.1 * Power * Seats);
    }
}

// Класс CarWithYear, наследуется от класса Car
class CarWithYear : Car
{
    // Дополнительные свойства автомобиля
    public int Year { get; set; }
    public int CurrentYear { get; set; }

    // Конструктор для инициализации свойств
    public CarWithYear(string brand, int power, int seats, int year, int currentYear) : base(brand, power, seats)
    {
        Year = year;
        CurrentYear = currentYear;
        RecalculateQuality();
    }

    // Функция перерасчета качества автомобиля
    public void RecalculateQuality()
    {
        double newQuality = CalculateQuality() - 1.5 * (CurrentYear - Year);
        Quality = (int)Math.Max(newQuality, 0);
    }
}

class Program
{
    static void Main()
    {
// Создание объекта автомобиля
Car myCar = new Car("Toyota", 120, 5);

// Вывод свойств автомобиля
Console.WriteLine("Марка: " + myCar.Brand);
Console.WriteLine("Мощность: " + myCar.Power + " л.с.");
Console.WriteLine("Количество мест: " + myCar.Seats);
Console.WriteLine("Качество: " + myCar.Quality);

// Создание объекта автомобиля с годом изготовления
CarWithYear myCarWithYear = new CarWithYear("Ford", 150, 4, 2015, 2023);

// Вывод свойств автомобиля с годом изготовления
Console.WriteLine("Марка: " + myCarWithYear.Brand);
Console.WriteLine("Мощность: " + myCarWithYear.Power + " л.с.");
Console.WriteLine("Количество мест: " + myCarWithYear.Seats);
Console.WriteLine("Год изготовления: " + myCarWithYear.Year);
Console.WriteLine("Текущий год: " + myCarWithYear.CurrentYear);
Console.WriteLine("Качество: " + myCarWithYear.Quality);

// Изменение текущего года и перерасчет качества автомобиля
myCarWithYear.CurrentYear = 2025;
myCarWithYear.RecalculateQuality();
Console.WriteLine("Новое качество: " + myCarWithYear.Quality);

    }
};