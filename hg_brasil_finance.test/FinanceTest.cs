using hg_brasil_finance.Aplication.Integration;
using Microsoft.Extensions.DependencyInjection;

namespace hg_brasil_finance.test
{
    public class FinanceTest
    {

        [Fact]
        public void GetStockPrice_ReturnOk()
        {
            //Arrange
            var key = "";
            var symbols = new List<string> { "TRPL4" };

            //Act
            var _finance = new FinanceHG(key);
            var result = _finance.GetStockPrice(symbols);

            //Assert
            Assert.NotNull(result);
        }


        [Fact]
        public void GetTickers_ReturnOk()
        {
            //Arrange
            var key = "";

            //Act
            var _finance = new FinanceHG(key);
            var result = _finance.GetAllTickers();

            //Assert
            Assert.NotNull(result);
        }
    }
}