using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public interface IFinanceStock
    {
        ApiResponse<StockResponse> GetStockPrice(IEnumerable<string> symbol);
        ApiResponse<DividendsResponse> GetStockDividends(IEnumerable<string> symbol);
        ApiResponse<StockResponse> GetIbovespa(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date);
        ApiResponse<StockResponse> GetIbovespa();
        ApiResponse<StockResponse> GetQuotations();
        ApiResponse<StockResponse> GetTaxes();
    }
}
