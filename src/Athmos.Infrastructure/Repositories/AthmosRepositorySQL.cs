using Athmos.Domain.Entities;
using Athmos.Domain.Ports;
using Athmos.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Infrastructure.Repositories
{
    public class AthmosRepositorySQL<T> : IRepository<T> where T : Entity 
    {
        private readonly AthmosContext context;

        public AthmosRepositorySQL(AthmosContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            try
            {
                return context.Set<T>().AsQueryable().Any(expression);
            }
            catch (Exception e)
            {

                throw new Exception($"no se completo la operacion {e.Message}");
            }
        }

        public async Task<T> Get(string id)
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
            catch (Exception e)
            {
                throw new Exception($"no se completo la operacion: {e.Message}");
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await context.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"no se completo la operacion: {e.Message}");
            }
        }

        public async Task Save(T obj)
        {
            try
            {
                var entity = await context.Set<T>().AddAsync(obj);

                //confirma que se añadio el objeto
                if (await context.SaveChangesAsync() < 0)
                    throw new Exception($"no se completo la operacion: {obj.GetType()}");
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        public async Task Update(T obj)
        {
            try
            {
                context.Entry(await context.Set<T>()
                    .FirstOrDefaultAsync(x => x.Id == obj.Id))
                    .CurrentValues.SetValues(obj);

                if (await context.SaveChangesAsync() < 0)
                    throw new Exception($"no se pudo actualizar: {obj.GetType()}");
            }
            catch (Exception e)
            {
                throw new Exception($"no se completo la operacion: {e.Message}");
            }
        }
    }
}
