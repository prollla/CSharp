using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "+input.txt";
        string outputFile = "output.txt";
        int rows = 10;

        // Генерация случайного текстового файла
        using (StreamWriter writer = new StreamWriter(inputFile))
        {
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                int num1 = random.Next(1, 10);
                int num2 = random.Next(1, 10);
                int num3 = random.Next(1, 10);
                writer.WriteLine($"{num1,-5} | {num2,5} | {num3,-5}");
            }
        }

        // Решение задачи
        using (StreamReader reader = new StreamReader(inputFile))
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                int sum = 0;
                foreach (string part in parts)
                {
                    int number;
                    if (int.TryParse(part, out number))
                    {
                        sum += number;
                    }
                }
                writer.WriteLine(sum);
            }
        }

        Console.WriteLine($"Файл {inputFile} сгенерирован, файл {outputFile} создан.");
    }
}