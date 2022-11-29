using IntegrationLibrary.Tenders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Tenders.Service
{
    public interface ITenderService
    {
        void Create(Tender tender);
        IEnumerable<Tender> GetAll();
    }
}
