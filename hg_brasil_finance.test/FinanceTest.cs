using hg_brasil_finance.Aplication.Integration;
using Moq;

namespace hg_brasil_finance.test
{
    public class FinanceTest
    {
        private readonly Mock<IFinanceHG> _mockFinance;

        public FinanceTest()
        {
            _mockFinance = new Mock<IFinanceHG>();
        }

        [Fact]
        public void GetStockPrice_ReturnOk()
        {
            //Arrange
            var key = "";
            var symbols = new List<string> { "TRPL4" };

            //Act
            var service = _mockFinance.Object;
            var result = service.GetStockPrice(key, symbols);

            //Assert
            Assert.NotNull(result);
        }
    }
}