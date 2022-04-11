using AutoMapper;
using Vineforce.TusharBhagat.State.Dto;


namespace Vineforce.TusharBhagat.States.Dto
{
    public class StateMapProfile : Profile
    {
        public StateMapProfile()
        {
            CreateMap<CreateOrEditStateDto, State>().ReverseMap();
            CreateMap<StateDto, State>().ReverseMap();
        }
    }
}
