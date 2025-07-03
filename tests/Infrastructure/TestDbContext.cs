using BaseLibrary.Core.Entities.Base;
using BaseLibrary.Infrastructure.Storage.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TestAuditableEntity : AuditableEntity
    {
        public string TestString { get; set; }
        public float TestFloat { get; set; }

        public TestAuditableEntity(string testString, float testFloat)
        {
            TestString = testString;
            TestFloat = testFloat;
        }
    }
    public class TestDbContext : BaseDbContext
    {
        public TestDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

        public DbSet<TestAuditableEntity> TestEntities { get; set; }
    }


    public class BaseDbContextTests
    {
        [Fact]
        public async Task SaveChangesAsync_ShouldSetAuditFields_WhenAddingNewEntity()
        {
            var options = new DbContextOptionsBuilder<BaseDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_Audit")
                .Options;

            var entity = new TestAuditableEntity("Test", 2.0f);

            // Act
            using (var context = new TestDbContext(options))
            {
                context.TestEntities.Add(entity);
                await context.SaveChangesAsync();
            }

            //// Perform testing
            Assert.NotEqual(default(DateTime), entity.CreatedAt);
            Assert.NotEqual(default(DateTime), entity.UpdatedAt);

            // CreatedAt & UpdatedAt approx. equal
            TimeSpan tolerance = TimeSpan.FromMilliseconds(100);
            var expected = entity.UpdatedAt.Value;
            var actual = entity.CreatedAt.Value;
            Assert.True(
                Math.Abs((expected - actual).TotalMilliseconds) <= tolerance.TotalMilliseconds,
                $"Expected: {expected}, Actual: {actual}, Difference: {(expected - actual).TotalMilliseconds}ms"
            );
        }
    }
}