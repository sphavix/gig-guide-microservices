using AutoMapper;
using Gigs.Application.Commands;
using Gigs.Application.Responses;
using Gigs.Domain.Entities;

namespace Gigs.Application.Mappers
{
    public class GigsMapperProfile : Profile
    {
        public GigsMapperProfile()
        {
            CreateMap<Gig, GetGigsResponse>().ReverseMap();
            CreateMap<Gig, CreateGigCommand>().ReverseMap();
        }
    }
}