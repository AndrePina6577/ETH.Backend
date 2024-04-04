using ETH.Domain.Common.Interfaces;
using ETH.Domain.Entities;
using ETH.Domain.Entities.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETH.Domain;

public sealed class SchoolContext : IdentityDbContext<User, Role<string>, string, IdentityUserClaim<string>, UserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SchoolContext"/> class.
    /// </summary>
    public SchoolContext()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SchoolContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseAudience> CourseAudiences { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<CoursesAudiences> CoursesAudiences { get; set; }
    public DbSet<CoursesCategories> CoursesCategories { get; set; }
    public DbSet<CourseSession> CourseSessions { get; set; }
    public DbSet<CourseTopic> CourseTopics { get; set; }
    public DbSet<CoursesTopics> CoursesTopics { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        ApplyConfigurations(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.DetectChanges();

        ProcessAddedEntities();
        ProcessUpdatedEntities();
        ProcessDeletedEntities();

        return base.SaveChangesAsync(cancellationToken);
    }

    private static void ApplyConfigurations(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CourseConfiguration());
        builder.ApplyConfiguration(new LocationConfiguration());
        builder.ApplyConfiguration(new CourseTopicConfiguration());
        builder.ApplyConfiguration(new CourseCategoryConfiguration());
        builder.ApplyConfiguration(new CourseAudienceConfiguration());
        builder.ApplyConfiguration(new CoursesTopicsConfiguration());
        builder.ApplyConfiguration(new CoursesCategoriesConfiguration());
        builder.ApplyConfiguration(new CoursesAudiencesConfiguration());
        builder.ApplyConfiguration(new CourseSessionConfiguration());
    }

    private void ProcessAddedEntities()
    {
        var entities = ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Added)
            .Select(t => t.Entity)
            .ToArray();

        foreach (var entity in entities)
        {
            switch (entity)
            {
                case IBaseEntity<int> baseEntity:
                {
                    baseEntity.Active = true;
                    baseEntity.CreatedAt = DateTimeOffset.Now;
                    baseEntity.UpdatedAt = DateTimeOffset.Now;
                    break;
                }
                case IBaseEntity<string> baseEntity:
                {
                    baseEntity.Active = true;
                    baseEntity.CreatedAt = DateTimeOffset.Now;
                    baseEntity.UpdatedAt = DateTimeOffset.Now;
                    break;
                }
                case IBaseManyToManyEntity manyEntity:
                {
                    manyEntity.Active = true;
                    manyEntity.CreatedAt = DateTimeOffset.Now;
                    manyEntity.UpdatedAt = DateTimeOffset.Now;
                    break;
                }
            }
        }
    }

    private void ProcessUpdatedEntities()
    {
        var entities = ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Modified)
            .Select(t => t.Entity)
            .ToArray();

        foreach (var entity in entities)
        {
            switch (entity)
            {
                case IBaseEntity<int> baseEntity:
                {
                    //frontend needs to explicitly say Active = false | true, else Active is not updated and remains its value
                    //therefore this should be a safe approach
                    if (baseEntity.Active == null)
                    {
                        Entry(baseEntity).Property(t => t.Active).IsModified = false;
                    }

                    Entry(baseEntity).Property(t => t.CreatedAt).IsModified = false;

                    baseEntity.UpdatedAt = DateTimeOffset.Now;
                    break;
                }
                case IBaseEntity<string> baseEntity:
                {
                    //frontend needs to explicitly say Active = false | true, else Active is not updated and remains its value
                    //therefore this should be a safe approach
                    if (baseEntity.Active == null)
                    {
                        Entry(baseEntity).Property(t => t.Active).IsModified = false;
                    }

                    Entry(baseEntity).Property(t => t.CreatedAt).IsModified = false;

                    baseEntity.UpdatedAt = DateTimeOffset.Now;
                    break;
                }
                case IBaseManyToManyEntity manyEntity:
                {
                    if (manyEntity.Active == null)
                    {
                        Entry(manyEntity).Property(t => t.Active).IsModified = false;
                    }

                    Entry(manyEntity).Property(t => t.CreatedAt).IsModified = false;

                    manyEntity.UpdatedAt = DateTimeOffset.Now;
                    break;
                }
            }
        }
    }

    private void ProcessDeletedEntities()
    {
        var entities = ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Deleted)
            .Select(t => t.Entity)
            .ToArray();

        foreach (var entity in entities)
        {
            Entry(entity).State = EntityState.Modified;

            switch (entity)
            {
                case IBaseEntity<int> baseEntity:
                {
                    // If we want to persist then we want to delete from database entirely
                    if (baseEntity.ToPersist())
                    {
                        Entry(entity).State = EntityState.Deleted;

                        continue;
                    }

                    Entry(baseEntity).Property(t => t.CreatedAt).IsModified = false;

                    baseEntity.Active = false;
                    baseEntity.UpdatedAt = DateTimeOffset.Now;
                    baseEntity.DeletedAt = DateTimeOffset.Now;
                    break;
                }
                case IBaseEntity<string> baseEntity:
                {
                    // If we want to persist then we want to delete from database entirely
                    if (baseEntity.ToPersist())
                    {
                        Entry(entity).State = EntityState.Deleted;

                        continue;
                    }

                    Entry(baseEntity).Property(t => t.CreatedAt).IsModified = false;

                    baseEntity.Active = false;
                    baseEntity.UpdatedAt = DateTimeOffset.Now;
                    baseEntity.DeletedAt = DateTimeOffset.Now;
                    break;
                }
                case IBaseManyToManyEntity manyEntity:
                {
                    if (manyEntity.ToPersist())
                    {
                        Entry(entity).State = EntityState.Deleted;

                        continue;
                    }

                    Entry(manyEntity).Property(t => t.CreatedAt).IsModified = false;

                    manyEntity.Active = false;
                    manyEntity.UpdatedAt = DateTimeOffset.Now;
                    manyEntity.DeletedAt = DateTimeOffset.Now;
                    break;
                }
            }
        }
    }
}
