namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<bool> CommitAsync(CancellationToken cancellationToken = default);
    }
}