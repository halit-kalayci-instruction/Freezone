using Application.Tests.Mocks.Repositories;
using Xunit;

namespace Application.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // MOCKlama
            // 3A Principle
            // Arrange => Haz�rl�klar
            // Act => �lgili kod blo�unun execute edilmesi
            // Assert => Sonu�land�r�lma
            var result = "deneme"; // business kodundan gelen cevap
            Assert.Equal(result, "deneme1");
        }
        [Fact]
        public void Test2()
        {

        }
    }
}