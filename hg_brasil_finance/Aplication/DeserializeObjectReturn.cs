using hg_brasil_finance.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hg_brasil_finance.Aplication
{
    public class DeserializeObjectReturn<T>
    {
        public Root<Dictionary<string, object>> DeserializeObject(string json)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new ResultItemConverter<T>());

            var result = JsonConvert.DeserializeObject<Root<Dictionary<string, object>>>(json, settings);

            var processedResults = new Dictionary<string, object>();

            foreach (var item in result.results)
            {
                if (item.Value is JObject jObject && jObject["error"] != null)                
                    processedResults[item.Key] = jObject.ToObject<ErrorResponse>();                
                else if (item.Value is JArray jArray)                
                    processedResults[item.Key] = jArray.ToObject<List<T>>();                
                else if (item.Value is JObject singleObject)
                    processedResults[item.Key] = singleObject.ToObject<T>();                
            }

            result.results = processedResults;

            return result;
        }
    }
}
