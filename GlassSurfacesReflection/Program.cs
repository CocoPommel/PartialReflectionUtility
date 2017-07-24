using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassSurfacesReflection
{
    class Program
    {
        static List<double> distances = new List<double>();
        static bool cont = true;
        public static double[] ROYGBV = {640.0, 605.0, 587.0, 534.0, 478.0, 427.0};
        public static string[] colors = {"RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "VIOLET" };

        static void Main(string[] args)
        {
            Console.WriteLine("Calculate for individual surfaces 'i' or successive surfaces 's'? (defaults to successive)"); 
            String mode = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter distance to next surface, or 'calc' to calculate reflections:"); //parse in distances between glass plates
                String input = Console.ReadLine();
                if(input == "calc")
                {
                    cont = false;
                } else
                {
                    distances.Add(Double.Parse(input));
                }
            } while (cont);

            if (mode.Equals("i"))
            {
                SingleSurface.calculate(distances); //calculate for a bunch of individual surfaces if so desired
            }

            double[] colorper = { 1, 1, 1, 1, 1, 1, 1 };

            for (int i = 0; i < distances.Count(); i++)
            {
                for (int j = 0; j < ROYGBV.Length; j++) //calculate reflection % for each visible color
                {
                    colorper[j] *= SingleSurface.partial(distances[i], ROYGBV[j]); //compound the probability with previous probabilities of that color reflecting
                }
            }

            Console.WriteLine("");
            for (int j = 0; j < colorper.Length; j++) //calculate reflection % for each visible color
            {
                Console.WriteLine(Program.colors[j] + ": " + (colorper[j] * 100) + "% reflection"); //output result times 100 to get percentage
            }

            Console.WriteLine("Press any key to exit"); //congratulations you've gone done a science
            Console.ReadKey();
        }
    }
}