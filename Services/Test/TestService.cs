using BaseLibrary.Data.Repo.Base;
using BaseLibrary.Services.Base;

namespace BaseApiLibrary.TestObjects
{
    public interface ITestService : IBaseService<TestEntity>
    {
        void TestMethod(); // Example method to demonstrate functionality
    }

    public class TestService(ITestRepo repo) : BaseService<TestEntity>(repo), ITestService
    {
        public void TestMethod()
        {
            // Example method to demonstrate functionality
            Console.WriteLine("Test method called in TestService.");
        }
    }
}
