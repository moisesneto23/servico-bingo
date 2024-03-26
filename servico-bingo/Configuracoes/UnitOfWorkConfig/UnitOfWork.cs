

using OrcamentoGenerico.Api.Configuracoes.Contexto;

namespace OrcamentoGenerico.Api.Configuracoes.UnitOfWorkConfig
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextoConfig _context;

        public UnitOfWork(ContextoConfig context)
            => _context = context;

        public async Task SaveAsync(CancellationToken cancellationToken)
            => await _context.SaveChangesAsync(cancellationToken);

    }
}


