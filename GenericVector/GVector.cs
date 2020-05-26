using System;
using System.Globalization;

namespace GenericVector
{
    [Serializable]
    public struct GVector : IFormattable, IEquatable<GVector>
    {
        #region Properties
        public int Dimensions => Axes.Length;
        public float[] Axes { get; }
        public GVector One => new GVector(Dimensions, 1f);
        public GVector Zero => new GVector(Dimensions, 0f);
        public GVector Normalized => this / Magnitude;
        public float Magnitude => (float)Math.Sqrt(MagnitudeSquared);
        public float MagnitudeSquared
        {
            get
            {
                var length = Axes[0];
                for (int i = 1; i < Dimensions; i++)
                    length += Axes[i] * Axes[i];

                return length;
            }
        }
        public float MagnitudeManhattan
        {
            get
            {
                var length = Axes[0];
                for (int i = 1; i < Dimensions; i++)
                    length += Math.Abs(Axes[i]);

                return length;
            }
        }
        #endregion


        #region Indexer
        public float this[int selected]
        {
            get { return Axes[selected]; }
            set { Axes[selected] = value; }
        }
        public GVector this[params int[] selected]
        {
            get
            {
                if (selected.Length > Dimensions)
                    throw new IndexOutOfRangeException("More dimensions selected than the vector has");

                var result = new GVector(selected.Length);
                for (int i = 0; i < selected.Length; i++)
                    result[i] = Axes[selected[i]];
                return result;
            }
            set
            {
                if (selected.Length > Dimensions)
                    throw new IndexOutOfRangeException("More dimensions selected than the vector has");

                for (int i = 0; i < selected.Length; i++)
                    Axes[selected[i]] = value[i];
            }
        }
        #endregion


        #region Constructors
        public GVector(params float[] values)
        {
            Axes = new float[values.Length];
            values.CopyTo(Axes, 0);
        }

        public GVector(GVector vector) : this(vector.Axes)
        {

        }

        public GVector(int dimensions) : this(new float[dimensions])
        {

        }

        public GVector(int dimensions, float value) : this(dimensions)
        {
            for (int i = 0; i < Dimensions; i++)
                Axes[i] = value;
        }

        public GVector(int dimensions, GVector values) : this(dimensions)
        {
            dimensions = Math.Min(Dimensions, values.Dimensions);
            for (int i = 0; i < dimensions; i++)
                Axes[i] = values[i];
        }
        #endregion


        #region Arithmetic
        public static GVector operator +(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA + axisB);

        public static GVector operator +(GVector vector, float value)
            => vector.ForEachAxis(axis => axis + value);

        public static GVector operator +(float value, GVector vector)
            => vector.ForEachAxis(axis => value + axis);


        public static GVector operator -(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA - axisB);

        public static GVector operator -(GVector vector, float value)
            => vector.ForEachAxis(axis => axis - value);

        public static GVector operator -(float value, GVector vector)
            => vector.ForEachAxis(axis => value - axis);


        public static GVector operator *(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA * axisB);

        public static GVector operator *(GVector vector, float value)
            => vector.ForEachAxis(axis => axis * value);

        public static GVector operator *(float value, GVector vector)
            => vector.ForEachAxis(axis => value * axis);


        public static GVector operator /(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA / axisB);

        public static GVector operator /(GVector vector, float value)
            => vector.ForEachAxis(axis => axis / value);

        public static GVector operator /(float value, GVector vector)
            => vector.ForEachAxis(axis => value / axis);


        public static GVector operator %(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA % axisB);

        public static GVector operator %(GVector vector, float value)
            => vector.ForEachAxis(axis => axis % value);

        public static GVector operator %(float value, GVector vector)
            => vector.ForEachAxis(axis => value % axis);


        public static GVector operator -(GVector vector)
            => -1f * vector;

        public static GVector operator ++(GVector vector)
            => vector.ForEachAxis(axis => axis++);

        public static GVector operator --(GVector vector)
            => vector.ForEachAxis(axis => axis--);


        public static bool operator ==(GVector left, GVector right)
            => left.Equals(right);

        public static bool operator !=(GVector left, GVector right)
            => !(left == right);
        #endregion


        #region Float math
        public GVector Abs()
            => ForEachAxis(value => Math.Abs(value));

        public GVector Ceil()
            => ForEachAxis(value => (float)Math.Ceiling(value));

        public GVector Clamp(GVector min, GVector max)
            => ForEachAxis((i, value) => Math.Max(min[i], Math.Min(max[i], value)));

        public GVector Clamp(float min, float max)
            => ForEachAxis(value => Math.Max(min, Math.Min(max, value)));

        public GVector Exp(float ePower)
            => ForEachAxis(value => (float)Math.Exp(ePower));

        public GVector Floor()
            => ForEachAxis(value => (float)Math.Floor(value));

        public GVector Log()
            => ForEachAxis(value => (float)Math.Log(value));

        public GVector Log(GVector newBase)
            => ForEachAxis((i, value) => (float)Math.Log(value, newBase[i]));

        public GVector Log(float newBase)
            => ForEachAxis(value => (float)Math.Log(value, newBase));

        public GVector Min(float min)
            => ForEachAxis(value => Math.Min(value, min));

        public GVector Min(GVector min)
            => ForEachAxis((i, value) => Math.Min(value, min[i]));

        public GVector Max(float max)
            => ForEachAxis(value => Math.Max(value, max));

        public GVector Max(GVector max)
            => ForEachAxis((i, value) => Math.Min(value, max[i]));

        public GVector Pow(GVector power)
            => ForEachAxis((i, value) => (float)Math.Pow(value, power[i]));

        public GVector Pow(float power)
            => ForEachAxis(value => (float)Math.Pow(value, power));

        public GVector Sign()
            => ForEachAxis(value => Math.Sign(value));

        public GVector Sqrt()
            => ForEachAxis(value => (float)Math.Sqrt(value));

        public GVector Truncate()
            => ForEachAxis(value => (float)Math.Truncate(value));

        #region Trigonometry
        public GVector Sin()
            => ForEachAxis(value => (float)Math.Sin(value));

        public GVector Cos()
            => ForEachAxis(value => (float)Math.Cos(value));

        public GVector Tan()
            => ForEachAxis(value => (float)Math.Tan(value));

        public GVector Asin()
            => ForEachAxis(value => (float)Math.Asin(value));

        public GVector Acos()
            => ForEachAxis(value => (float)Math.Acos(value));

        public GVector Atan()
            => ForEachAxis(value => (float)Math.Atan(value));

        public GVector Atan2(GVector other)
            => ForEachAxis((i, value) => (float)Math.Atan2(value, other[i]));

        public GVector Atan2(float other)
            => ForEachAxis(value => (float)Math.Atan2(value, other));
        #endregion
        #endregion


        #region Vector math
        public GVector ClampMagnitude(float max)
            => MagnitudeSquared > max * max ? Normalized * max : this;

        public static float Distance(GVector vectorA, GVector vectorB)
            => (vectorA - vectorB).Magnitude;

        public static float DistanceSquared(GVector vectorA, GVector vectorB)
            => (vectorA - vectorB).MagnitudeSquared;

        public static GVector Lerp(GVector vectorA, GVector vectorB, GVector t)
        {
            var result = new GVector(vectorA);
            var dimensions = Math.Min(t.Dimensions, Math.Min(vectorA.Dimensions, vectorB.Dimensions));
            for (int i = 0; i < dimensions; i++)
                result[i] = (1f - t[i]) * vectorA[i] + t[i] * vectorB[i];

            return result;
        }

        public static GVector Lerp(GVector vectorA, GVector vectorB, float t)
            => ForEachAxis(vectorA, vectorB, (i, valueA, valueB) => (1f - t) * valueA + t * valueB);

        public static GVector Reflect(GVector vector, GVector normal)
            => vector - normal * 2f * Dot(normal, vector);

        public static float Dot(GVector vectorA, GVector vectorB)
        {
            var result = vectorA[0] * vectorB[0];
            var dimensions = Math.Min(vectorA.Dimensions, vectorB.Dimensions);
            for (int i = 1; i < dimensions; i++)
                result += vectorA[i] * vectorB[i];

            return result;
        }

        public GVector MoveTowards(GVector target, float delta)
        {
            var diff = -this + target;
            float magnitude = diff.Magnitude;
            if (magnitude <= delta || delta == 0)
                return new GVector(target);
            return this + diff / magnitude * delta;
        }
        #endregion


        #region ToString
        public override string ToString()
        {
            return ToString(value => value.ToString(CultureInfo.InvariantCulture));
        }

        public string ToString(string format)
        {
            return ToString(value => value.ToString(format));
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return ToString(value => value.ToString(formatProvider));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString(value => value.ToString(format, formatProvider));
        }
        #endregion


        #region Comparision
        public override int GetHashCode()
        {
            return Axes.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is GVector)
                return Equals((GVector)obj);
            else
                return false;
        }

        public bool Equals(GVector other)
        {
            if (other == null || Dimensions != other.Dimensions)
                return false;

            if ((this - other).MagnitudeSquared >= float.Epsilon * float.Epsilon)
                return false;
            else
                return true;
        }
        #endregion


        #region Helper
        public GVector ForEachAxis(Func<float, float> operation)
        {
            return ForEachAxis((i, value) => operation(value));
        }

        public GVector ForEachAxis(Func<int, float, float> operation)
        {
            var result = new GVector(this);
            for (int i = 0; i < result.Dimensions; i++)
                result[i] = operation(i, result[i]);

            return result;
        }

        private static GVector ForEachAxis(GVector vectorA, GVector vectorB, Func<float, float, float> operation)
        {
            return ForEachAxis(vectorA, vectorB, (i, axisA, axisB) => operation(axisA, axisB));
        }

        private static GVector ForEachAxis(GVector vectorA, GVector vectorB, Func<int, float, float, float> operation)
        {
            var result = new GVector(vectorA);
            var dimensions = Math.Min(vectorA.Dimensions, vectorB.Dimensions);
            for (int i = 0; i < dimensions; i++)
                result[i] = operation(i, vectorA[i], vectorB[i]);

            return result;
        }

        public string ToString(Func<float, string> converter)
        {
            var values = new string[Axes.Length];
            for (int i = 0; i < Axes.Length; i++)
                values[i] = converter(Axes[i]);

            return $"({string.Join(", ", values)})";
        }
        #endregion
    }
}
