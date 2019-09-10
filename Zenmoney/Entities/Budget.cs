namespace Zenmoney.Entities
{
    public class Budget
    {
        public int User { get; set; }
        public int Changed { get; set; }
        public string Date { get; set; }
        public string Tag { get; set; }
        public int Income { get; set; }
        public int Outcome { get; set; }
        public bool IncomeLock { get; set; }
        public bool OutcomeLock { get; set; }
    }
}