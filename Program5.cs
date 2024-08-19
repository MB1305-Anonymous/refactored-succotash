using System;

class TemperatureConverter
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Temperature Converter");
            Console.WriteLine("1. Celsius to Fahrenheit");
            Console.WriteLine("2. Fahrenheit to Celsius");
            Console.WriteLine("3. Celsius to Kelvin");
            Console.WriteLine("4. Kelvin to Celsius");
            Console.WriteLine("5. Fahrenheit to Kelvin");
            Console.WriteLine("6. Kelvin to Fahrenheit");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 7)
            {
                break;
            }

            double temperature = 0;
            switch (choice)
            {
                case 1:
                    Console.Write("Enter temperature in Celsius: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Fahrenheit: {CelsiusToFahrenheit(temperature)}");
                    break;
                case 2:
                    Console.Write("Enter temperature in Fahrenheit: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Celsius: {FahrenheitToCelsius(temperature)}");
                    break;
                case 3:
                    Console.Write("Enter temperature in Celsius: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Kelvin: {CelsiusToKelvin(temperature)}");
                    break;
                case 4:
                    Console.Write("Enter temperature in Kelvin: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Celsius: {KelvinToCelsius(temperature)}");
                    break;
                case 5:
                    Console.Write("Enter temperature in Fahrenheit: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Kelvin: {FahrenheitToKelvin(temperature)}");
                    break;
                case 6:
                    Console.Write("Enter temperature in Kelvin: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Fahrenheit: {KelvinToFahrenheit(temperature)}");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    static double CelsiusToKelvin(double celsius)
    {
        return celsius + 273.15;
    }

    static double KelvinToCelsius(double kelvin)
    {
        return kelvin - 273.15;
    }

    static double FahrenheitToKelvin(double fahrenheit)
    {
        return CelsiusToKelvin(FahrenheitToCelsius(fahrenheit));
    }

    static double KelvinToFahrenheit(double kelvin)
    {
        return CelsiusToFahrenheit(KelvinToCelsius(kelvin));
    }
}
