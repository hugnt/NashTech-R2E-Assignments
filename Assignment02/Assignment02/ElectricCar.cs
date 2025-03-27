using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02;

public interface IChargable
{
    public void Charge(DateTime timeOfCharge);
}

public class ElectricCar : Car, IChargable
{
    public DateTime TimeOfCharge { get; set; }

    public void Charge(DateTime timeOfCharge)
    {
        TimeOfCharge = timeOfCharge;
        Console.WriteLine($"ElectricCar {Make} charged on {timeOfCharge.ToString("yyyy-MM-dd HH:mm")}");
    }

    public void GetInfoInput()
    {

        DisplayDetails();
        var chargeOptions = Helper.GetInputValidated<char>(label: "Do you want to charge?:",
                       validateFunc: input => input.IsValidCharacter(new List<char>() { 'Y', 'N' }),
                       strError: "Invalid input! Please enter 'Y' or 'N'");

        if (chargeOptions == 'Y')
        {
            var chargeDate = Helper.GetInputValidated<DateTime>(label: "Enter refuke/charge date and time (yyyy-MM-dd HH:mm):",
                       validateFunc: input => input.IsValidDateFormat("yyyy-MM-dd HH:mm"),
                       strError: "Invalid date format! Please enter a valid date");
            Charge(chargeDate);
        }
    }

}
