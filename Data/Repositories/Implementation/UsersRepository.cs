using Data.Repositories.Interfaces;
using Data.UnitofWork.Interfaces;
using DomainModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
   public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<Users> DbSet;
        public UsersRepository(IMongoContext context) : base(context)
        {
            Context = context;
            DbSet = Context.GetCollection<Users>(typeof(Users).Name);
        }

       public async Task UpdateUsers(Users obj)
        {
            var filter = Builders<Users>.Filter.Eq(s => s._id, obj._id);
            var result = await DbSet.ReplaceOneAsync(filter, obj);
        }
    }
}
