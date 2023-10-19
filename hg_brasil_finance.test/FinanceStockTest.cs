using hg_brasil_finance.Aplication.Integration;
using System.Net;

namespace hg_brasil_finance.test
{
    public class FinanceStockTest
    {
        private const string KEY = "";
        private readonly FinanceHG _finance = new FinanceHG(KEY);
        private readonly FinanceHG _financeCache = new FinanceHG(KEY, new CacheConfig(50));

        [Fact]
        public void GetStockPrice_ReturnOk()
        {
            //Arrange
            var symbols = new List<string> { "TRPL4" };

            //Act
            var result = _financeCache.GetStockPrice(symbols);

            //Assert
            Assert.Equal(result.StatusCode, HttpStatusCode.OK.ToString());
            Assert.NotNull(result);
        }

        [Fact]
        public void GetStockDividends_ReturnOk()
        {
            //Arrange
            var symbols = new List<string> { "TREL4", "TRPL4" };

            //Act 
            var result = _finance.GetStockDividends(symbols);

            //Assert
            Assert.Equal(result.StatusCode, HttpStatusCode.OK.ToString());

        }
    }
}