namespace hg_brasil_finance.Domain.Entities
{
    public class Bitstamp
    {
        public string name { get; set; }
        public List<string> format { get; set; }
        public int last { get; set; }
        public int buy { get; set; }
        public int sell { get; set; }
        public double variation { get; set; }
    }
}
