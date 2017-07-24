using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassSurfacesReflection
{
    class SingleSurface
    {
        static double oneSurfaceValue = 0.2;

        public static double partial(double distance, double wavelength) //calculates partial reflection given two surfaces. we can assume the first vector is exactly rightward at (0.2, 0) because only the differences between the vectors matter.
        {
            double t1 = Math.Pow(oneSurfaceValue - oneSurfaceValue * Math.Cos((distance / wavelength) * 2 * Math.PI), 2); //horizontal difference from previous surface using formula 0.2cos(2pi * d/w)
            double t2 = Math.Pow(0 - oneSurfaceValue * Math.Sin((distance / wavelength) * 2 * Math.PI), 2); //vertical difference from previous surface using formula 0.2sin(2pi * d/w)
            return t1 + t2;
        }

        public static void calculate(List<double> distances)
        {
            for (int i = 0; i < distances.Count(); i++)
            {
                Console.WriteLine("");
                Console.WriteLine("SURFACE " + i + ":"); //for each surface
                for (int j = 0; j < Program.ROYGBV.Length; j++) //calculate reflection % for each visible color
                {
                    Console.WriteLine(Program.colors[j] + ": " + (SingleSurface.partial(distances[i], Program.ROYGBV[j]) * 100) + "% reflection"); //output result times 100 to get percentage
                }
            }
        }
    }
}