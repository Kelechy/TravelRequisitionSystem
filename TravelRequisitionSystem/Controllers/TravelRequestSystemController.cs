using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TravelRequisitionSystem.Data;
using TravelRequisitionSystem.DTO;
using TravelRequisitionSystem.Model;

namespace TravelRequisitionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelRequestSystemController : ControllerBase
    {
        private readonly ITravelRequestRepo _repository;
        private readonly IMapper _mapper;
        public TravelRequestSystemController(ITravelRequestRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [Authorize]
        [HttpPost]
        [Route("/SubmitTravelRequest")]
        public async Task<IActionResult> SubmitTravelRequest(TravelRequestModelDTO details)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(details);
                var detailDTO = _mapper.Map<TravelRequestDetail>(details);
                var result = await _repository.CreateTravelRequest(detailDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //[Authorize]
        //[HttpPost]
        //[Route("/UpdateTravelRequest")]
        //public async Task<IActionResult> UpdateTravelRequest(TravelRequestModelDTO details)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest(details);
        //        var detailDTO = _mapper.Map<TravelRequestDetail>(details);
        //        var result = await _repository.UpdateTravelRequest(detailDTO);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        [Authorize]
        [HttpDelete]
        [Route("/DeleteTravelRequest")]
        public async Task<IActionResult> DeleteTravelRequestByRequisitionNumber(string requisitionNumber)
        {
            try
            {
                var result = await _repository.DeleteTravelRequestByRequisitionNumber(requisitionNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("/SearchTravelRequest")]
        public async Task<IActionResult> SearchTravelRequestByRequisitionNumber(string requisitionNumber)
        {
            try
            {
                var result = await _repository.SearchTravelRequestByRequisitionNumber(requisitionNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet("[action]/{CountryName}")]
        public async Task<IActionResult> GetCountryDetails(string CountryName)
        {
            var response = await _repository.SearchCountryDetails(CountryName);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult GenerateToken()
        {
            var response = _repository.GenerateJWT();
            return Ok(response);
        }
    }
}
