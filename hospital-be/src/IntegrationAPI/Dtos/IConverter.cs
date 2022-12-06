using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.Dtos
{
    public interface IConverter<TEntity, TDto>
    {
        public TDto Convert(TEntity entity);
        public TEntity Convert(TDto dto);
    }
}
