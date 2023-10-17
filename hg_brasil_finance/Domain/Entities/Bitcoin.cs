namespace hg_brasil_finance.Domain.Entities
{
    public class Bitcoin
    {
        public BlockchainInfo blockchain_info { get; set; }
        public Coinbase coinbase { get; set; }
        public Bitstamp bitstamp { get; set; }
        public Foxbit foxbit { get; set; }
        public Mercadobitcoin mercadobitcoin { get; set; }
    }
}
