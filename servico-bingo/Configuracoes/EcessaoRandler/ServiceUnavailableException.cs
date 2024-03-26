﻿using System.Runtime.Serialization;

namespace OrcamentoGenerico.Api.Configuracoes.EcessaoRandler
{
    internal class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException() : this("Serviço indisponível.") { }
        public ServiceUnavailableException(string message) : base(message) { }
        public ServiceUnavailableException(string message, Exception innerException) : base(message, innerException) { }
        protected ServiceUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}