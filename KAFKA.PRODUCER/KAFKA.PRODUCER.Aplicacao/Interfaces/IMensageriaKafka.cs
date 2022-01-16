﻿using KAFKA.PRODUCER.Dominios.Dominios;
using System.Collections.Generic;

namespace KAFKA.PRODUCER.Aplicacao.Interfaces
{
    public interface IMensageriaKafka
    {
        public string EnviaMensagem(List<MensagemKafka> mensagemKafka);
        public List<string> ConvertMensagemKafkaString(List<MensagemKafka> mensagens);
    }
}
