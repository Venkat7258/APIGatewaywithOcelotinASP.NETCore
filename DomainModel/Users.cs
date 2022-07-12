using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
   public class Users
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //[BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string DatabaseAccess { get; set; }
        public bool IsActive { get; set; }
    }
    
}
