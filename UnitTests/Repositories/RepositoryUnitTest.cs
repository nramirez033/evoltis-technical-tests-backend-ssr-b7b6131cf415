using Xunit;

namespace technical_tests_backend_ssr.UnitTests.Repositories
{
    public class RepositoryUnitTest
    {
        [Fact(Skip = "Ejemplo")]
        public void Test1()
        {
            // Arrange
            int expected = 5;
            int actual = 2 + 3;
            // Act
            // Call the repository.
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
