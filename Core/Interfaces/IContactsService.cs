using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IContactsService
    {
        Task<IEnumerable<ContactDto>> GetAll();
        Task<ContactDto> Get(string email);
        Task Create(ContactDto model);
    }
}
