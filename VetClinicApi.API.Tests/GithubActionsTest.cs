namespace VetClinicApi.API.Tests
{
    public class GithubActionsTest
    {
        [Fact]
        public void SuccessTest()
        {
            Assert.True(true, "test for github action");
        }

        [Fact]
        public void FailedTest()
        {
            Assert.True(false, "test for github action");
        }
    }
}