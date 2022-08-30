using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TravelRequisitionSystem.Context;
using TravelRequisitionSystem.Model;
using TravelRequisitionSystem.Utitlity;

namespace TravelRequisitionSystem.Data
{
    public class TravelRequestRepo : ITravelRequestRepo
    {
        private readonly TravelRequestSystemContext _context;
        private readonly IConfiguration _config;

        public TravelRequestRepo(TravelRequestSystemContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<ResponseModel> CreateTravelRequest(TravelRequestDetail detail)
        {
            ///////generate  REQNUMBER
            Random rd = new Random();
            int rand_num = rd.Next(10, 10000);

            var reqNumber = rand_num + detail.TravelerName + detail.Destination + DateTime.Now.Ticks;
            var request = new TravelRequestDetail()
            {
                RequestDate = detail.RequestDate,
                SourceLocation = detail.SourceLocation,
                SourceCountry = detail.SourceCountry,
                Destination = detail.Destination,
                DestinatioCountry = detail.DestinatioCountry,
                ProposedDepartureTimestamp = detail.ProposedDepartureTimestamp,
                TravelClass = detail.TravelClass,
                TripType = detail.TripType,
                ChargeCode = detail.ChargeCode,
                TravelerName = detail.TravelerName,
                RequisitionStatus = Status.Submitted,
                RequisitionNumber = reqNumber
            };

            _context.travelRequestDetails.Add(request);
            _context.SaveChanges();

            return new ResponseModel
            {
                ResponseMessage = "Travel Request Created Successfully",
                ResponseObject = request.RequisitionNumber,
                ResponseCode = HttpStatusCode.OK
            };
        }

        //public async Task<ResponseModel> UpdateTravelRequest(TravelRequestDetail detail)
        //{
        //    var req = _context.travelRequestDetails.Where(i => i.RequisitionNumber == detail.RequisitionNumber).FirstOrDefault();
        //    if (req != null && req.RequisitionStatus != Status.Booked)
        //    {
        //        _context.travelRequestDetails.Update(detail);
        //        _context.SaveChanges();

        //        return new ResponseModel
        //        {
        //            ResponseMessage = "Travel Request Updated Successfully",
        //            ResponseCode = HttpStatusCode.OK
        //        };
        //    }
        //    else
        //    {
        //        return new ResponseModel
        //        {
        //            ResponseMessage = "Error occured while Updating Travel Request ",
        //            ResponseCode = HttpStatusCode.BadRequest
        //        };
        //    }



        //}

        public async Task<ResponseModel> DeleteTravelRequestByRequisitionNumber(string requisitionNumber)
        {
            var req = _context.travelRequestDetails.Where(i => i.RequisitionNumber == requisitionNumber && i.RequisitionStatus != Status.Booked).FirstOrDefault();
            if (req != null)
            {
                _context.travelRequestDetails.Remove(req);
                _context.SaveChanges();

                return new ResponseModel
                {
                    ResponseMessage = "Travel Request Deleted  Successfully",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            else
            {
                return new ResponseModel
                {
                    ResponseMessage = "Error occured, Request can not be deleted",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }


        }

        public async Task<ResponseModel> SearchTravelRequestByRequisitionNumber(string RequisitionNumber)
        {
            var req = _context.travelRequestDetails.Where(i => i.RequisitionNumber == RequisitionNumber).FirstOrDefault();
            if (req != null)
            {
                return new ResponseModel
                {
                    ResponseMessage = "Travel Request Found",
                    ResponseObject = req,
                    ResponseCode = HttpStatusCode.OK
                };

            }
            else
            {
                return new ResponseModel
                {
                    ResponseMessage = "Travel Request does not exist",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }


        }

        public async Task<CountryDetails> SearchCountryDetails(string CountryName)
        {
            var details = await ExternalAPI.GetCountryDetails(_config, CountryName);
            var weather = await ExternalAPI.GetWeatherDetails(_config, CountryName);

            var weatherDetails = new WeatherDetails
            {
                Humidity = weather.main.humidity.ToString(),
                Presssure = weather.main.pressure.ToString(),
                MaximumTemperature = weather.main.temp_max.ToString(),
                MinimumTemperature = weather.main.temp_min.ToString()
            };

            var result = new CountryDetails
            {
                Country = details.FirstOrDefault().name,
                Currency = details.FirstOrDefault().currencies.FirstOrDefault().name,
                Weather = weatherDetails,
                Province = details.FirstOrDefault().region
            };
            return result;
           
        }

        public ResponseModel GenerateJWT()
        {
            var token = GenerateToken.GenerateJwtToken(_config);
            return new ResponseModel
            {
                ResponseCode = HttpStatusCode.OK,
                ResponseMessage = "Success",
                ResponseObject = token
            };
        }
    }
}
