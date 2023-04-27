using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace Prog6221_POE
{
    internal class Program
    {
        public static Recipe rec = new Recipe();

        static void Main(string[] args)
        {
            Recipe();
        }

        public static void Recipe()
        {
            //variables
            int ingnum;
            string ingname;
            double ingquant;
            string inguom = "";
            int numStep;
            string stepDesc;
            string ScaleInput;
            string ResetOrClear;
            string confirm;


            //ask & set Number of ingredients in recipe
            InstructionColour();
            WriteLine("Enter the number of ingredients in recipe: ");
            Undo();
            ingnum = int.Parse(ReadLine());
            rec.setIngNum(ingnum);
            BlankLine();

            //ask & set Ingredients in recipe
            for (int i = 0; i < ingnum; i++)
            {
                //Ingredient Name
                InstructionColour();
                WriteLine("Enter name of ingredient " + (i + 1) + ":");
                Undo();
                ingname = ReadLine();
                while (int.TryParse(ingname, out int z))
                {
                    InstructionColour();
                    WriteLine("Enter name of ingredient " + (i + 1) + ":");
                    Undo();
                }

                //Ingredient Quantity
                InstructionColour();
                WriteLine("Enter quantity of ingredient " + (i + 1) + ":");
                Undo();
                while (!double.TryParse(ReadLine(), out ingquant))
                {
                    InstructionColour();
                    WriteLine("Enter quantity of ingredient " + (i + 1) + ":");
                    Undo();
                }

                //Ingredient Unit of Measurement
                InstructionColour();
                WriteLine("Enter the unit of measurement of ingredient " + (i + 1) + ":");
                Undo();
                inguom = ReadLine().ToLower();
                while (int.TryParse(inguom, out int x))
                {
                    InstructionColour();
                    WriteLine("Enter the unit of measurement of ingredient " + (i + 1) + ":");
                    Undo();
                }

                BlankLine();
                //set ingredients
                rec.setIngDetails(ingname, ingquant, inguom, i);

            }

            //ask & set Number of steps in recipe
            InstructionColour();
            WriteLine("Enter number of steps needed to complete recipe: ");
            Undo();
            while (!int.TryParse(ReadLine(), out numStep))
            {
                InstructionColour();
                WriteLine("Enter number of steps needed to complete recipe: ");
                Undo();
            }
            rec.setSteps(numStep);
            BlankLine();

            //ask & set Steps description
            for (int i = 0; i < numStep; i++)
            {
                InstructionColour();
                WriteLine("Enter instructions need for step " + (i + 1) + ":");
                Undo();
                stepDesc = ReadLine();
                rec.setDesc(stepDesc, i);
            }
            BlankLine();

            //ask & set Scale value for quantities
            InstructionColour();
            WriteLine("Do you want to (a) half (b) double (c) triple (d) not change the recipe:");
            Undo();
            ScaleInput = ReadLine();
            while (int.TryParse(ScaleInput, out int z))
            {
                InstructionColour();
                WriteLine("Enter \'a, b, c or d\' or \'half, double, triple or same\':");
                Undo();
            }
            rec.setScale(ScaleInput);
            BlankLine();

            //print recipe
            rec.PrintRecipe();
            BlankLine();

            //ask about reset or clear
            InstructionColour();
            WriteLine("Would you like to reset quantity scale value or clear recipe?");
            WriteLine("Enter (a) reset or (b) clear: ");
            Undo();
            ResetOrClear = ReadLine().ToLower();
            //testing if value is numerical, not supposed to be
            while (int.TryParse(ResetOrClear, out int z))
            {
                InstructionColour();
                WriteLine("Enter \'a or b\' or \'reset or clear\':");
                Undo();
            }
            switch (ResetOrClear)
            {
                case "a":
                case "reset":
                    {
                        rec.resetScale();
                        break;
                    }
                case "b":
                case "clear":
                    {
                        WriteLine("Are you sure? (yes) or (no)");
                        confirm = ReadLine().ToLower();
                        if (confirm == "yes")
                        {
                            rec.ClearArrays();
                            break;
                        }
                        break;
                    }

            }
            BlankLine();
            //Jumps to final question
            FinQues();
        }

        public static void FinQues()
        {
            string FinAns;
            string confirm;
            string[] args = new string[1];
            bool repeat = false;
            while (repeat)
            {
                InstructionColour();
                WriteLine("Would you like to enter a new recipe or exit?");
                Undo();
                while (int.TryParse(ReadLine(), out int z))
                {
                    InstructionColour();
                    WriteLine("Enter \'new recipe\' or \'exit\':");
                }
                FinAns = ReadLine().ToLower();
                if (FinAns.Equals("exit"))
                {
                    Environment.Exit(0);

                }
                else
                {
                    WriteLine("Are you sure? (yes) or (no)");
                    confirm = ReadLine().ToLower();
                    if (confirm == "yes")
                    {
                        rec.ClearArrays();
                        Main(args);
                    }
                    else if (confirm == "no")
                    {
                        repeat = true;
                    }
                }
            }
        }

        public static void BlankLine()
        {
            WriteLine();
        }

        public static void InstructionColour()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void Undo()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
