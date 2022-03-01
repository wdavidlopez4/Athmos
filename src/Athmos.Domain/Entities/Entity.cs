using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity(Guid? id = null)
        {
            this.Id = id != null ? id.Value : Guid.NewGuid();
        }
    }
}
