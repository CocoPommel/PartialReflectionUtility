using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassSurfacesReflection
{
    class Program
    {
        static List<double> distancesBetween = new List<double>();
        static bool cont = true;
        static double[] ROYGBV = {640.0, 605.0, 587.0, 534.0, 478.0, 427.0};
        static string[] colors = {"RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "VIOLET" };
        static double oneSurfaceValue = 0.2;


        static double partial(double distance, double wavelength) //calculates partial reflection given two surfaces. we can assume the first vector is exactly rightward at (0.2, 0) because only the differences between the vectors matter.
        {
            double t1 = Math.Pow(oneSurfaceValue - oneSurfaceValue * Math.Cos((distance / wavelength) * 2 * Math.PI), 2); //horizontal difference from previous surface using formula 0.2cos(2pi * d/w)
            double t2 = Math.Pow(0 - oneSurfaceValue * Math.Sin((distance / wavelength) * 2 * Math.PI), 2); //vertical difference from previous surface using formula 0.2sin(2pi * d/w)
            return t1 + t2;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Enter distance to next surface, or 'calc' to calculate reflections:"); //parse in distances between glass plates
                String input = Console.ReadLine();
                if(input == "calc")
                {
                    cont = false;
                } else
                {
                    distancesBetween.Add(Double.Parse(input));
                }
            } while (cont);


            for(int i = 0; i < distancesBetween.Count(); i++)
            {
                Console.WriteLine("");
                Console.WriteLine("SURFACE " + i + ":"); //for each surface
                for(int j = 0; j < ROYGBV.Length; j++) //calculate reflection % for each visible color
                {
                    Console.WriteLine(colors[j] + ": " + (partial(distancesBetween[i], ROYGBV[j]) * 100) + "% reflection"); //output result times 100 to get percentage
                }
            }
            Console.WriteLine("Press any key to exit"); //congratulations you've gone done a science
            Console.ReadKey();
        }
    }
}