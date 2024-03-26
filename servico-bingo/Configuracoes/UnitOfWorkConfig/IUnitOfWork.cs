namespace OrcamentoGenerico.Api.Configuracoes.UnitOfWorkConfig;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken);
}
