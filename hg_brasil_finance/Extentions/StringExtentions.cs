using hg_brasil_finance.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace hg_brasil_finance.Extentions
{
    public static class StringExtentions
    {
        public static Root<Dictionary<string, StockResponse>> DeserializeObjectStock(this string value)
        {
            return JsonConvert.DeserializeObject<Root<Dictionary<string, StockResponse>>>(value);
        }
    }
}
