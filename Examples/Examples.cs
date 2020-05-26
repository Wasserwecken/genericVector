using GenericVector;
using System;

namespace Examples
{
    public class Examples
    {
        static void Main()
        {
            Inits();
            BasicArithmetics();
            FloatMath();
            VectorMath();

            Console.ReadKey();
        }

        private static void Inits()
        {
            Console.WriteLine("Initialisations");

            // vector with five dimensions, default value for each axis is 0
            var vector5 = new GVector(5);
            Console.WriteLine(vector5);

            // four dimensional vector with given values for each axis
            var vector4 = new GVector(3f, 5f, 7f, 2f);
            Console.WriteLine(vector4);

            // 3D vector with a default value of 2 for each axis
            var vector3 = new GVector(3, 2f);
            Console.WriteLine(vector3);

            // 2D vector created from a higher dimensional one
            var vector2 = new GVector(2, vector5);
            Console.WriteLine(vector2);
        }

        private static void BasicArithmetics()
        {
            Console.WriteLine("Basic arithmetics");

            var vector3 = new GVector(1f, 2f, 3f);
            var vector2 = new GVector(4f, 5f);

            var resultA = vector2 + vector3;
            Console.WriteLine(resultA);

            var resultB = vector3 - vector2;
            Console.WriteLine(resultB);

            var resultC = vector2 % vector3;
            Console.WriteLine(resultC);
        }

        private static void FloatMath()
        {
            Console.WriteLine("Float math");

            var vector = new GVector(3f, -5f, 7f, -11f, 13f);
            GVector result;

            result = GVector.Sin(vector);
            Console.WriteLine(result);

            result = GVector.Sign(vector);
            Console.WriteLine(result);

            result = GVector.Min(vector, 0f);
            Console.WriteLine(result);
        }

        private static void VectorMath()
        {
            Console.WriteLine("Vector math");

            var vector2 = new GVector(new float[] { 1f, 2f });
            var vector4 = new GVector(new float[] { 3f, 4f, 5f, 6f });
            GVector resultVector;
            float resultFloat;

            resultVector = GVector.ClampToMagnitude(vector2, 0.5f);
            Console.WriteLine(resultVector);

            resultVector = GVector.Lerp(vector4, vector2, 0.5f);
            Console.WriteLine(resultVector);

            resultFloat = GVector.Dot(vector2, vector4);
            Console.WriteLine(resultFloat);

            resultFloat = GVector.Distance(vector4, vector2);
            Console.WriteLine(resultFloat);
        }

        private static void Casting()
        {

        }
    }
}
