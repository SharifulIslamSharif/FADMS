namespace FADMS.Data.Entity.Dealer
{
    public class Currency:Base
    {
        public string formalName { get; set; }

        public string symbolText { get; set; }

        public string symbolSign { get; set; }

        public int? decimalAllow { get; set; }
    }
}
