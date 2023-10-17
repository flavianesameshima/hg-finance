using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public interface IFinanceHG
    {
        ReturnAPI GetStockPrice(string key, IEnumerable<string> symbol);
        ReturnAPI GetStockDividends(string key, IEnumerable<string> symbol);
        ReturnAPI GetIboves(string key, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date);
        ReturnAPI GetAll(string key);
        ReturnAPI GetQuotations(string key);
        ReturnAPI GetTaxes(string key);
        ReturnAPI GetHistorical(string key, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date, string mode);
        ReturnAPI GetHistoricalStocks(string key, IEnumerable<string> symbols, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date);
    }
}
