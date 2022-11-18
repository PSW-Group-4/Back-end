using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.Dtos
{
    public interface IConverter<Entity, Dto>
    {
        public Dto Convert(Entity entity);
        public Entity Convert(Dto dto);
    }
}
