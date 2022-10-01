namespace MemeHub.Database.Extensions
{
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Source: https://www.red-gate.com/simple-talk/blogs/change-delete-behavior-and-more-on-ef-core/
    /// </summary>
    public static class DbContextExtensions
    {
        private static List<Action<IMutableEntityType>> Conventions = new List<Action<IMutableEntityType>>();

        public static void AddRemovePluralizeConvention(this ModelBuilder builder)
        {
            Conventions.Add(et => et.SetTableName(et.DisplayName()));
        }

        public static void AddRemoveOneToManyCascadeConvention(this ModelBuilder builder)
        {
            Conventions.Add(et => et.GetForeignKeys()
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict));
        }

        public static void ApplyConventions(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (Action<IMutableEntityType> action in Conventions)
                    action(entityType);
            }

            Conventions.Clear();
        }
    }
}
