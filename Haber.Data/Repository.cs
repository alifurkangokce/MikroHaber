﻿using Haber.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
   public class Repository<T>:IRepository<T> where T:BaseEntity
    {
        private readonly ApplicationDbContext db;
        private readonly DbSet<T> entities;
        public Repository(ApplicationDbContext db)
        {
            this.db = db;
            this.entities = db.Set<T>();
        }
        public void Delete(T entity)
        {
            entities.Remove(entity);
        }
        public T Find(String slug)
        {
            return entities.FirstOrDefault(f=>f.Slug==slug);
        }

        public T Find(Guid id)
        {
            return entities.FirstOrDefault(f => f.Id == id);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return entities.FirstOrDefault(where);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).ToList();
        }

        public void Insert(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = "username";
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = "username";
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = "username";
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
