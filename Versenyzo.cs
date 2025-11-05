namespace Euroskills2018.Models
{
    public class Versenyzo
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string SzakmaId { get; set; }
        public string OrszagId { get; set; }
        public int Pont { get; set; }

        public Szakma? Szakma { get; set; }
        public Orszag? Orszag { get; set; }
    }
}