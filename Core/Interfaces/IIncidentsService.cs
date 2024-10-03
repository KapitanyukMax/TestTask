using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IIncidentsService
    {
        Task<IEnumerable<IncidentDto>> GetAll();
        Task<IncidentDto> Get(string name);
        Task Create(CreateIncidentDto model);
    }
}
