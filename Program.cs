namespace Sweet__n__Salty_Challenge;
class Program
{
/* Sweet ‘n Salty .NET console application 
Summary: 

The Sweet and Salty Console Application prints numbers to the console screen starting at a number specified by the user and stopping at a number specified by the user.  
The range of the two numbers is limited to 1000.  
The quantity of numbers printed per line is also decided by the user with a maximum of 30. 
The application will print “Sweet” instead of any number that is a multiple of 3. 
The application will print “Salty” instead of any number that is a multiple of 5. 
The application will print “Sweet’nSalty” instead of any number that is a multiple of both 3 and 5. 
The application prints a summary after completing the printout.
*/

    /// <summary>
    /// Main method where the program begins
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {   
        /// <summary>
        /// try block to see if any System.FormatException is caught by users inputing non-integer data
        /// </summary>
        /// <value></value>
        try
        {
            
        /// <summary>
        /// Boolean value to check if inputs are valid and set the do-while loop. Int values to print for the summary at the end that are incremeneted in the for loop.
        /// </summary>
        bool invalidInput = true;
        int sns = 0;
        int salty = 0;
        int sweet = 0;
        
        /// <summary>
        /// Beginning of do-while loop
        /// </summary>
        /// <value></value>
        do 
        {
        
        System.Console.WriteLine("Enter a number (higher than zero and lower than 1000) at which to start: ");
        /// <summary>
        /// Nullable operator on string data type for the user input read line, which is then parsed to an integer as the start point
        /// </summary>
        /// <returns>integer</returns>
        string? strStart = Console.ReadLine()!.Trim();
        int start = Int32.Parse(strStart);

        System.Console.WriteLine("Enter a number (higher than the start number) at which to stop: ");
        /// <summary>
        /// Nullable operator on string data type for the user input read line, which is then parsed to an integer as the stop point
        /// </summary>
        /// <returns>integer</returns>
        string? strStop = Console.ReadLine()!.Trim();
        int stop = Int32.Parse(strStop);

        /// <summary>
        /// Input validation to check that the difference between the start and stop values is not greater than 1000, and that the stop point is a greater number than the start point
        /// </summary>
        /// <param name="stop"></param>
        /// <returns>A string to tell the user their input was wrong</returns>
        if (stop - start > Math.Abs(1000) || start > stop)
        {
            /// <summary>
            /// Switches the boolean for an invalid input to true and outputs a message to the console to inform the user
            /// </summary>
            invalidInput = true;
            System.Console.WriteLine("Invalid input, please try again");

        } 
        else
        {
            /// <summary>
            /// Switches the boolean to false for an invalid input
            /// </summary>
            invalidInput = false;

            /// <summary>
            /// Creates a variable to find the difference between the stop and start point
            /// </summary>
            int difference = stop - start;

            /// <summary>
            /// Instantiates a list and adds a value to the list until the numbers reach the stop point number
            /// </summary>
            /// <typeparam name="int"></typeparam>
            /// <returns>A list of integers</returns>
            List<int> rangeList = new List<int>();
                for (int i = 0; i <= difference; i++)
                {
                    rangeList.Add(i);
                }

            System.Console.WriteLine("Enter how many numbers (5-30) to display on each line: ");

            /// <summary>
            /// Nullable operator on string data type for the user input read   line, which is then parsed to an integer as the number of numbers to display before a line break
            /// </summary>
            /// <returns>integer</returns>
            string? strNumsToDisplay = Console.ReadLine()!.Trim();
            int numsToDisplay = Int32.Parse(strNumsToDisplay);
            
            // If-Else statement to check that the number of numbers to display is between 5 and 30
            if (numsToDisplay > 30 || numsToDisplay < 5)
            {
                /// <summary>
                /// Switches the boolean value for an invalid input to true and informs the user that their input was incorrect
                /// </summary>
                invalidInput = true;
                System.Console.WriteLine("Out of range. Please enter a number between 5 and 30");

            }
            else
            {
                /// <summary>
                /// Switches the boolean value for an invalid input to false
                /// </summary>
                invalidInput = false;

                /// <summary>
                /// Declares a variable to count how many numbers are printed and assigns it to 0
                /// </summary>
                int numbersPrinted = 0;

                // For Loop to iterate over the integer list from earlier
                for (int i = 1; i <= rangeList.Count; i++)
                {
                // Checks if the number of numbers printed is equal to the value the user desired and if so, creates a new line and sets the counter to 0
                if (numbersPrinted == numsToDisplay)
                {
                    System.Console.Write("\n");
                    numbersPrinted = 0;
                }
                // Checks to make sure 0 is printed as an integer and not included in the modulo operations
                else if (i == 0)
                {
                    numbersPrinted++;
                    System.Console.Write(0);
                }
                // Checks to see if the iterated number is divisible by 3 and not divisible by 5 and increments both numbersPrinted and the final tally of "Sweet" statments
                else if (i % 3 == 0 && i % 5 != 0)
                {
                    numbersPrinted++;
                    System.Console.Write(" " + "Sweet");
                    sweet ++;
                }
                // Checks to see if the iterated number is divisible by 5 and not divisible by 3 and increments both numbersPrinted and the final tally of "Salty" statments
                else if (i % 5 == 0 && i % 3 != 0)
                {
                    numbersPrinted++;
                    System.Console.Write(" " + "Salty");
                    salty++;
                }
                // Checks to see if the iterated number is divisible by 3 and divisible by 5 and increments both numbersPrinted and the final tally of "Sweet 'n' Salty" statments
                else if (i % 3 == 0 && i % 5 == 0)
                {
                    numbersPrinted++;
                    System.Console.Write(" " + "Sweet 'n' Salty");
                    sns++;
                }
                // Increments numbersPrinted and outputs the iterated value to the console
                else
                {
                    numbersPrinted++;
                    System.Console.Write(" " + i);
                }
            }
        /// <summary>
        /// Prints the total count of each statment to the console and informs the user how many times each was printed
        /// </summary>
        /// <value></value>
        System.Console.WriteLine($"\"Sweet\" was printed {sweet} times.");
        System.Console.WriteLine($"\"Salty\" was printed {salty} times.");
        System.Console.WriteLine($"\"Sweet 'n' Salty\" was printed {sns} times.");
            }
        }
        }
        // Checks to see if an invalid input was entered and if so, loops the process back to the beginning
        while (invalidInput == true);
        }
        // Catches an invalid input that is of a non-integer value and outputs the error message to the console
        catch (System.FormatException e)
        {
            System.Console.WriteLine($"Error caught: {e.Message}.");
        }
        // Manages resources by exiting the application if an exception is caught
        finally
        {
            Environment.Exit(-1);
        }

}
}