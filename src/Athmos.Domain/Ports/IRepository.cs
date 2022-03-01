using Athmos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Domain.Ports
{
    public interface IRepository<T> where T : Entity
    {
        public Task Save(T obj);

        public Task<T> Get(string id);

        public Task<List<T>> GetAll();

        public Task Update(T obj);

        public bool Exists(Expression<Func<T, bool>> expression);
    }
}
