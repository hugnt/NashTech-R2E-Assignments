using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02;

public abstract class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public DateTime LastMaintenanceDate { get; set; }

    public DateTime ScheduleMaintenance()
    {
        return LastMaintenanceDate.AddMonths(6);
    }

    public void DisplayDetails()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Car:").Append(Make).Append($"({Year})");
        sb.AppendLine("Last Maintenance:").Append(LastMaintenanceDate.ToString("yyyy-MM-dd"));
        sb.AppendLine("Next Maintenance:").Append(ScheduleMaintenance().ToString("yyyy-MM-dd"));

    }

}
