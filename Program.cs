using Projekt_Pudelko;

Pudelko p0 = new Pudelko(2.5, 9.321, 0.1);
Pudelko p1 = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter);
Pudelko p2 = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.centimeter);
Pudelko p3 = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.milimeter);

Console.WriteLine(p0);
Console.WriteLine(p0.ToString("m"));
Console.WriteLine(p0.ToString("cm"));
Console.WriteLine(p0.ToString("mm"));
