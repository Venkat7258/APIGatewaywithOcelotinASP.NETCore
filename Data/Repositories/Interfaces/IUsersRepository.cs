using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
   public interface IUsersRepository: IGenericRepository<Users>
    {
        Task UpdateUsers(Users obj);
    }
}
