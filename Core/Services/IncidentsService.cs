using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using DataAccess.Interfaces;

namespace Core.Services
{
    public class IncidentsService : IIncidentsService
    {
        private readonly IMapper mapper;
        private readonly IContactsRepository contactsRepo;
        private readonly IAccountsRepository accountsRepo;
        private readonly IIncidentsRepository incidentsRepo;

        public IncidentsService(IMapper mapper, IContactsRepository contactsRepo,
            IAccountsRepository accountsRepo, IIncidentsRepository incidentsRepo)
        {
            this.mapper = mapper;
            this.contactsRepo = contactsRepo;
            this.accountsRepo = accountsRepo;
            this.incidentsRepo = incidentsRepo;
        }

        public async Task<IEnumerable<IncidentDto>> GetAll()
        {
            return mapper.Map<List<IncidentDto>>(await incidentsRepo.GetAll());
        }

        public async Task<IncidentDto> Get(string name)
        {
            Incident? incident = await incidentsRepo.GetByName(name);
            if (incident == null)
                throw new HttpException("Not Found", HttpStatusCode.NotFound);

            return mapper.Map<IncidentDto>(incident);
        }

        public async Task Create(CreateIncidentDto model)
        {
            Account? account = await accountsRepo.GetByName(model.AccountName);
            if (account == null)
                throw new HttpException("Not Found", HttpStatusCode.NotFound);

            Contact? contact = await contactsRepo.GetByEmail(model.ContactEmail);
            if (contact == null)
            {
                await contactsRepo.Insert(mapper.Map<Contact>(model));
            }
            else
            {
                await contactsRepo.Update(mapper.Map<Contact>(model));
            }

            await contactsRepo.Save();

            await incidentsRepo.Insert(mapper.Map<Incident>(model));
            await incidentsRepo.Save();
        }
    }
}
