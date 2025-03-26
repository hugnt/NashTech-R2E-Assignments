using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01;

class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public CarType Type { get; set; }

    public void GetInfoInput()
    {
        Console.WriteLine("Enter car type (Fuel/Electric):");
        getCarTypeInput();
        Console.WriteLine("Enter Make:");
        getMakeInput();
        Console.WriteLine("Enter Model:");
        getModelInput();
        Console.WriteLine("Enter Year:");
        getYearInput();
    }
    private void getMakeInput()
    {
        var isValidCast = true;
        do
        {
            var makeInput = Console.ReadLine();
            isValidCast = makeInput != null && makeInput.Trim() != "";
            if (!isValidCast) Console.Write("Car make not valid!, Enter type again: \n");
            else Make = makeInput;
        }
        while (!isValidCast);
    }

    private void getModelInput()
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

    private void getCarTypeInput()
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

    private void getYearInput()
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
