using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01;

class MenuModel
{
    private List<CarModel> lstCars;

    public void Start()
    {
        lstCars = new();
        var choice = "-1";
        do
        {
            Console.WriteLine("[Menu] Enter your choice:");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                var newCar = new CarModel();
                newCar.SetInfoByConsole();
                addCar(newCar);
            }
            else if (choice == "2")
            {
                Console.WriteLine("List of cars:");
                foreach (var car in lstCars)
                {
                    Console.WriteLine(car.ToString());
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter keyword: (Searching by Make)");
                var keyWord = Console.ReadLine();
                var lstResults = lstCars.Where(x => x.Make.Contains(keyWord.Trim()));
                if (lstResults == null)
                {
                    Console.WriteLine("Cars not found");
                    continue;
                }
                Console.WriteLine("Results:");
                foreach (var car in lstResults)
                {
                    Console.WriteLine(car.ToString());
                }

            }
            else if (choice == "4")
            {
                Console.WriteLine("Enter type: (Fuel/Electric)");
                var isValidCast = Enum.TryParse(Console.ReadLine(), out CarType carType);
                if (!isValidCast)
                {
                    Console.WriteLine("Car type not match!");
                    continue;
                }
                var lstResults = lstCars.Where(x => x.Type == carType);
                if (lstResults == null)
                {
                    Console.WriteLine("Cars not found");
                    continue;
                }
                Console.WriteLine("Results:");
                foreach (var car in lstResults)
                {
                    Console.WriteLine(car.ToString());
                }
            }
            else if (choice == "5")
            {
                if (lstCars.Count() == 0)
                {
                    Console.WriteLine("No cars in the list!");
                    continue;
                }
                Console.WriteLine("Enter car model:");
                var model = Console.ReadLine();
                var selectedCar = lstCars.Where(x => x.Model == model.Trim()).FirstOrDefault();
                if (selectedCar == null)
                {
                    Console.WriteLine("Cars not found");
                    continue;
                }
                lstCars.Remove(selectedCar);
                Console.WriteLine("Deleted successfully!:");

            }
            else if (choice == "6")
            {
                return;
            }
            else
            {
                Console.WriteLine("Option not found!");
            }

        } while (choice != "6");
    }

    private void addCar(CarModel newCar)
    {
        if (lstCars.Any(x => x.Model == newCar.Model))
        {
            Console.WriteLine("Car model has been exist!");
            return;
        }
        lstCars.Add(newCar);
        Console.WriteLine("Car added successfully!");
    }


}
