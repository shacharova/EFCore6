using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EFCore6.Dal.ValueGenerators
{
    public class UtcDateTimeGenerator : ValueGenerator<DateTime>
    {
        public override DateTime Next(EntityEntry entry)
        {
            return DateTime.UtcNow;
        }

        protected override object NextValue(EntityEntry entry)
        {
            return DateTime.UtcNow;
        }

        public override bool GeneratesTemporaryValues => false;
    }
}
