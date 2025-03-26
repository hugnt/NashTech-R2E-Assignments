using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01;

class Menu
{
    private List<Car> lstCars;

    public void Start()
    {
        lstCars = new();
        var choice = "-1";
        do
        {
            Console.WriteLine("*****[Menu] Enter your choice:");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                var newCar = new Car();
                newCar.GetInfoInput();
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
                var results = searchCarsByMake(keyWord);
                if (results != null)
                {
                    Console.WriteLine("Results:");
                    foreach (var car in results)
                    {
                        Console.WriteLine(car.ToString());
                    }
                }                

            }
            else if (choice == "4")
            {
                Console.WriteLine("Enter type: (Fuel/Electric)");
                var carTypeInput = Console.ReadLine();
                var results = getCarsByTypeString(carTypeInput);
                if (results != null)
                {
                    Console.WriteLine("Results:");
                    foreach (var car in results)
                    {
                        Console.WriteLine(car.ToString());
                    }
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
                removeCar(model);

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

    private void addCar(Car newCar)
    {
        if (lstCars.Any(x => x.Model == newCar.Model))
        {
            Console.WriteLine("Car model has been exist!");
            return;
        }
        lstCars.Add(newCar);
        Console.WriteLine("Car added successfully!");
    }

    private void removeCar(string model)
    {
        var selectedCar = lstCars.Where(x => x.Model == model.Trim()).FirstOrDefault();
        if (selectedCar == null)
        {
            Console.WriteLine("Cars not found");
            return;
        }
        lstCars.Remove(selectedCar);
        Console.WriteLine("Deleted successfully!:");
    }
 
    private List<Car> searchCarsByMake(string keyWord)
    {
        var lstResults = lstCars.Where(x => x.Make.Contains(keyWord.Trim()));
        if (lstResults == null)
        {
            Console.WriteLine("Cars not found");
            return null;
        }
        return lstResults.ToList();
    }

    private List<Car> getCarsByTypeString(string carTypeString)
    {
        var isValidCast = Enum.TryParse(carTypeString, out CarType carType);
        if (!isValidCast)
        {
            Console.WriteLine("Car type not match!");
            return null;
        }
        var lstResults = lstCars.Where(x => x.Type == carType);
        if (lstResults == null)
        {
            Console.WriteLine("Cars not found");
            return null;
        }
        return lstResults.ToList();
    }


}
