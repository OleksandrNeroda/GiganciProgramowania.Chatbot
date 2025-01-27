using GiganciProgramowania.BuildingBlocks.Domain;

namespace GiganciProgramowania.Chatbot.Domain.Commons;

public interface IBaseRepository<TEntity> : IRepository
{
    void Add(TEntity entity);

    Task CommitAsync();

    ValueTask<TEntity> Get(Guid id, CancellationToken cancellationToken);
}
