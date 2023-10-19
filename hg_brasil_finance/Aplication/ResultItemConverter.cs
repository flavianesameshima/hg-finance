using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hg_brasil_finance.Aplication
{
    public class ResultItemConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<IEnumerable<T>>();
            }

            if (token.Type == JTokenType.Object && token["error"] != null)
            {
                return token.ToObject<T>();
            }

            throw new JsonSerializationException("Unknown result type");
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
