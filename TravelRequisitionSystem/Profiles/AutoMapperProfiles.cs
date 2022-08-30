using AutoMapper;
using TravelRequisitionSystem.DTO;
using TravelRequisitionSystem.Model;

namespace TravelRequisitionSystem.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TravelRequestModelDTO, TravelRequestDetail>();
            //CreateMap<TravelRequestDetail, TravelRequestSearchDTO>();
        }
    }
}
