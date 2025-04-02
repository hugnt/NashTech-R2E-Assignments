using Assignment04_05_MVC.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Reflection;

namespace Assignment04_05_MVC.Common.Helper;

public class FileExport
{
    public static byte[] ExportToExcel<T>(List<T> data, string displayFields)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("ExportData");

            var properties = typeof(T).GetProperties().ToList();

            if (displayFields != "*")
            {
                var fieldsToExport = displayFields.Split(',').Select(f => f.Trim()).ToList();
                properties = properties.Where(p => fieldsToExport.Contains(p.Name)).ToList();
            }

            int colIndex = 1;
            foreach (var property in properties)
            {
                var columnName = FormatColumnName(property.Name);
                worksheet.Cell(1, colIndex).Value = columnName;
                colIndex++;
            }


            int rowIndex = 2;
            foreach (var item in data)
            {
                colIndex = 1;
                foreach (var property in properties)
                {
                    var value = property.GetValue(item);

                    if (value == null)
                    {
                        worksheet.Cell(rowIndex, colIndex).Value = string.Empty;
                    }
                    else
                    {
                        worksheet.Cell(rowIndex, colIndex).Value = value.ToString();
                    }
                    colIndex++;
                }
                rowIndex++;
            }

            // Save the workbook to a memory stream and return it as byte array
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }

    private static string FormatColumnName(string propertyName)
    {
        // Format the column name (e.g., "FirstName" -> "First Name")
        var formattedName = System.Text.RegularExpressions.Regex.Replace(propertyName, @"([a-z])([A-Z])", "$1 $2");
        return formattedName;
    }

}
