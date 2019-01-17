using LearningHub.Data.Context;
using LearningHub.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LearningHub.Data.Infrastructure
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool _disposed;
        private Dictionary<string, object> _repositories;

        protected DbContext DataContext { get; }

        public UnitOfWork(SchoolPandaContext context)
        {
            DataContext = context;
            DataContext.Database.Migrate();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            DataContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }
            _disposed = true;
        }

        public Repository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type)) return (Repository<T>)_repositories[type];
            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), DataContext);
            _repositories.Add(type, repositoryInstance);
            return (Repository<T>)_repositories[type];
        }
    }
}