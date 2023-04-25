using ef7_example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ef7_example.Domain.interceptors;

public class AuditableInterceptor : SaveChangesInterceptor
{

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData,result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,InterceptionResult<int> result,CancellationToken cancellationToken)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData,result,cancellationToken);
    }

    public void UpdateEntities(DbContext context)
    {
        if(context is null) return;

        foreach(var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if(entry.State == EntityState.Added){
                entry.Entity.CreatedBy = "SYSTEM";
                entry.Entity.Created = DateTime.Now;
            }

            if(entry.State == EntityState.Modified)
            {
                entry.Entity.LastModifiedBy = "SYSTEM";
                entry.Entity.LastModified = DateTime.Now;
            }
        }
    }
}