// See https://aka.ms/new-console-template for more information

using hg_brasil_finance.Aplication.Integration;


var finance = new FinanceHG("");
var symbols = new List<string> { "TRPL4" };

var teste = finance.GetStockPrice(symbols);
Console.WriteLine(teste.ToString());

teste = finance.GetStockPrice(symbols);
Console.WriteLine(teste.ToString());

teste = finance.GetStockPrice(symbols);
Console.WriteLine(teste.ToString());
