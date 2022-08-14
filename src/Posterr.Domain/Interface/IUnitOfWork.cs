namespace Posterr.Domain.Interface
{
    public interface IUnitOfWork
    {
        bool Commit();
        Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}
