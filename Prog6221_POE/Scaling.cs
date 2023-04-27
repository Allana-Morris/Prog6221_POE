using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Prog6221_POE
{
    //Scale Conversion Library
    internal class Scaling
    {
        // 1 tablespoon = 15ml
        // 1 teaspoon = 5ml
        // 1 cup = 250ml
        // 1/2 cup = 125ml
        // 1/3 cup = 80ml
        // 1/4 cup = 60ml

        // 16 tablespoons = 1 cup
        //8 tablespoons = 1/2 cup
        //4 tablespoon = 1/4 cup
        
        public (double, string) CheckScale(double quan, string uom, double scal)
        {
            double retrn;
            int quantScal = (int)(Round(quan * scal));


            switch (uom)
            {
                case "teaspoon":
                case "teaspoons":
                case "tsp":
                    {
                        if (quantScal % 3 == 0)
                        {
                            int tbsp = quantScal / 3;
                            return(tbsp, "tbsp");
                        }
                        else
                        {

                        }
                        break;
                    } 

                case "tablespoon":
                case "tablespoons":
                case "tbsp":
                    {
                        if ((quantScal % 4) == 0)
                        {
                            int mul = quantScal / 4;
                            retrn = mul * 0.25;
                            return (retrn, "cup");
                        }
                        else
                        {

                        }
                        break;

                    }

                case "cup":
                case "cups":
                    {
                        break;
                    }

                case "ml":
                case "milliliter":
                case "millilitre":
                case "milliliters":
                case "millilitres":
                    {
                        switch (quantScal)
                        {
                            case 250:
                                {
                                    return (1, "cup");
                                    
                                }
                            case 160:
                                {
                                    return (2 / 3, "cup");
                                    
                                }
                            case 125:
                                {
                                    return (1 / 2, "cup");
                                }
                            case 80:
                                {
                                    return (1 / 3, "cup");
                                }
                            case 60:
                                {
                                    return (1 / 4, "cup");
                                }
                            default:
                                break;
                        }
                        break;
                    }

                case "mg":
                case "milligram":
                case "milligrams":
                    {
                        if (quantScal > 1000)
                        {
                            return ((quantScal / 1000), "g");
                        }
                        break;
                    }

                case "g":
                case "gram":
                case "grams":
                    {
                        if (quantScal < 1)
                        {
                            return ((quantScal * 1000), "mg");
                        }
                        break;
                    }





            }

            return (quantScal, uom);

        }
    }
}







