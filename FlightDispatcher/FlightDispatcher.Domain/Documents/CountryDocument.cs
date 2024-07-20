using FlightDispatcher.Domain.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Documents
{
    public class CountryDocument : IDocument
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
