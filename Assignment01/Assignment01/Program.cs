using System.Reflection;
using System.Text;

namespace Assignment01
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            var menuStr = "Menu: \n1.Add a Car \n2.View All Cars \n3.Search Car by Make \n4.Filter Cars by Type \n5.Remove a Car by Model \n6.Exit";
            Console.WriteLine(menuStr);
            var menu = new MenuModel();
            menu.Start();
        }

    }

   

   

}
