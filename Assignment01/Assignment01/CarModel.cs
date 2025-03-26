using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01;

class CarModel
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public CarType Type { get; set; }

    public void SetInfoByConsole()
    {
        Console.WriteLine("Enter car type (Fuel/Electric):");
        getCarTypeConsole();
        Console.WriteLine("Enter Make:");
        getMakeConsole();
        Console.WriteLine("Enter Model:");
        getModelConsole();
        Console.WriteLine("Enter Year:");
        getYearConsole();
    }
    private void getMakeConsole()
    {
        var isValidCast = true;
        do
        {
            var makeInput = Console.ReadLine();
            isValidCast = makeInput != null && makeInput.Trim() != "";
            if (!isValidCast) Console.Write("Car name not valid!, Enter type again: \n");
            else Make = makeInput;
        }
        while (!isValidCast);
    }

    private void getModelConsole()
    {
        var isValidCast = true;
        do
        {
            var modelInput = Console.ReadLine();
            isValidCast = modelInput != null && modelInput.Trim() != "";
            if (!isValidCast) Console.Write("Car model not valid!, Enter type again: \n");
            else Model = modelInput;
        }
        while (!isValidCast);
    }

    private void getCarTypeConsole()
    {
        var isValidCast = true;
        do
        {
            var typeInput = Console.ReadLine();
            isValidCast = Enum.TryParse(typeInput, out CarType carType);

            if (!isValidCast) Console.Write("Car type not match!, Enter car type again: \n");
            else Type = carType;
        }
        while (!isValidCast);
    }

    private void getYearConsole()
    {
        var isValidCast = true;
        do
        {
            isValidCast = int.TryParse(Console.ReadLine(), out int yearInput);
            if (yearInput < 0) isValidCast = false;
            if (!isValidCast) Console.Write("Year is not valid!, Enter year again: \n");
            else Year = yearInput;
        }
        while (!isValidCast);
    }

    public override string? ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Make: {Make} | Model: {Model} | Year: {Year} | Type: {Enum.GetName(Type.GetType(), Type)}");
        return sb.ToString();
    }
}
