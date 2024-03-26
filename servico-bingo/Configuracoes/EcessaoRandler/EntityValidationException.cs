namespace OrcamentoGenerico.Api.Configuracoes.EcessaoRandler
{
    internal class EntityValidationException : Exception
    {
        public EntityValidationException(string? message) : base(message) { }
    }
}