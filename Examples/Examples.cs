using GenericVector;
using System;

namespace Examples
{
    public class Examples
    {
        static void Main()
        {
            Inits();

            Console.ReadKey();
        }


        private static void Inits()
        {
            // vector with five dimensions
            var vector5 = new GVector(5);

            // four dimensional vector with given values for each axis
            var vector42 = new GVector(3f, 5f, 7f, 2f);

            // 3D vector width a default value 0.5 for each axis
            var vector3 = new GVector(3, 0.5f);

            //2D vector created from a higher dimensional one
            var vector2 = new GVector(2, vector5);
        }
    }
}
