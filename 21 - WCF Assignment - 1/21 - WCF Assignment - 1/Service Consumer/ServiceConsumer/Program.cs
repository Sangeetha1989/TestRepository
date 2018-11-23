using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceConsumer.CalculatorService;

namespace ServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorClient proxy = new CalculatorClient();
            int number1 = 0;
            int number2 = 0;
            Console.WriteLine("Welcome User!!! \n");
            Console.WriteLine("Enter First Number : ");
            number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number : ");
            number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Addition Result : {0}", proxy.DoAdd(number1, number2));
            Console.WriteLine("Subtraction Result : {0}", proxy.DoSubtract(number1, number2));           
            Console.ReadLine();
        }
    }
}
