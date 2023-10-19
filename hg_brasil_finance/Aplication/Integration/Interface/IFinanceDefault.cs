using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration.Interface
{
    public interface IFinanceDefault<T>
    {
        ApiResponse<T> GetAll();
    }
}
