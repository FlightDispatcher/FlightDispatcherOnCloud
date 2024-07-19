using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Interfaces
{
    public interface IRepositoryBase<TDocument>
    {
        Task<List<TDocument>> GetAll();
        Task<TDocument> GetById(ObjectId id);
    }
}
