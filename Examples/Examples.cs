using GenericVector;
using System;
using System.Numerics;

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
            Casting();

            Console.ReadKey();
        }

        private static void Inits()
        {
            Console.WriteLine("\nInitialisations");

            var vector5 = new GVector(5);
            Console.WriteLine(vector5);

            var vector4 = new GVector(3f, 5f, 7f, 2f);
            Console.WriteLine(vector4);

            var vector3 = new GVector(3, 2f);
            Console.WriteLine(vector3);

            var vector2 = new GVector(2, vector5);
            Console.WriteLine(vector2);
        }

        private static void BasicArithmetics()
        {
            Console.WriteLine("\nBasic arithmetics");

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
            Console.WriteLine("\nFloat math");

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
            Console.WriteLine("\nVector math");

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
            Console.WriteLine("\nCasting");

            var vector3 = new GVector(3f, 5f, 7f);
            var vector2 = new GVector(1f, 2f);
            GVector resultVector;
            float resultFloat;

            // excludes the third dimension, distance of a 2D perspective
            resultFloat = GVector.Distance(vector2, vector3);
            Console.WriteLine(resultFloat);

            // includes the third dimension, distance of a 3D perspective
            resultFloat = GVector.Distance(vector2.ToDimension(3), vector3);
            Console.WriteLine(resultFloat);


            // AddDimensions recovers lost dimensions
            resultVector = GVector.Lerp(vector2, vector3, 0.5f).AddDimensions(vector3);
            Console.WriteLine(resultVector);

            // downcast to a lower dimension
            resultVector = vector3.ToDimension(2).ToDimension(4);
            Console.WriteLine(resultVector);
        }
    }
}
