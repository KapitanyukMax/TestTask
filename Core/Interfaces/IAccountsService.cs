using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task<IEnumerable<AccountDto>> GetAll();
        Task<AccountDto> Get(string name);
        Task Create(CreateAccountDto model);
    }
}
