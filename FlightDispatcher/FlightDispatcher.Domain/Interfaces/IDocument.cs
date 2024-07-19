﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Interfaces
{
    public interface IDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
