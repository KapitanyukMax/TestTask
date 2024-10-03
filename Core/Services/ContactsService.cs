using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace Core.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IMapper mapper;
        private readonly IContactsRepository contactsRepo;
        private readonly IAccountsRepository accountsRepo;

        public ContactsService(IMapper mapper, IContactsRepository contactsRepo,
            IAccountsRepository accountsRepo)
        {
            this.mapper = mapper;
            this.contactsRepo = contactsRepo;
            this.accountsRepo = accountsRepo;
        }

        public async Task<IEnumerable<ContactDto>> GetAll()
        {
            return mapper.Map<List<ContactDto>>(await contactsRepo.GetAll());
        }

        public async Task<ContactDto> Get(string email)
        {
            Contact? contact = await contactsRepo.GetByEmail(email);
            if (contact == null)
                throw new HttpException("Not Found", HttpStatusCode.NotFound);

            return mapper.Map<ContactDto>(contact);
        }

        public async Task Create(ContactDto model)
        {
            Account? account = await accountsRepo.GetByName(model.AccountName);
            if (account == null)
                throw new HttpException("Not Found", HttpStatusCode.NotFound);

            Contact? contact = await contactsRepo.GetByEmail(model.Email);
            if (contact == null)
            {
                await contactsRepo.Insert(mapper.Map<Contact>(model));
            }
            else
            {
                await contactsRepo.Update(mapper.Map<Contact>(model));
            }

            await contactsRepo.Save();
        }
    }
}
