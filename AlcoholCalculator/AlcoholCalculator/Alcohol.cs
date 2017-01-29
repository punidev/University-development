namespace AlcoholCalculator
{
    internal class Alcohol
    {
        public string Name;
        public double Alco;
        public double Part;

        public Alcohol(string name, double alco, double part)
        {
            Name = name;
            Alco = alco;
            Part = part;
        }
        public Alcohol OfPart(double part)
        {
            return new Alcohol(this.Name, Alco, part);
        }
    }
}