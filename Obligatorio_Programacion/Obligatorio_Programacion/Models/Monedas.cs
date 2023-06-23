using Newtonsoft.Json;

namespace Obligatorio_Programacion.Models
{
    public class Monedas
    {
        [JsonProperty("USDUYU", NullValueHandling = NullValueHandling.Ignore)]
        public double? Usduyu { get; set; }
    }
}
