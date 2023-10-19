using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration.Interface
{
    public interface IFinanceStock
    {
        ApiResponse<StockResponse> GetStockPrice(IEnumerable<string> symbol);
        ApiResponse<StockResponse> GetStockPrice(string symbol);
        ApiResponse<StockResponse> GetStockDividends(IEnumerable<string> symbol);
        ApiResponse<StockResponse> GetIbovespa(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date);
        ApiResponse<StockResponse> GetIbovespa();
        ApiResponse<StockResponse> GetQuotations();
        ApiResponse<StockResponse> GetTaxes();
        ApiResponse<StockResponse> GetHistorical(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date, string mode);
        ApiResponse<StockResponse> GetHistoricalStocks(IEnumerable<string> symbols, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date);
    }
}
