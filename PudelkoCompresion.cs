
namespace Projekt_Pudelko
{
    public static class PudelkoCompresion
    {
       public static Pudelko Compress(this Pudelko p)
        {
            return new Pudelko(p.A, p.B, p.C, p.UnitOfMeasure);
        }
    }
}
