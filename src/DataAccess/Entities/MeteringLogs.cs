using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.SaaS.Accelerator.DataAccess.Entities;
public partial class MeteringLogs
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public string TenantId { get; set; }
    public string ObjectId { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public int SubscriptionId { get; set; }
    public Guid AmpSubscriptionId { get; set; }
    public int DimensionId { get; set; }
    public int SubscriptionUserId { get; set; }

    public virtual Subscriptions Subscription { get; set; }
    public virtual MeteredDimensions MeteredDimension { get; set; }
    public virtual SubscriptionUsers SubscriptionUser { get; set; }

}
