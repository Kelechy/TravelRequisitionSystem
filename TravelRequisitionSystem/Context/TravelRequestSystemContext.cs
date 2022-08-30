using Microsoft.EntityFrameworkCore;
using TravelRequisitionSystem.Model;

namespace TravelRequisitionSystem.Context
{
    public class TravelRequestSystemContext : DbContext
    {
        public TravelRequestSystemContext(DbContextOptions<TravelRequestSystemContext> opt) : base(opt)
        {

        }

        public DbSet<TravelRequestDetail> travelRequestDetails { get; set; }
    }
}
