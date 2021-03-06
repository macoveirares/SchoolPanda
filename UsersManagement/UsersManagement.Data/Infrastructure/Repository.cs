﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UsersManagement.Data.Context;
using UsersManagement.Domain.Infrastructure;

namespace UsersManagement.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private DbSet<T> dbset;

        public Repository(SchoolPandaContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            dbset = DataContext.Set<T>();
        }

        protected DbContext DataContext => _context;

        public T GetById(int id)
        {
            return Entities.Find(id);
        }

        public IEnumerable<T> Query()
        {
            return Entities.ToList();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> where)
        {
            return Entities.Where(where).ToList();
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity is LoggedBaseEntity)
            {
                (entity as LoggedBaseEntity).InsertedDate = DateTime.Now;
                (entity as LoggedBaseEntity).UpdatedDate = DateTime.Now;
            }

            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity is LoggedBaseEntity)
            {
                (entity as LoggedBaseEntity).UpdatedDate = DateTime.Now;
            }

            Entities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual IQueryable<T> Table => Entities;

        private DbSet<T> Entities => dbset ?? (dbset = _context.Set<T>());
    }
}
