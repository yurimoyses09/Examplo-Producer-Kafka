using Confluent.Kafka;
using KAFKA.PRODUCER.Aplicacao.Interfaces;
using KAFKA.PRODUCER.Dominios.Dominios;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace KAFKA.PRODUCER.Aplicacao
{
    public class EnviaMensagemKafka : IMensageriaKafka
    {
        #region Construtor
        private readonly IConfiguration _configuration;
        public EnviaMensagemKafka(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        public string EnviaMensagem(List<MensagemKafka> mensagemKafka)
        {
            string nomeTopico = _configuration.GetSection("MyConfigurationKafkaProducer").GetSection("NomeTopicoKafka").Value;

            #region Configuracao do Producer
            var configProducer = new ProducerConfig
            {
                BootstrapServers = _configuration.GetSection("MyConfigurationKafkaProducer").GetSection("ServerBoostrap").Value,
                ClientId = _configuration.GetSection("MyConfigurationKafkaProducer").GetSection("ClientId").Value,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = _configuration.GetSection("MyConfigurationKafkaProducer").GetSection("ApiKeyUsuario").Value,
                SaslPassword = _configuration.GetSection("MyConfigurationKafkaProducer").GetSection("ApiKeySenha").Value,
                SslCertificateLocation = _configuration.GetSection("MyConfigurationKafkaProducer").GetSection("LocationCertificatePem").Value,
            };
            #endregion

            List<string> Mensagens = ConvertMensagemKafkaString(mensagemKafka);

            using var producer = new ProducerBuilder<Null, string>(configProducer).Build();
            
            try
            {
                if (!mensagemKafka.Equals(null))
                {
                    foreach (var item in Mensagens)
                    {
                        var ExecucaoProducer = producer.ProduceAsync(nomeTopico, new Message<Null, string> 
                        {
                            Key = null,
                            Value = item 
                        });

                        ExecucaoProducer.Wait();
                        
                        if (ExecucaoProducer.Result.Equals(ErrorCode.NoError))
                            return $"Falha ao produzir mensagem {ExecucaoProducer.Result}";
                    }
                    producer.Flush();
                    return $"Processado com sucesso - topico {nomeTopico} - value = {Mensagens}";
                }
                else
                {
                    return $"Nenhuma mensagem para ser enviada";
                }
            }
            catch (ProduceException<Null, MensagemKafka> ex)
            {
                return ex.Message;
            }
        }

        public List<string> ConvertMensagemKafkaString(List<MensagemKafka> mensagens)
        {
            List<string> valoresProducer = new List<string>();

            foreach (var item in mensagens)
            {
                valoresProducer.Add(JObject.FromObject(item).ToString(Formatting.None));
            }

            return valoresProducer;
        }
    }
}
