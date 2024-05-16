// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

class calculator
{
     public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value is "not a number" if an operation, such as division, could result in an error.
        
        //Use the switch statement to do the math.
        switch (op)
        {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                // Ask the user to enter a non zero divisior.
                if(num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }

}

class program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        // Display title of the console calculator app.
        Console.WriteLine("C# Console Calculator\r");
        Console.WriteLine("-----------------------\n");
        while (!endApp)
        {
            //Declare variables and the set to empty
            //Use Nullable types (with ?) to match type of system.console.readline
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            //Ask the user to type the first number.
            Console.WriteLine("Type a number and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("this is not valid input. please enter an integer value:");
                numInput1 = Console.ReadLine();

            }
            //Ask the user to type the second number 
            Console.WriteLine("Type another number and then press Enter: ");
            numInput2 = Console.ReadLine();
            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("this is not valid input, please enter an integer value: ");
                numInput2 = Console.ReadLine();

            }
            //Ask the user to choose an option
            Console.WriteLine("Choose an operator from the following list: ");
            Console.WriteLine("\ta - add");
            Console.WriteLine("\ts - subtract");
            Console.WriteLine("\tm - multiply");
            Console.WriteLine("\td - divide");

            string? op = Console.ReadLine();

            // Validate input is not null, and matches the pattern.
            if (op == null || ! Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("ERROR: Unrecognized input. ");
            }
            else
            {
                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);

                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                    
                }
                catch (Exception e )
                {
                    Console.WriteLine("oh no! An exception occurred trying to do the math.\n - Details: " + e. Message);
                }
            }
            Console.WriteLine("------------------------------\n");
            // Wait for the user to respond before closing
            Console.Write("press 'n' and Enter to close the app or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Friendly linespacing.
        }
        return;
    }
}






