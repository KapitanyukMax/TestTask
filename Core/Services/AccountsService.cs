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
    public class AccountsService : IAccountsService
    {
        private readonly IMapper mapper;
        private readonly IContactsRepository contactsRepo;
        private readonly IAccountsRepository accountsRepo;

        public AccountsService(IMapper mapper, IContactsRepository contactsRepo,
            IAccountsRepository accountsRepo)
        {
            this.mapper = mapper;
            this.contactsRepo = contactsRepo;
            this.accountsRepo = accountsRepo;
        }

        public async Task<IEnumerable<AccountDto>> GetAll()
        {
            return mapper.Map<List<AccountDto>>(await accountsRepo.GetAll());
        }

        public async Task<AccountDto> Get(string name)
        {
            Account? account = await accountsRepo.GetByName(name);
            if (account == null)
                throw new HttpException("Not Found", HttpStatusCode.NotFound);

            return mapper.Map<AccountDto>(account);
        }

        public async Task Create(CreateAccountDto model)
        {
            Account? account = await accountsRepo.GetByName(model.AccountName);
            if (account != null)
                throw new HttpException("Conflict", HttpStatusCode.Conflict);

            await accountsRepo.Insert(mapper.Map<Account>(model));
            await accountsRepo.Save();

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
        }
    }
}
