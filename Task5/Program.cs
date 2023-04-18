using System;
using System.Collections.Generic;
public interface IPaper
{
    string Text { get; set; }

    void Write(string text);
    void Clear();
}
public abstract class AbstractPaper : IPaper
{
    public string Text { get; set; }

    protected int NumberOfPages { get; set; }

    protected string PaperType { get; set; }

    public abstract void Write(string text);

    public virtual void Clear()
    {
        Text = "";
    }
    public abstract void AddPage();
}
public class RegularPaper : AbstractPaper
{
    public string Author { get; set; }

    public int Year { get; set; }

    public override void Write(string text)
    {
        Text += text;
    }

    public override void AddPage()
    {
        NumberOfPages++;
    }

    public void SetType(string paperType)
    {
        PaperType = paperType;
    }

    public void Print()
    {
        Console.WriteLine("Text: {0}", Text);
        Console.WriteLine("Number of Pages: {0}", NumberOfPages);
        Console.WriteLine("Type: {0}", PaperType);
        Console.WriteLine("Author: {0}", Author);
        Console.WriteLine("Year: {0}", Year);
    }
}
class Program
{
    static void Main()
    {
        List<IPaper> papers = new List<IPaper>();

        // Создаем экземпляры класса RegularPaper и добавляем их в список
        RegularPaper paper1 = new RegularPaper();
        paper1.SetType("Lined paper");
        paper1.Author = "John Smith";
        paper1.Year = 2021;
        paper1.Write("Hello, world!");
        papers.Add(paper1);

        RegularPaper paper2 = new RegularPaper();
        paper2.SetType("Blank paper");
        paper2.Author = "Jane Doe";
        paper2.Year = 2022;
        paper2.Write("Lorem ipsum dolor sit amet");
        paper2.AddPage();
        paper2.Write(", consectetur adipiscing elit");
        papers.Add(paper2);
        
        foreach (IPaper paper in papers)
        {
            if (paper is RegularPaper)
            {
                RegularPaper regularPaper = (RegularPaper)paper;
                regularPaper.Print();
            }
        }
    }
}
