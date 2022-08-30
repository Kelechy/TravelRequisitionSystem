using System.Collections.Generic;
using System.Threading.Tasks;
using TravelRequisitionSystem.Model;

namespace TravelRequisitionSystem.Data
{
    public interface ITravelRequestRepo
    {
        Task<CountryDetails> SearchCountryDetails(string CountryName);
        Task<ResponseModel> CreateTravelRequest(TravelRequestDetail detail);
        //Task<ResponseModel> UpdateTravelRequest(TravelRequestDetail detail);
        Task<ResponseModel> DeleteTravelRequestByRequisitionNumber(string RequisitionNumber);
        Task<ResponseModel> SearchTravelRequestByRequisitionNumber(string RequisitionNumber);
        ResponseModel GenerateJWT();
    }
}
