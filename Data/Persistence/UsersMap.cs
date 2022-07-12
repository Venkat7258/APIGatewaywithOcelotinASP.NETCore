using DomainModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Persistence
{
    public class UsersMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Users>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                //  map.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
                map.MapIdMember(x => x._id);
                map.MapMember(x => x.FirstName).SetIsRequired(true);
                map.MapMember(x => x.LastName).SetIsRequired(true);
            });
        }
    }
}
