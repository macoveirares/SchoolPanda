using ResourceManagement.Domain.Infrastructure;

namespace ResourceManagement.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Save();
        void Dispose(bool disposing);
        Repository<T> Repository<T>() where T : BaseEntity;
    }
}
