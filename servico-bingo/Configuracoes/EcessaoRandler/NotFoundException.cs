﻿using System.Runtime.Serialization;

namespace OrcamentoGenerico.Api.Configuracoes.EcessaoRandler
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : this("Registro não encontrado.") { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
