namespace Zenmoney.Entities
{
    public class Transaction
    {
        public string Id { get; set; }
        public int User { get; set; }
        public string Date { get; set; }
        public double Income { get; set; }
        public double Outcome { get; set; }
        public int Changed { get; set; }
        public int IncomeInstrument { get; set; }
        public int OutcomeInstrument { get; set; }
        public int Created { get; set; }
        public string OriginalPayee { get; set; }
        public bool Deleted { get; set; }
        public bool Viewed { get; set; }
        public string Hold { get; set; }
        public string QrCode { get; set; }
        public string IncomeAccount { get; set; }
        public string OutcomeAccount { get; set; }
        public string[] Tag { get; set; }
        public string Comment { get; set; }
        public string Payee { get; set; }
        public double? OpIncome { get; set; }
        public double? OpOutcome { get; set; }
        public int? OpIncomeInstrument { get; set; }
        public int? OpOutcomeInstrument { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Merchant { get; set; }
        public string IncomeBankID { get; set; }
        public string OutcomeBankID { get; set; }
        public string ReminderMarker { get; set; }
    }
}