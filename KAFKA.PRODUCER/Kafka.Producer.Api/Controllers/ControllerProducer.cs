using KAFKA.PRODUCER.Aplicacao.Interfaces;
using KAFKA.PRODUCER.Dominios.Dominios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kafka.Producer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerProducer : ControllerBase
    {
        #region Construtor
        private IMensageriaKafka _mensageriaKafka;
        public ControllerProducer(IMensageriaKafka mensageriaKafka)
        {
            _mensageriaKafka = mensageriaKafka;
        }
        #endregion

        [HttpPost]
        public IActionResult PostMensage([FromBody] List<MensagemKafka> mensagem)
        {
            return Created("", _mensageriaKafka.EnviaMensagem(mensagem));
        }
    }
}

