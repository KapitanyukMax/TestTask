using AutoMapper;
using Core.Dtos;
using DataAccess.Entities;

namespace Core.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<ContactDto, Contact>().ReverseMap();

            CreateMap<CreateAccountDto, Account>()
                .ForMember(a => a.Name,
                    config =>
                        config.MapFrom(a => a.AccountName));
            CreateMap<CreateAccountDto, Contact>()
                .ForMember(c => c.Email,
                    config =>
                        config.MapFrom(a => a.ContactEmail))
                .ForMember(c => c.FirstName,
                    config =>
                        config.MapFrom(a => a.ContactFirstName))
                .ForMember(c => c.LastName,
                    config =>
                        config.MapFrom(a => a.ContactLastName));
            CreateMap<Account, AccountDto>();

            CreateMap<CreateIncidentDto, Incident>()
                .ForMember(i => i.Description,
                config =>
                    config.MapFrom(i => i.IncidentDescription));
            CreateMap<CreateIncidentDto, Contact>()
                .ForMember(c => c.Email,
                    config =>
                        config.MapFrom(i => i.ContactEmail))
                .ForMember(c => c.FirstName,
                    config =>
                        config.MapFrom(i => i.ContactFirstName))
                .ForMember(c => c.LastName,
                    config =>
                        config.MapFrom(i => i.ContactLastName));
            CreateMap<Incident, IncidentDto>();
        }
    }
}