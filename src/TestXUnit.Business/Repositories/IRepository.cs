using System;
using TestXUnit.Business.Model;

namespace TestXUnit.Business.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
    }
}