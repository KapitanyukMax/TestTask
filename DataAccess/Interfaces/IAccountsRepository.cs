using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account?> GetByName(object name);
        Task Save();
        Task Insert(Account account);
    }
}
