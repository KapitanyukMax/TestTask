using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IContactsRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact?> GetByEmail(object email);
        Task Save();
        Task Insert(Contact contact);
        Task Update(Contact contactToUpdate);
    }
}