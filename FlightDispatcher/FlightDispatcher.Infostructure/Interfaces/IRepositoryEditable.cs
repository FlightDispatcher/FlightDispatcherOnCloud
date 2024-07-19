using FlightDispatcher.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Interfaces
{
    public interface IRepositoryEditable<TDocument>
    {
        Task<TDocument> Create(TDocument document);
        Task<TDocument> Update(TDocument document);
    }
}
