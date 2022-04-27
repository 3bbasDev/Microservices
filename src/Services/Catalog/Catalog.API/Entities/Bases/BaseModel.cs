using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.API.Entities.Bases
{
    public class BaseModel<TId>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public TId? Id { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
