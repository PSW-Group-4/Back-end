using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Utilities.Converters
{
    public interface Converter<Entity, Dto>
    {
        public Dto Convert(Entity entity);
        public Entity Convert(Dto dto);
    }
}
