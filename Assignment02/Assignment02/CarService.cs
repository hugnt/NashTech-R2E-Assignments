using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02;

public class CarService
{
    public CarService()
    {
        var makeInput = Helper.GetInputValidated<string>(label: "Enter car make:",
                          validateFunc: input => input.IsValidInputString(),
                          strError: "Invalid car make! It must be not null or empty!, Please enter a valid value");

        var modelInput = Helper.GetInputValidated<string>(label: "Enter car model:",
                         validateFunc: input => input.IsValidInputString(),
                         strError: "Invalid car model! It must be not null or empty!, Please enter a valid value");

        var yearInput = Helper.GetInputValidated<int>(label: "Enter car year (e.g., 2000):",
                          validateFunc: input =>
                          {
                              return (int.TryParse(input, out int inputParsed) && inputParsed.IsBetweenNumber(1886, DateTime.Now.Year), inputParsed);
                          },
                          strError: "Invalid year! Please enter a valid year between 1886 and the current year.");

        var lastMaintenanceInputDate = Helper.GetInputValidated<DateTime>(label: "Enter last maintenance date (yyyy-MM-dd):",
                          validateFunc: input => input.IsValidDateFormat("yyyy-MM-dd"),
                          strError: "Invalid date format! Please enter a valid date");

        var carType = Helper.GetInputValidated<char>(label: "Is this a FuelCar or ElectricCar? (F/E):",
                       validateFunc: input => input.IsValidCharacter(new List<char>() { 'F', 'E' }),
                       strError: "Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar");

        if (carType == 'F')
        {
            var fuelCar = new FuelCar()
            {
                Make = makeInput,
                Model = modelInput,
                Year = yearInput,
                LastMaintenanceDate = lastMaintenanceInputDate
            };
            fuelCar.DisplayDetails();
            fuelCar.GetInfoInput();
        }
        else if (carType == 'E')
        {
            var electricCar = new ElectricCar()
            {
                Make = makeInput,
                Model = modelInput,
                Year = yearInput,
                LastMaintenanceDate = lastMaintenanceInputDate
            };
            electricCar.DisplayDetails();
            electricCar.GetInfoInput();
        }

    }
}
