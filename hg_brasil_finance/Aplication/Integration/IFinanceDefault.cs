using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public interface IFinanceDefault
    {
        ApiResponse<DefaultResponse> GetAll();
    }
}
