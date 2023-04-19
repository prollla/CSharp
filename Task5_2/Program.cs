using System;
using System.Collections.Generic;

public interface IPaper
{
    int NumberOfPages { get; set; }
    void Write(string text);
    void AddPage();
}

public abstract class Notebook : IPaper
{
    public int NumberOfPages { get; set; }
    public string Size { get; set; }
    public bool IsSpiralBound { get; set; }

    public abstract void Write(string text);
    public abstract void AddPage();
    public void Clear()
    {
        // Реализация очистки страниц
    }
}

public class NotebookForDrawing : Notebook
{
    public string PaperType { get; set; }
    public bool HasGrid { get; set; }

    public override void Write(string text)
    {
        // Реализация для зарисовки
    }

    public override void AddPage()
    {
        // Реализация добавления новой страницы для зарисовки
    }

    public void Erase()
    {
        // Реализация очистки зарисовок
    }

    public void DrawGrid()
    {
        // Реализация добавления сетки для зарисовок
    }
}

public class Program
{
    public static void Main()
    {
        List<IPaper> papers = new List<IPaper>();

        // Добавляем объекты в список
        papers.Add(new NotebookForDrawing() { NumberOfPages = 50, Size = "A4", IsSpiralBound = true });
        papers.Add(new NotebookForDrawing() { NumberOfPages = 100, Size = "A5", IsSpiralBound = false });

        // Выполняем действия с каждым объектом в списке
        foreach (IPaper paper in papers)
        {
            {
                paper.Write("Hello, world!");
                paper.AddPage();
            }
        }
    }
}