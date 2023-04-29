
using System.Collections;
using System.Globalization;

namespace Projekt_Pudelko
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable<double>
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;

        private readonly UnitOfMeasure unitOfMeasure;

        public double A
        {
            get { return Math.Round(GetNumberInUnit(a,"m"), 3); }
        }

        public double B
        {
            get { return Math.Round(GetNumberInUnit(b,"m"), 3); }
        }
        public double C
        {
            get { return Math.Round(GetNumberInUnit(c,"m"), 3); }
        }
        public double Objetosc
        {
            get { return Math.Round(GetNumberInUnit(a, "m") * GetNumberInUnit(b, "m") * GetNumberInUnit(c, "m"), 9); }
        }
        public double Pole
        {
            get { return Math.Round(2 * GetNumberInUnit(a, "m") * GetNumberInUnit(b, "m") + 2 * GetNumberInUnit(a, "m") * GetNumberInUnit(c, "m") + 2 * GetNumberInUnit(b, "m") * GetNumberInUnit(c, "m"), 6); }
        }

        public UnitOfMeasure UnitOfMeasure
        {
            get { return unitOfMeasure; }
        }

        public Pudelko()
        {
            a = 10;
            b = 10;
            c = 10;

            unitOfMeasure = UnitOfMeasure.centimeter;
        }

        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.unitOfMeasure = UnitOfMeasure.centimeter;

            if (a == null)
            {
                this.a = 10;
                if(unit == UnitOfMeasure.milimeter)
                {
                    this.a = GetNumberInUnit((double)this.a, "mm");
                }
                else if(unit == UnitOfMeasure.meter)
                {
                    this.a = GetNumberInUnit((double)this.a, "m");
                }
            }
            else
            {
                this.a = (double)a;
            }

            if(b == null)
            {
                this.b = 10;
               
                if (unit == UnitOfMeasure.milimeter)
                {
                    this.b = GetNumberInUnit((double)this.b, "mm");
                }
                else if (unit == UnitOfMeasure.meter)
                {
                    this.b = GetNumberInUnit((double)this.b, "m");
                }
            }
            else
            {
                this.b = (double)b;
            }

            if (c == null)
            {
                this.c = 10;
               
                if (unit == UnitOfMeasure.milimeter)
                {
                    this.c = GetNumberInUnit((double)this.c, "mm");
                }
                else if (unit == UnitOfMeasure.meter)
                {
                    this.c = GetNumberInUnit((double)this.c, "m");
                }
            }
            else
            {
                this.c = (double)c;
            }
            this.unitOfMeasure = unit;



            if (this.a <= 0 || this.b <= 0 || this.c <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if((this.a > 10 || this.b > 10 || this.c > 10) && unit == UnitOfMeasure.meter) // możliwy błąd 
            {
                throw new ArgumentOutOfRangeException();
            }
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

        public static Pudelko Parse(string text)
        {
            if(string.IsNullOrEmpty(text) == true)
            {
                throw new ArgumentNullException("text");
            }

            string[] parts = text.Split('\u00d7');
            double a = ParseSide(parts[0]);
            double b = ParseSide(parts[1]);
            double c = ParseSide(parts[0]);

            return new Pudelko(a, b, c);
        }

        private static double ParseSide(string side)
        {
            double result = 0;

            side = side.Trim();

            if (side.EndsWith("m"))
            {
                result = double.Parse(side.Substring(0, side.Length - 1));
            }
            else if (side.EndsWith("cm"))
            {
                result = double.Parse(side.Substring(0, side.Length - 2)) / 100.0;
            }
            else if (side.EndsWith("mm"))
            {
                result = double.Parse(side.Substring(0, side.Length - 2)) / 1000.0;
            }

            return result;
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
        IEnumerator<double> IEnumerable<double>.GetEnumerator()
        {
            foreach (var x in this) 
            {
                yield return (double)x;  // sus
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
