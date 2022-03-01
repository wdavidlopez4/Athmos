using Athmos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Infrastructure.EF
{
    public class AthmosContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AthmosContext(DbContextOptions<AthmosContext> options) : base(options)
        {

        }
    }
}
