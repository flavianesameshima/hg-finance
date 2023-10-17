namespace hg_brasil_finance.Domain.Entities
{
    public class Root
    {
        public string by { get; set; }
        public bool valid_key { get; set; }
        public Results results { get; set; }
        public int execution_time { get; set; }
        public bool from_cache { get; set; }
    }
}
