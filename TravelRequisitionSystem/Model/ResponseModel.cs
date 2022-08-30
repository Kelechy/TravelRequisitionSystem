using System.Net;

namespace TravelRequisitionSystem.Model
{
    public class ResponseModel
    {
        public string ResponseMessage { get; set; }
        public object ResponseObject { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
    }
}
