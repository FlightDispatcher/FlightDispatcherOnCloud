using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Interfaces
{
    public interface IRepositoryErasable
    {
        Task Delete(ObjectId id);
    }
}
