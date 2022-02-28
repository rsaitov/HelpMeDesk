using AutoMapper;
using Data;
using Domain;
using HelpMeDeskNet5.ViewModels;

namespace HelpMeDeskNet5
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ticket, TicketDTO>();
            CreateMap<TicketDTO, Ticket>();

            CreateMap<TicketDTO, TicketViewModel>();
            CreateMap<TicketViewModel, TicketDTO>();
        }
    }
}
