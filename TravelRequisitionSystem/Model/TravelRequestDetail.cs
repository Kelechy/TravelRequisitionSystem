using System;
using System.ComponentModel.DataAnnotations;
using TravelRequisitionSystem.Utitlity;

namespace TravelRequisitionSystem.Model
{
    public class TravelRequestDetail
    {
        [Key]
        public int ID { get; set; }
        public DateTime RequestDate { get; set; }
        public string SourceLocation { get; set; }
        public string SourceCountry { get; set; }
        public string Destination { get; set; }
        public string DestinatioCountry { get; set; }
        public DateTime ProposedDepartureTimestamp { get; set; }
        public TravelClassEnums TravelClass { get; set; }
        public TripTypeEnums TripType { get; set; }
        public string ChargeCode { get; set; }
        public string TravelerName { get; set; }
        public Status RequisitionStatus { get; set; }
        public string RequisitionNumber { get; set; }

    }
}
