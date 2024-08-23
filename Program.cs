using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();

                string choice = Choice();
                if (choice == "5")
                {
                    break;
                }
                string name = Name();

                int num1 = Number("Enter water usage last month: ");
                Console.WriteLine("Water usage last month: " + num1 + "m³");
                int num2 = Number("Enter water usage this month: ");
                Console.WriteLine("Water usage this month: " + num2 + "m³");

                if (num1 >= num2)
                {
                    Console.WriteLine("Invalid input. Please try again..!");
                    continue;
                }

                int Consumption;
                Consumption = num2 - num1;
                if (choice == "4")
                {
                    int numpeople = Number("Enter numpeople: ");
                    double m3 = Consumption / numpeople;
                    Console.WriteLine("The average amount of water used by each person is: " + m3 + "m3");
                }
                Console.WriteLine("Water consumption is: " + Consumption + "m³");
                Console.WriteLine("        ");//distance 
                Console.WriteLine("----- PrintBill -----");
                double price = Price(choice, Consumption);
                Console.WriteLine("Total water bill: " + price.ToString("0.000") + " VND");
                double environmentFee = price * 0.1;
                Console.WriteLine("Environment Fee is: " + environmentFee.ToString("0.000") + "VND");

                double VAT = price * 0.1;
                Console.WriteLine("VAT is: " + VAT.ToString("0.000") + " VND");

                double totalBill;
                totalBill = price + VAT + environmentFee;
                Console.WriteLine("Total bill is: " + totalBill.ToString("0.000") + " VND");

                Console.WriteLine("Please press Enter key to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void Menu() //Print out the menu for the user 
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Business services");
            Console.WriteLine("2. Administrative agency, public services");
            Console.WriteLine("3. Production units");
            Console.WriteLine("4. Household");
            Console.WriteLine("5. Exit");
        }
        static string Choice() //User enters selection 
        {
            Console.WriteLine("Enter customer type: ");
            string choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Invalid choice. Please enter a valid option.");
                choice = Console.ReadLine();
            }

            return choice;
        }
        static string Name() // User enters name 
        {
            Console.WriteLine("Enter customer name: ");
            string name = Console.ReadLine();
            return name;
        }
        static int Number(string message) // Enter last month's water number, this month's number, and the number of people in the household (if the user's choice is "4"
        {
            Console.Write(message);
            int num = int.Parse(Console.ReadLine());
            return num;
        }
        static double Price(string choice, int Consumption) // Calculate water bill based on user selection  
        {
            double price = 0;
            switch (choice)
            {
                case "1":
                    price = Consumption * 22.068;
                    break;
                case "2":
                    price = Consumption * 9.955;
                    break;
                case "3":
                    price = Consumption * 11.615;
                    break;
                case "4":
                    if (Consumption <= 10)
                    {
                        price = 5.973 * Consumption;
                    }
                    else if (Consumption <= 20)
                    {
                        price = (10 * 5.973) + (Consumption - 10) * 7.052;
                    }
                    else if (Consumption <= 30)
                    {
                        price = (10 * 5.973) + (10 * 7.052) + (Consumption - 20) * 8.699;
                    }
                    else
                    {
                        price = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + (Consumption - 30) * 15.929;
                    }
                    break;
                case "5":
                    Console.WriteLine("Exit...!");
                    Environment.Exit(0);
                    break;
            }
            return price;
        }
    }
}
