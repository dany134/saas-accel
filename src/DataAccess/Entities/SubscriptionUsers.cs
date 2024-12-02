using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.SaaS.Accelerator.DataAccess.Entities
{
    public class SubscriptionUsers
    {
        public SubscriptionUsers()
        {
            MeteringLogs = new HashSet<MeteringLogs>();
        }
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string FullName { get; set; }
        public Guid AmpSubscriptionId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual Subscriptions Subscription { get; set; }
        public virtual ICollection<MeteringLogs> MeteringLogs { get; set; }
    }
}
