using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace Prog6221_POE
{
    internal class Recipe
    {


        //Variables
        public int ingNum;
        public string[] ingName = new string[1];
        public double[] ingQuant = new double[1];
        public double[] ScalQuant = new double[1];
        public string[] ingUoM = new string[1];
        public string[] ScalUoM = new string[1];
        public int Step = 0;
        public string[] StepDetail = new string[1];
        public double recScale;
        Scaling scal = new Scaling();


        public void setIngNum(int inp)
        {
            ingNum = inp;
            ingName = new string[ingNum + 1];
            ingQuant = new double[ingNum + 1];
            ScalQuant = new double[ingNum + 1];
            ingUoM = new string[ingNum + 1];
            ScalUoM = new string[ingNum + 1];
        }

        public void setIngDetails(string ingname, double ingquan, string inguom, int index)
        {
            //creates ingredient arrays to length of number of ingredients
            ingName[index] = ingname;
            ingQuant[index] = ingquan;
            ingUoM[index] = inguom;
        }

        public void setSteps(int num)
        {
            Step = num;
            StepDetail = new string[num];
        }

        public void setDesc(string inp, int index)
        {
            StepDetail[index] = inp;
        }

        public void PrintRecipe()
        {
            WriteLine("Ingredients: ");
            for (int i = 0; i < ingNum; i++)
            {
                //scale check
                (ScalQuant[i], ScalUoM[i]) = scal.CheckScale(ingQuant[i], ingUoM[i], recScale);
                
                //format and print
                if ((ScalQuant[i] > 1) && (ScalUoM[i] == "cup"))
                {
                    ScalUoM[i] = "cups";
                }
                if ((ScalUoM[i] == "cup") || (ScalUoM[i] == "cups"))
                {
                    WriteLine(ScalQuant[i] + " " + ScalUoM[i] + " of " + ingName[i]);
                }
                else
                {
                    WriteLine(ScalQuant[i] + ScalUoM[i] + " of " + ingName[i]);
                }
            }
            //print steps
            WriteLine("");
            WriteLine("Method:");
            for (int j = 0; j < Step; j++)
            {
                WriteLine((j + 1) + ": " + StepDetail[j]);
            }
            WriteLine("");

        }

        public void setScale(string scale)
        {
            //checks inputted value and converts scale variable to correspond
            switch (scale.ToLower())
            {
                case "half":
                case "a":
                    {
                        recScale = 0.5;
                        break;
                    }

                case "double":
                case "b":
                    {
                        recScale = 2;
                        break;
                    }

                case "triple":
                case "c":
                    {
                        recScale = 3;
                        break;
                    }
                default:
                    {
                        recScale = 1;
                        break;
                    }
            }
        }

        public void resetScale()
        {
            //sets scale to original scale and reprints recipe
            recScale = 1;
            PrintRecipe();
        }

        public void ClearArrays()
        {
            //resets all values to 'factory setting'
            Array.Clear(ingName, 0, ingName.Length);
            Array.Clear(ingQuant, 0, ingQuant.Length);
            Array.Clear(ingUoM, 0, ingUoM.Length);
            Array.Clear(StepDetail, 0, StepDetail.Length);
            ingNum = 0;
            recScale = 1;
            Step = 0;


        }




    }
}
