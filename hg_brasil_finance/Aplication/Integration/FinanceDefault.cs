using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public class FinanceDefault : IFinanceDefault
    {
        private readonly BaseIntegration<Dictionary<string, DefaultResponse>> _integration;
        private readonly CacheConfig _cache;
        private readonly string _keyFinanceHG;

        public FinanceDefault(string keyFinanceHG, CacheConfig cache)
        {
            _cache = cache;
            _keyFinanceHG = keyFinanceHG;
            _integration = new BaseIntegration<Dictionary<string, DefaultResponse>>(_keyFinanceHG, _cache);
        }
        public FinanceDefault(string keyFinanceHG)
        {
            _keyFinanceHG = keyFinanceHG;
            _integration = new BaseIntegration<Dictionary<string, DefaultResponse>>(_keyFinanceHG, _cache);
        }

        public ApiResponse<Dictionary<string, DefaultResponse>> GetAll()
        =>_integration.FetchData<Dictionary<string, DefaultResponse>>("", "AllCache");
        
    }
}
