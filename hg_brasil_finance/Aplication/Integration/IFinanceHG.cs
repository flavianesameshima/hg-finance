using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public interface IFinanceHG
    {
        ApiResponse<Dictionary<string, StockResponse>> GetStockPrice(IEnumerable<string> symbol);
        ApiResponse<Dictionary<string, StockResponse>> GetStockDividends(IEnumerable<string> symbol);
        ApiResponse<Dictionary<string, StockResponse>> GetIboves(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date);
        ApiResponse<Dictionary<string, DefaultResponse>> GetAll();
        ApiResponse<Dictionary<string, StockResponse>> GetQuotations();
        ApiResponse<Dictionary<string, StockResponse>> GetTaxes();
        ApiResponse<Dictionary<string, StockResponse>> GetHistorical(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date, string mode);
        ApiResponse<Dictionary<string, StockResponse>> GetHistoricalStocks(IEnumerable<string> symbols, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date);
        ApiResponse<List<String>> GetAllTickers();
    }
}
