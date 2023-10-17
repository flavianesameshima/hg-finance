namespace hg_brasil_finance.Domain.Entities
{
    public class Root<T>
    {
        public string by { get; set; }
        public bool valid_key { get; set; }
        public T results { get; set; }
        public double execution_time { get; set; }
        public bool from_cache { get; set; }
    }
}
