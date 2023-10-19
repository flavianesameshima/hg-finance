using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public class FinanceDefault : IFinanceDefault
    {
        private readonly BaseIntegration<DefaultResponse> _integration;

        public FinanceDefault(string keyFinanceHG, CacheConfig cache = null)
        {
            _integration = new BaseIntegration<DefaultResponse>(keyFinanceHG, cache);
        }

        public ApiResponse<DefaultResponse> GetAll()
        =>_integration.FetchData("", "AllCache");
        
    }
}
