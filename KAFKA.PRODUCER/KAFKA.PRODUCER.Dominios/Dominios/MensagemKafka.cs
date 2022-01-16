using Newtonsoft.Json;
using static KAFKA.PRODUCER.Dominios.Enums.Enum;

namespace KAFKA.PRODUCER.Dominios.Dominios
{
    public class MensagemKafka
    {
        [JsonProperty(PropertyName = "data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "cpf")]
        public string Cpf { get; set; }

        [JsonProperty(PropertyName = "idade")]
        public string Idade { get; set; }

        [JsonProperty(PropertyName = "status_civil")]
        public statusCivil StatusCivil { get; set; }
    }

}
