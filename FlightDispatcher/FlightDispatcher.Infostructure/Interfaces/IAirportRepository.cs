using FlightDispatcher.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Interfaces
{
    public interface IAirportRepository : IRepositoryBase<AirportDocument>, IRepositoryEditable<AirportDocument>, IRepositoryErasable
    {
    }
}
