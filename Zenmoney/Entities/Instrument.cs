namespace Zenmoney.Entities
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Symbol { get; set; }
        public double Rate { get; set; }
        public int Changed { get; set; }
    }
}