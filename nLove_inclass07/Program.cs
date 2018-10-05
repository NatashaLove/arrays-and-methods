using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nLove_inclass07
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = 17;
            Console.WriteLine("Using the ref keyword.");
            Console.WriteLine(DisplayInformation("Main", "before ref", number));
            UseReference(ref number);
            Console.WriteLine(DisplayInformation("Main", "after ref", number));

            Console.WriteLine();
            Console.WriteLine("Using the out keyword.");
            Console.WriteLine(DisplayInformation("Main", "before out", number));
            UseOutParameters(out number);
            Console.WriteLine(DisplayInformation("Main", "after out", number));

            Console.WriteLine();

            Console.WriteLine("Using a built-in out parameter");
            bool doItAgain = true;

            while (doItAgain) {
                Console.WriteLine("Enter a number: ");
                string strAnswer = Console.ReadLine();

                if(Int32.TryParse(strAnswer, out number))
                {
                    Console.WriteLine("{0} is a good number.", strAnswer);
                    doItAgain = false;

                }
                else {
                    Console.WriteLine("{0} is not a valid number.", strAnswer);
                }
             
            }

            Console.WriteLine("Using Parameter Arrays.");
            string[] names = new string[5] {"Mary", "Lilly", "Natasha", "Kevin", "David"};

            DisplayArray(names);
            DisplayArray("George", "Sally", "Misha");
            DisplayArray("Susan");
            DisplayArray("Robert", "Sam");

            Console.WriteLine();

            Console.WriteLine("Overloaded methods.");
            OverloadedMethod(names[0]);
            OverloadedMethod(number);// takes the number from the input: Int32.TryParse(strAnswer, out number) - it is the OUT number (reference)

            Console.WriteLine();
            
            Console.WriteLine("Opional or Default parameters");
            UseDefaultParameters(number, names[0], 8.2, 'b');
            UseDefaultParameters(number, names[1]);
            UseDefaultParameters(number:14, name:"Steffon", letter: 'g');// "number:14, name:"Steffon", letter: 'g' " - how to assign values in methods (i declaration - below - use "=")

            Console.WriteLine();

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }

        //description of methods
        static string DisplayInformation(string method, string timing, int number) {
            
            // String - class ; string - data type
            //the line below - 0 - first char - 15- how many chars to add (spaces!)
            return String.Format("In {0, 15}, {1, 11} change number is {2}.", method, timing, number);
        }
        static void UseReference(ref int number) {
            Console.WriteLine(DisplayInformation("ref Method", "before", number));
            number = 67;
            Console.WriteLine(DisplayInformation("ref Method", "after", number));
        }

        //out - saves the var in memory (reference) - like reference - takes the saved number from reference
        static void UseOutParameters(out int number)
        {
            //can't use not initialized variable
            number = 5;
            Console.WriteLine(DisplayInformation("out Method", "after", number));
        }


        static void DisplayArray(params string[] names) {
            for (int i = 0; i < names.Length; i++)
            {
                // puts "and" before the last word
                if (names.Length >1 && i == names.Length-1)
                {
                    // if it is pre-last item -
                    Console.Write(" and ");
                }
                Console.Write(" {0}", names[i]);

                // puts commas after each word, but for last and prelast - because "and" between them
                if (names.Length > 2 && i !=names.Length-2 && i != names.Length - 1)
                {
                    //if it is not the last or prelast - 
                    Console.Write(", ");
                }

            }

            Console.WriteLine("\n----------------------");

            }

        static void OverloadedMethod(string name) {
            Console.WriteLine("You entered the  name: {0}.", name);
        }

        static void OverloadedMethod(int number) {
            Console.WriteLine("You entered a number: {0}", number);
        }

        static void UseDefaultParameters(int number, string name, double other = 7.955, char letter = 'a') {
            Console.WriteLine("The parameters are {0}, {1}, {2} and {3}.", number, name, other, letter);
        }


    }
}
