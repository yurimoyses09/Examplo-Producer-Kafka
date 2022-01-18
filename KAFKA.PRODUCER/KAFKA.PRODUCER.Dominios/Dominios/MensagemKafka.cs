using Newtonsoft.Json;

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
        public int StatusCivil { get; set; }
    }

}
