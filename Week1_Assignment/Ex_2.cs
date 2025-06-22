using System;

// Interface
public interface IDocument
{
    void Open();
}

// Concrete Document Classes
public class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Launching Word Document...");
    }
}

public class PdfDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Launching PDF Document...");
    }
}

public class ExcelDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Launching Excel Document...");
    }
}

// Abstract Factory
public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

// Concrete Factories
public class WordFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

public class PdfFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

public class ExcelFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new ExcelDocument();
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        DocumentFactory wordFactory = new WordFactory();
        IDocument wordFile = wordFactory.CreateDocument();
        wordFile.Open();

        DocumentFactory pdfFactory = new PdfFactory();
        IDocument pdfFile = pdfFactory.CreateDocument();
        pdfFile.Open();

        DocumentFactory excelFactory = new ExcelFactory();
        IDocument excelFile = excelFactory.CreateDocument();
        excelFile.Open();
    }
}

