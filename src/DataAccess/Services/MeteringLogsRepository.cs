using Marketplace.SaaS.Accelerator.DataAccess.Context;
using Marketplace.SaaS.Accelerator.DataAccess.Contracts;
using Marketplace.SaaS.Accelerator.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.SaaS.Accelerator.DataAccess.Services;
public class MeteringLogsRepository : IMeteringLogsRepository
{
    private readonly SaasKitContext context;

    public MeteringLogsRepository(SaasKitContext context)
    {
        this.context = context;
    }
    public IEnumerable<MeteringLogs> Get()
    {
        return this.context.MeteringLogs.ToList();
    }

    public MeteringLogs Get(int id)
    {
        return this.context.MeteringLogs.Find(id);
    }

    public IEnumerable<MeteringLogs> GetLogsByUserId(int userId)
    {
        var userLogs = this.context.MeteringLogs
            .Include(x => x.MeteredDimension)
            .ThenInclude(x => x.Plan)
            .Include(x => x.SubscriptionUser)
            .Where(x => x.SubscriptionUserId == userId);

        return userLogs.ToList();
    }

    public void Remove(MeteringLogs entity)
    {
        this.context.MeteringLogs.Remove(entity);
    }

    public int Save(MeteringLogs entities)
    {
        var existingUser = this.context.MeteringLogs.Find(entities.Id);
        if (existingUser != null)
        {
            existingUser.ObjectId = entities.ObjectId;
            existingUser.TenantId = entities.TenantId;
            this.context.MeteringLogs.Update(existingUser);
            return existingUser.Id;
        }
        else
        {
            this.context.MeteringLogs.Add(entities);
        }

        this.context.SaveChanges();
        return entities.Id;
    }
}
