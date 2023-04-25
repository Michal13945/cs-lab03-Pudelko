
namespace Projekt_Pudelko
{
    public sealed class Pudelko
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

        

        
    }
}
