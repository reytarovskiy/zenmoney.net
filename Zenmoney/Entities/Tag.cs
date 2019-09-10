namespace Zenmoney.Entities
{
    public class Tag
    {
        public string Id { get; set; }
        public int User { get; set; }
        public int Changed { get; set; }
        public string Icon { get; set; }
        public bool BudgetIncome { get; set; }
        public bool BudgetOutcome { get; set; }
        public bool? Required { get; set; }
        public int? Color { get; set; }
        public object Picture { get; set; }
        public string Title { get; set; }
        public bool ShowIncome { get; set; }
        public bool ShowOutcome { get; set; }
        public string Parent { get; set; }
    }
}