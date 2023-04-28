
using Microsoft.Graph;
using System.Globalization;

namespace Projekt_Pudelko
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;

        private readonly UnitOfMeasure unitOfMeasure;

        public double A
        {
            get { return Math.Round(a, 3); }
        }

        public double B
        {
            get { return Math.Round(b, 3); }
        }
        public double C
        {
            get { return Math.Round(c, 3); }
        }
        public double Objetosc
        {
            get { return Math.Round(GetNumberInUnit(a, "m") * GetNumberInUnit(b, "m") * GetNumberInUnit(c, "m"), 9); }
        }
        public double Pole
        {
            get { return Math.Round(2 * GetNumberInUnit(a, "m") * GetNumberInUnit(b, "m") + 2 * GetNumberInUnit(a, "m") * GetNumberInUnit(c, "m") + 2 * GetNumberInUnit(b, "m") * GetNumberInUnit(c, "m"), 6); }
        }
        public Pudelko()
        {
            a = 10;
            b = 10;
            c = 10;

            unitOfMeasure = UnitOfMeasure.centimeter;
        }

        public Pudelko(double a = 10, double b = 10, double c = 10, UnitOfMeasure unitOfMeasure = UnitOfMeasure.meter)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(a > 10 || b > 10 || c > 10 && unitOfMeasure == UnitOfMeasure.meter) // możliwy błąd 
            {
                throw new ArgumentOutOfRangeException();
            }


            this.a = a;
            this.b = b;
            this.c = c;
            this.unitOfMeasure = unitOfMeasure;

        }

        public static explicit operator double[] (Pudelko p)
        {
            double[] result = new double[3];
            result[0] = GetNumberInUnitStatic(p.a, p.unitOfMeasure, "m");
            result[1] = GetNumberInUnitStatic(p.b, p.unitOfMeasure, "m");
            result[2] = GetNumberInUnitStatic(p.c, p.unitOfMeasure, "m");
            return result;
        }

        public static implicit operator Pudelko((double a, double b, double c) result)
        {
            return new Pudelko(result.a, result.b, result.c, UnitOfMeasure.milimeter);
        }

        public double this[int index]
        {
            get
            {
                switch (index) 
                {
                    case 0:
                        return this.a;
                    case 1:
                        return this.b;
                    case 2:
                        return this.c;
                    default:
                        throw new IndexOutOfRangeException();
                }

            }
        }
        private double  GetNumberInUnit(double number, string unitAsString)
        {
            UnitOfMeasure unit = UnitOfMeasure.meter;
            switch (unitAsString)
            {
                case "mm":
                    unit = UnitOfMeasure.milimeter;
                    break;
                case "cm":
                    unit = UnitOfMeasure.centimeter;
                    break;
                case "m":
                    unit = UnitOfMeasure.meter;
                    break;
            }

            if(unit == unitOfMeasure)
            {
                return number;
            }
            else if(unit == UnitOfMeasure.meter && unitOfMeasure == UnitOfMeasure.centimeter)
            {
                return number / 100;
            }
            else if(unit == UnitOfMeasure.centimeter && unitOfMeasure == UnitOfMeasure.milimeter)
            {
                return  number / 10;
            }
            else if (unit == UnitOfMeasure.centimeter && unitOfMeasure == UnitOfMeasure.meter)
            {
                return number * 100;
            }
            else if (unit == UnitOfMeasure.meter && unitOfMeasure == UnitOfMeasure.milimeter)
            {
                return number * 1000;
            }
            else if (unit == UnitOfMeasure.milimeter && unitOfMeasure == UnitOfMeasure.centimeter)
            {
                return number * 10;
            }
            else if (unit == UnitOfMeasure.milimeter && unitOfMeasure == UnitOfMeasure.meter)
            {
                return number * 1000;
            }

            return number;
        }

         private static double  GetNumberInUnitStatic(double number, UnitOfMeasure unitOfMeasure, string unitAsString)
        {
            UnitOfMeasure unit = UnitOfMeasure.meter;
            switch (unitAsString)
            {
                case "mm":
                    unit = UnitOfMeasure.milimeter;
                    break;
                case "cm":
                    unit = UnitOfMeasure.centimeter;
                    break;
                case "m":
                    unit = UnitOfMeasure.meter;
                    break;
            }

            if(unit == unitOfMeasure)
            {
                return number;
            }
            else if(unit == UnitOfMeasure.meter && unitOfMeasure == UnitOfMeasure.centimeter)
            {
                return number / 100;
            }
            else if(unit == UnitOfMeasure.centimeter && unitOfMeasure == UnitOfMeasure.milimeter)
            {
                return  number / 10;
            }
            else if (unit == UnitOfMeasure.centimeter && unitOfMeasure == UnitOfMeasure.meter)
            {
                return number * 100;
            }
            else if (unit == UnitOfMeasure.meter && unitOfMeasure == UnitOfMeasure.milimeter)
            {
                return number * 1000;
            }
            else if (unit == UnitOfMeasure.milimeter && unitOfMeasure == UnitOfMeasure.centimeter)
            {
                return number * 10;
            }
            else if (unit == UnitOfMeasure.milimeter && unitOfMeasure == UnitOfMeasure.meter)
            {
                return number * 1000;
            }

            return number;
        }

        public override string ToString()
        {
            return this.ToString(null, CultureInfo.CurrentCulture);
        }

        public  string ToString(string format)
        {
            if(format == "cm" || format == "mm" || format == "m")
            {
                return this.ToString(format, CultureInfo.CurrentCulture);
            }
            else
            {
                throw new FormatException();
            }
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if(format == null)
            {
                return $"«{string.Format("{0:#,0.000}",Math.Round(GetNumberInUnit(A, "m"),3))}» «m» {'\u00d7'}" +
                    $" «{string.Format("{0:#,0.000}" ,Math.Round(GetNumberInUnit(B, "m"),3))}» «m» {'\u00d7'}" +
                    $" «{string.Format("{0:#,0.000}",Math.Round(GetNumberInUnit(C, "m"),3))}» «m»\r\n\r\n";
            }
            else
            {
                return $"«{string.Format("{0:#,0.000}", Math.Round(GetNumberInUnit(A, format), 3))}» «{format}» {'\u00d7'} «{string.Format("{0:#,0.000}", Math.Round(GetNumberInUnit(B, format), 3))}» «{format}» {'\u00d7'} «{string.Format("{0:#,0.000}", Math.Round(GetNumberInUnit(C, format), 3))}» «{format}»\r\n\r\n";
            }
        }

        public bool Equals(Pudelko? other)
        {
            return GetNumberInUnit(a, "m") == GetNumberInUnit(other.a,"m") &&
                   GetNumberInUnit(b, "m") == GetNumberInUnit(other.b, "m") &&
                   GetNumberInUnit(c, "m") == GetNumberInUnit(other.c, "m");
        }

        public static bool operator==(Pudelko p1, Pudelko p2)
        {
            return GetNumberInUnitStatic(p1.a, p1.unitOfMeasure, "m") == GetNumberInUnitStatic(p2.a, p2.unitOfMeasure, "m") &&
                  GetNumberInUnitStatic(p1.b, p1.unitOfMeasure, "m") == GetNumberInUnitStatic(p2.b, p2.unitOfMeasure, "m") &&
                  GetNumberInUnitStatic(p1.c, p1.unitOfMeasure, "m") == GetNumberInUnitStatic(p2.c, p2.unitOfMeasure, "m");
        }

        public static bool operator!=(Pudelko p1, Pudelko p2)
        {
            return GetNumberInUnitStatic(p1.a, p1.unitOfMeasure, "m") != GetNumberInUnitStatic(p2.a, p2.unitOfMeasure, "m") ||
                  GetNumberInUnitStatic(p1.b, p1.unitOfMeasure, "m") != GetNumberInUnitStatic(p2.b, p2.unitOfMeasure, "m") ||
                  GetNumberInUnitStatic(p1.c, p1.unitOfMeasure, "m") != GetNumberInUnitStatic(p2.c, p2.unitOfMeasure, "m");
        }

        public static Pudelko operator+(Pudelko p1, Pudelko p2)
        {
            double a = 0;
            double b = 0;
            double c = 0;

            double p1A = GetNumberInUnitStatic(p1.a, p1.unitOfMeasure, "m");
            double p1B = GetNumberInUnitStatic(p1.b, p1.unitOfMeasure, "m");
            double p1C = GetNumberInUnitStatic(p1.c, p1.unitOfMeasure, "m");
            double p2A = GetNumberInUnitStatic(p2.a, p2.unitOfMeasure, "m");
            double p2B = GetNumberInUnitStatic(p2.b, p2.unitOfMeasure, "m");
            double p2C = GetNumberInUnitStatic(p2.c, p2.unitOfMeasure, "m");

            a = p1A + p2A;
            b = p1B + p2B;
            
            if(p2C >= p1C)
            {
                c = p2C;
            }
            else
            {
                c = p1C;
            }


            return new Pudelko(a, b, c);
        }

        public override int GetHashCode()
        {
            double[] dimensions = new double[] { this.a, this.b, this.c };
            Array.Sort(dimensions);
            int hash = 17;

            foreach (double dimension in dimensions)
            {
                hash = hash * 31 + dimension.GetHashCode();
            }

            return hash;
        }
    }
}
