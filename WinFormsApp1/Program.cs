// Класс Car

using CarApp;
using System;
using System.Windows.Forms;

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