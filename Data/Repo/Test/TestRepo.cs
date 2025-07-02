using BaseLibrary.Data;
using BaseLibrary.Data.Repo.Base;
using Microsoft.EntityFrameworkCore;

namespace BaseApiLibrary.TestObjects
{
    public interface ITestRepo : IBaseRepository<TestEntity>
    {
        void TestMethod(); // Example method to demonstrate functionality
    }
    public class TestRepo(AppDbContext ctx) : BaseRepository<DbContext, TestEntity>(ctx), ITestRepo
    {
        public void TestMethod()
        {
            Console.WriteLine("Test method called in TestRepo.");
        }
    }
}
