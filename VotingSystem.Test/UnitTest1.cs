namespace VotingSystem.Test
{
  

    public static class TestOne
    {
        public static int Add(int a, int b) => a + b;
    }
    public class TestOneTests
    {

        [Fact]
        public void Add_AddsTwoNumbersTogether()
        {
            var result = TestOne.Add(1, 1);
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 1)]
        public void Add_AddsTwoNumbersTogether_Theory(int a, int b, int expected)
        {
            var result = TestOne.Add(a, b);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void TestListContainsValue()
        {
            var list = new List<int>{1, 2, 3, 5};
            Assert.Contains(1, list);
        }
    }
}