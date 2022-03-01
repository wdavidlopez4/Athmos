using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athmos.Domain.Ports
{
    public interface IMapObject
    {
        public TDestination Map<TSourse, TDestination>(TSourse sourse);
    }
}
