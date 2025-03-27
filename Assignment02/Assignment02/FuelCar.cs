using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02;

public interface IIFuelable
{
    public void Refuel(DateTime timeOfRefuel);
}
public class FuelCar : Car,IIFuelable
{
    public DateTime TimeOfRefuel { get; set; }
    public void Refuel(DateTime timeOfRefuel)
    {
        TimeOfRefuel = timeOfRefuel;
        Console.WriteLine($"FuelCar {Make} refueled on {timeOfRefuel.ToString("yyyy-MM-dd HH:mm")}");
    }
    public void GetInfoInput()
    {

        DisplayDetails();
        var refuelOptions = Helper.GetInputValidated<char>(label: "Do you want to refuel?:",
                       validateFunc: input => input.IsValidCharacter(new List<char>() { 'Y', 'N' }),
                       strError: "Invalid input! Please enter 'Y' or 'N'");

        if (refuelOptions == 'Y')
        {
            var refuelDate = Helper.GetInputValidated<DateTime>(label: "Enter refuke/charge date and time (yyyy-MM-dd HH:mm):",
                       validateFunc: input => input.IsValidDateFormat("yyyy-MM-dd HH:mm"),
                       strError: "Invalid date format! Please enter a valid date");
            Refuel(refuelDate);
        }
    }

}
