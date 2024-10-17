namespace TempatureComparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int tempsEntered = 5;
            const int tempMin = -30;
            const int tempMax = 130;
            double[] temperatures = new double[tempsEntered];

            for (int i = 0; i < tempsEntered; i++)
            {
                bool isValid = false;
                while (!isValid)
                {
                    Console.Write($"Enter temperature {i + 1} (Fahrenheit between {tempMin} and {tempMax}): ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out double temp) && temp >= tempMin && temp <= tempMax)
                    {
                        temperatures[i] = temp;
                        isValid = true;  
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input '{input}', please enter a temperature within the valid range ({tempMin} to {tempMax}).");
                    }
                }
            }

            bool isAscending = true;
            bool isDescending = true;

            for (int i = 1; i < tempsEntered; i++)
            {
                if (temperatures[i] <= temperatures[i - 1])
                    isAscending = false;
                if (temperatures[i] >= temperatures[i - 1])
                    isDescending = false;
            }


            if (isAscending)
                Console.WriteLine("Getting warmer.");
            else if (isDescending)
                Console.WriteLine("Getting cooler.");
            else
                Console.WriteLine("It’s a mixed bag.");

            Console.WriteLine("\n5-day temperature ");
            for (int i = 0; i < tempsEntered; i++)
            {
                Console.WriteLine($"{temperatures[i]:F1}");
            }


            double total = 0;
            for (int i = 0; i < tempsEntered; i++)
            {
                total += temperatures[i];
            }
            double average = total / tempsEntered;
            Console.WriteLine($"\nAverage temperature is {average:F1}");
        }
    }
}
