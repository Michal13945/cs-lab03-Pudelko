
using Microsoft.Graph;
using System.Globalization;

namespace Projekt_Pudelko
{
    public sealed class Pudelko : IFormattable
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;

        private readonly UnitOfMeasure unitOfMeasure;

        public double A
        {
            get { return Math.Round(a,3); }
        }

        public double B
        {
            get { return Math.Round(b, 3); }
        }
        public double C
        {
            get { return Math.Round(c, 3); }
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

        private double GetNumberInUnit(double number, string unitAsString)
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
    }
}
