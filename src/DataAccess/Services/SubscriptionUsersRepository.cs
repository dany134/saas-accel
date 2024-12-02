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
public class SubscriptionUsersRepository : ISubscriptionUsersRepository
{
    private readonly SaasKitContext context;

    public SubscriptionUsersRepository(SaasKitContext context)
    {
        this.context = context;
    }
    public IEnumerable<SubscriptionUsers> Get()
    {
        return this.context.SubscriptionUsers.ToList();
    }

    public SubscriptionUsers Get(int id)
    {
        return this.context.SubscriptionUsers.Find(id);
    }

    public IEnumerable<SubscriptionUsers> GetUsersByAmpSubscriptionId(Guid subscriptionId)
    {
        var subscriptionUsers = this.context.SubscriptionUsers
            .Include(x => x.Subscription)
            .Where(x => x.AmpSubscriptionId == subscriptionId)
            .ToList();

        return subscriptionUsers;
    }

    public void Remove(SubscriptionUsers entity)
    {
        this.context.SubscriptionUsers.Remove(entity);
    }

    public int Save(SubscriptionUsers entities)
    {
        var existingUser = this.context.SubscriptionUsers.Where(s => s.UserEmail == entities.UserEmail).FirstOrDefault();
        if (existingUser != null)
        {
            existingUser.FullName = entities.FullName;
            existingUser.UserEmail = entities.UserEmail;
            this.context.SubscriptionUsers.Update(existingUser);
            return existingUser.Id;
        }
        else
        {
            this.context.SubscriptionUsers.Add(entities);
        }

        this.context.SaveChanges();
        return entities.Id;
    }
}
