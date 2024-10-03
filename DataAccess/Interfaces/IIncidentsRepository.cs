using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IIncidentsRepository
    {
        Task<IEnumerable<Incident>> GetAll();
        Task<Incident?> GetByName(object name);
        Task Save();
        Task Insert(Incident incident);
    }
}
